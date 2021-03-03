using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOBJ;
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private Transform p0, p1, p2, p3;
    [Range(1, 10)]
    public float sens = 1;
    public bool rotate=false;
    private float oldT, oldMousePos, t = 0.5f;

    [Range(0, 1)]
    public float _t;

    private void Update()
    {
        playerOBJ.transform.localPosition = Vector3.Lerp(new Vector3(-2f, playerOBJ.transform.localPosition.y, playerOBJ.transform.localPosition.z),
                                          new Vector3(2f, playerOBJ.transform.localPosition.y, playerOBJ.transform.localPosition.z), t);

        if (rotate)
        {
            float rotationYTemp = transform.rotation.y;
            transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(p0.position, p1.position, p2.position, p3.position, _t));
            transform.position = new Vector3(Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, _t).x,
                                             transform.position.y,
                                             Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, _t).z);
            _t += (Time.deltaTime / speed) / 1.16f;
            if (_t >= 1)
            {
                rotate = false;
                transform.rotation = Quaternion.Euler(0, (transform.rotation.y > rotationYTemp) ? rotationYTemp + 90f : rotationYTemp - 90f, 0);
            }
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            _t = 0;
        }

        #region mouse move
        if (Input.GetMouseButtonDown(0))
        {
            oldT = t;
            oldMousePos = Input.mousePosition.x / Screen.width;
        }
        if (Input.GetMouseButton(0))
        {
            float posDelta = (Input.mousePosition.x / Screen.width - oldMousePos)*sens;
            if (t <= 0 && posDelta <= 0)
            {
                t = 0;
                oldT = 0;
                oldMousePos = Input.mousePosition.x / Screen.width;
            }
            else if (t >= 1 && posDelta >= 0)
            {
                t = 1;
                oldT = 1;
                oldMousePos = Input.mousePosition.x / Screen.width;
            }
            else
            {
                t = oldT + posDelta;
            }
        }
        #endregion
    }
}

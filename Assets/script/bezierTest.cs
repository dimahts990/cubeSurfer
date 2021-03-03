using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class bezierTest : MonoBehaviour
{
    public Transform p0, p1, p2, p3;

    [Range(0,1)]
    public float t;

    void Update()
    {
        transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(p0.position, p1.position, p2.position, p3.position, t));
    }

    private void OnDrawGizmos()
    {
        int sigmentNumber = 20;
        Vector3 preveousePoint = p0.position;

        for(int i = 0; i < sigmentNumber + 1; i++)
        {
            float parameter = (float)i / sigmentNumber;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }
}

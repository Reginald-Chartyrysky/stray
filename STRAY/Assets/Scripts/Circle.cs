using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public int vertexCount = 40;
    public float lineWidth = 0.2f;
    public float radius;

    private LineRenderer line;
  //  public bool circleFillsScreen;
    void Start()
    {
      //  line = GetComponent<LineRenderer>();
    //    SetupCircle();
    }

    void SetupCircle()
    {

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        float deltaTheta = (2f* Mathf.PI)/ vertexCount;
        float theta = 0f;

        Vector3 oldPos = transform.position; 
        for (int i = 0; i < vertexCount+1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }

#endif
}

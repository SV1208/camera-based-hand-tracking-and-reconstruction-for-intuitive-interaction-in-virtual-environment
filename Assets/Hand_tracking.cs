using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    public Vector3[] previouspoints;
    public float smooth_speed= 5f;
    void Start()
    {
        previouspoints = new Vector3[handPoints.Length];
        for(int i=0;i<handPoints.Length;i++){
            previouspoints[i]=handPoints[i].transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        print(data);
        string[] points = data.Split(',');
        print(points[0]);

        //0        1*3      2*3
        //x1,y1,z1,x2,y2,z2,x3,y3,z3

        for ( int i = 0; i<21; i++)
        {

            float x = 7-float.Parse(points[i * 3])/100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            Vector3 targetposition = new Vector3(x,y,z);
            handPoints[i].transform.localPosition = Vector3.Lerp(previouspoints[i], targetposition, Time.deltaTime * smooth_speed);
            previouspoints[i] = handPoints[i].transform.localPosition;
            // handPoints[i].transform.localPosition = new Vector3(x, y, z);

        }



    }
}




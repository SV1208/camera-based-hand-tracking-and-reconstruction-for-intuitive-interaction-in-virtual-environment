using UnityEngine;

public class finger : MonoBehaviour
{
    public Transform sphere1;
    public Transform sphere2;
    // Update is called once per frame
    private void Update()
    {
        Vector3 midpoint = (sphere1.position + sphere2.position) / 2f;
        transform.position = midpoint;

        Vector3 direction = sphere2.position - sphere1.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

        float distance = direction.magnitude; // Distance between landmarks
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, distance*0.9f);
    }
}


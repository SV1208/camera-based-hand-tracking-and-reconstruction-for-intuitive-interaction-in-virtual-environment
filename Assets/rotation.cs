using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform target;
    public int speed=25;

    void Update(){
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }   
}

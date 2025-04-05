    // using UnityEngine;
    // using UnityEngine.UI;
    // using TMPro;

    // public class Boxcollider : MonoBehaviour
    // {   public TextMeshProUGUI info;
    //     public float touchdistance=0.5f;
    //     public bool istouch=false;
    //     public Transform sphere1;
    //     public Transform sphere2;
    //     private bool sphere1Colliding = false;
    //     private bool sphere2Colliding = false;
    //     public float smooth_speed = 5f; 
    //     public float rotation_speed = 3f; 

    //     private void OnTriggerEnter(Collider other)
    //     {
    //         if (other.transform == sphere1) sphere1Colliding = true;
    //         if (other.transform == sphere2) sphere2Colliding = true;
    //     }

    //     private void OnTriggerExit(Collider other)
    //     {
    //         if (other.transform == sphere1) sphere1Colliding = false;
    //         if (other.transform == sphere2) sphere2Colliding = false;
    //     }

    //     private void Update()
    //     {       
    //         // float distancetocube = Vector3.Distance(sphere1.transform.position, transform.position);
    //         // if(sphere1Colliding && !istouch){
    //         //     istouch = true;
    //         //     Display(true);
    //         // }
    //         // else if(!sphere1Colliding && istouch){
    //         //     istouch = false;
    //         //     Display(false);
    //         // }
    //         if (sphere1Colliding && sphere2Colliding)
    //         {
    //             // Compute midpoint
    //             Vector3 midpoint = (sphere1.position + sphere2.position) / 2f;
    //             // transform.position = midpoint;
    //             transform.position = Vector3.Lerp(transform.position, midpoint, Time.deltaTime * smooth_speed);

    //             // Compute rotation
    //             Vector3 direction = sphere2.position - sphere1.position;
    //             Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
    //             // transform.rotation = rotation;
    //             transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_speed);
    //     }
    //     }

    //     void Display(bool show){
    //         if(show){
    //             info.text="these is a cube Solo leeling and amagami sistera both are a harem that i like hte msost ";
    //         }
    //         else{
    //             info.text="";
    //         }
    //     }
    // }




using UnityEngine;
using TMPro;

public class Boxcollider : MonoBehaviour
{
    public TextMeshProUGUI info; // UI Text element for showing the info
    public float touchdistance = 0.5f;
    public bool istouch = false;
    public Transform sphere1;
    public Transform sphere2;
    private bool sphere1Colliding = false;
    private bool sphere2Colliding = false;
    public float smooth_speed = 5f;
    public float rotation_speed = 3f;
    public float displayDistance = 2f; // Distance to display text above the cube

    private void OnTriggerEnter(Collider other)
    {
        // If sphere1 or sphere2 collide with the cube
        if (other.transform == sphere1)
            sphere1Colliding = true;

        if (other.transform == sphere2)
            sphere2Colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // If sphere1 or sphere2 exit the collision area with the cube
        if (other.transform == sphere1)
            sphere1Colliding = false;

        if (other.transform == sphere2)
            sphere2Colliding = false;
    }

    private void Update()
    {
        // When sphere1 is colliding with the cube
        if (sphere1Colliding && !istouch)
        {
            istouch = true;
            Display(true); // Show the text
        }
        // When sphere1 is no longer colliding with the cube, start the cooldown
        else if (!sphere1Colliding && istouch)
        {
            istouch = false;
            Display(false);
        }

        // Move and rotate the cube when both spheres are colliding
        if (sphere1Colliding && sphere2Colliding)
        {
            // Compute midpoint
            Vector3 midpoint = (sphere1.position + sphere2.position) / 2f;
            transform.position = Vector3.Lerp(transform.position, midpoint, Time.deltaTime * smooth_speed);

            // Compute rotation to face the direction from sphere1 to sphere2
            Vector3 direction = sphere2.position - sphere1.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_speed);
        }
    }

    void Display(bool show)
    {
        // Show or hide the text based on the collision state
        if (show)
        {
            // Update the text
            info.text = "These are the cube and the spheres interacting. This is my favorite text to display!";

            // Update text position above the cube (Camera-relative positioning)
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * displayDistance);
            info.transform.position = screenPosition; // Update position on screen
        }
        else
        {
            // Clear the text
            info.text = "";
        }
    }
}

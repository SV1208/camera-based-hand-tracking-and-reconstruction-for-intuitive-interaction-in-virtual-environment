// using UnityEngine;
// using TMPro;

// public class Earth_picking : MonoBehaviour
// {
//     public TextMeshProUGUI info;
//     public Rigidbody earthRigidbody;
//     public float smooth_speed = 5f;
//     public float rotation_speed = 3f;
//     public float displayDistance = 2f; 
//     public Transform sphere1;
//     public Transform sphere2;
//     private CircularOrbit orbitScript; // Reference to the CircularOrbit script
//     private bool isPickedUp = false;
//     private bool sphere1Colliding = false;
//     private bool sphere2Colliding = false;
//     private Vector3 lastVelocity; // Store Earth's velocity before stopping

    
//     private void Start()
//     {
//         // Find and store the CircularOrbit script attached to the GameObject tagged "TagA"
//         orbitScript = GameObject.FindGameObjectWithTag("TagA").GetComponent<CircularOrbit>();
//     }

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

//     void Update()
//     {
//         if (sphere1Colliding && sphere2Colliding)
//         {
//             if (!isPickedUp)
//             {
//                 orbitScript.Pause(); // Stop orbiting
//             }

//             // Move Earth smoothly to midpoint
//             Vector3 midpoint = (sphere1.position + sphere2.position) / 2f;
//             transform.position = Vector3.Lerp(transform.position, midpoint, Time.deltaTime * smooth_speed);

//             // Rotate Earth to align with the direction between spheres
//             Vector3 direction = sphere2.position - sphere1.position;
//             Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
//             transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_speed);
//         }
//         else if (isPickedUp) // If released
//         {
//             orbitScript.Resume(); // Resume orbit
//         }
//     }

//     void PickUpEarth()
//     {
//         isPickedUp = true;
//         lastVelocity = earthRigidbody.linearVelocity; // Store velocity before stopping
//         orbitScript.enabled = false; // Disable orbit motion
//         earthRigidbody.linearVelocity = Vector3.zero; // Stop movement
//     }

//     void ReleaseEarth()
//     {
//         isPickedUp = false;
//         orbitScript.enabled = true; // Re-enable orbit motion
//     }
// }


// using UnityEngine;
// using TMPro;

// public class Earth_picking : MonoBehaviour
// {
//     public TextMeshProUGUI info;
//     public Rigidbody earthRigidbody;
//     public float smooth_speed = 5f;
//     public float rotation_speed = 3f;
//     public float displayDistance = 2f;
//     public Transform sphere1;
//     public Transform sphere2;
//     private CircularOrbit orbitScript;
//     private bool isPickedUp = false;
//     private bool sphere1Colliding = false;
//     private bool sphere2Colliding = false;
//     private Vector3 lastVelocity;

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

//     void Update()
//     {
//         if (sphere1Colliding && sphere2Colliding)
//         {
//             Vector3 midpoint = (sphere1.position + sphere2.position) / 2f;
//             transform.position = Vector3.Lerp(transform.position, midpoint, Time.deltaTime * smooth_speed);

//             Vector3 direction = sphere2.position - sphere1.position;
//             Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
//             transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_speed);
//         }
//     }
// }


using UnityEngine;
using TMPro;

public class Earth_picking : MonoBehaviour
{
    public TextMeshProUGUI info;
    public Rigidbody earthRigidbody;
    public float smooth_speed = 5f;
    public float rotation_speed = 3f;
    public Transform sphere1;
    public Transform sphere2;
    private bool isPickedUp = false;
    private bool sphere1Colliding = false;
    private bool sphere2Colliding = false;
    private Vector3 lastVelocity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == sphere1) sphere1Colliding = true;
        if (other.transform == sphere2) sphere2Colliding = true;
        
        if (sphere1Colliding && sphere2Colliding)
        {
            PickUpEarth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == sphere1) sphere1Colliding = false;
        if (other.transform == sphere2) sphere2Colliding = false;
        
        if (!sphere1Colliding && !sphere2Colliding)
        {
            ReleaseEarth();
        }
    }

    private void PickUpEarth()
    {
        isPickedUp = true;
        lastVelocity = earthRigidbody.linearVelocity;
        earthRigidbody.linearVelocity = Vector3.zero;
        earthRigidbody.useGravity = false;
    }

    private void ReleaseEarth()
    {
        isPickedUp = false;
        earthRigidbody.useGravity = true;
        earthRigidbody.linearVelocity = lastVelocity;
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }

    void Update()
    {
        if (isPickedUp)
        {
            Vector3 midpoint = (sphere1.position + sphere2.position) / 2f;
            transform.position = Vector3.Lerp(transform.position, midpoint, Time.deltaTime * smooth_speed);

            Vector3 direction = sphere2.position - sphere1.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_speed);
        }
    }
}
// // using System;
// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class PlanetGravity : MonoBehaviour
// // {
// //     public GameObject objectToAttract; // The object that will orbit (Earth)
// //     public bool orbit = false;
// //     public float G = 1f; // Gravitational constant
// //     private bool collided = false;

// //     // Reference to LineRenderer
// //     private LineRenderer lineRenderer;
// //     private List<Vector3> positions = new List<Vector3>(); // List to store the points of the orbit path

// //     private void Start()
// //     {
// //         if (orbit)
// //             Orbit();

// //         // Initialize the LineRenderer
// //         lineRenderer = objectToAttract.GetComponent<LineRenderer>();
// //         if (lineRenderer == null)
// //         {
// //             lineRenderer = objectToAttract.AddComponent<LineRenderer>();
// //         }

// //         lineRenderer.positionCount = 0; // Start with no points
// //         lineRenderer.startWidth = 0.1f; // Set the line width
// //         lineRenderer.endWidth = 0.1f;
// //         lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Default material
// //         lineRenderer.startColor = Color.green; // Path color
// //         lineRenderer.endColor = Color.green;
// //     }

// //     private void FixedUpdate()
// //     {
// //         if (objectToAttract == null)
// //             return;

// //         if (collided)
// //             return;

// //         // Apply gravitational force
// //         ApplyGravity();

// //         // Update the path of the object using LineRenderer
// //         UpdatePath();
// //     }

// //     private void ApplyGravity()
// //     {
// //         float objAttractMass = objectToAttract.GetComponent<Rigidbody>().mass;
// //         float planetMass = GetComponent<Rigidbody>().mass;
// //         float distance = Vector3.Distance(gameObject.transform.position, objectToAttract.transform.position);
// //         float force = G * (objAttractMass * planetMass) / (distance * distance);

// //         // Calculate direction
// //         Vector3 direction = transform.position - objectToAttract.transform.position;

// //         // Apply force
// //         objectToAttract.GetComponent<Rigidbody>().AddForce(direction.normalized * force);
// //     }

// //     private void Orbit()
// //     {
// //         // Orbital Speed Equation
// //         float planetMass = GetComponent<Rigidbody>().mass;
// //         float distance = Vector3.Distance(objectToAttract.transform.position, transform.position);
// //         objectToAttract.transform.LookAt(transform);
// //         Vector3 velocity = objectToAttract.transform.right * Mathf.Sqrt(G * planetMass / distance);
// //         objectToAttract.GetComponent<Rigidbody>().linearVelocity = velocity;
// //     }

// //     private void UpdatePath()
// //     {
// //         // Add the current position of the object to the path
// //         positions.Add(objectToAttract.transform.position);

// //         // Update the position count of the LineRenderer
// //         lineRenderer.positionCount = positions.Count;

// //         // Set the positions of the LineRenderer to the stored path positions
// //         for (int i = 0; i < positions.Count; i++)
// //         {
// //             lineRenderer.SetPosition(i, positions[i]);
// //         }
// //     }

// //     private void OnCollisionEnter(Collision collision)
// //     {
// //         // Uncomment if you want to stop the orbit when collision occurs
// //         // collided = true;
// //     }
// // }



// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlanetGravity : MonoBehaviour
// {
//     public GameObject objectToAttract; // The object that will orbit (Earth)
//     public bool orbit = false;
//     public float G = 1f; // Gravitational constant
//     private bool collided = false;

//     // LineRenderer for path visualization
//     private LineRenderer lineRenderer;
//     private List<Vector3> positions = new List<Vector3>(); // List to store the points of the orbit path

//     // Variables for elliptical orbit
//     private Vector3 initialVelocity;
//     private float semiMajorAxis;
//     private Vector3 velocity;

//     private void Start()
//     {
//         if (orbit)
//             Orbit();

//         // Initialize LineRenderer
//         lineRenderer = objectToAttract.GetComponent<LineRenderer>();
//         if (lineRenderer == null)
//         {
//             lineRenderer = objectToAttract.AddComponent<LineRenderer>();
//         }

//         lineRenderer.positionCount = 0; // Start with no points
//         lineRenderer.startWidth = 0.1f; // Set the line width
//         lineRenderer.endWidth = 0.1f;
//         lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Default material
//         lineRenderer.startColor = Color.green; // Path color
//         lineRenderer.endColor = Color.green;
//     }

//     private void FixedUpdate()
//     {
//         if (objectToAttract == null)
//             return;

//         if (collided)
//             return;

//         // Apply gravitational force
//         ApplyGravity();

//         // Update the path of the object using LineRenderer
//         UpdatePath();
//     }

//     private void ApplyGravity()
//     {
//         float objAttractMass = objectToAttract.GetComponent<Rigidbody>().mass;
//         float planetMass = GetComponent<Rigidbody>().mass;
//         float distance = Vector3.Distance(gameObject.transform.position, objectToAttract.transform.position);
//         float force = G * (objAttractMass * planetMass) / (distance * distance);

//         // Calculate direction
//         Vector3 direction = transform.position - objectToAttract.transform.position;

//         // Apply force to the object
//         objectToAttract.GetComponent<Rigidbody>().AddForce(direction.normalized * force);
//     }

//     private void Orbit()
//     {
//         // Semi-major axis of the elliptical orbit (average of the periapsis and apoapsis)
//         float distance = Vector3.Distance(objectToAttract.transform.position, transform.position);
//         semiMajorAxis = distance * 1.5f; // You can adjust this for your desired elliptical shape

//         // Orbital Speed Calculation for elliptical orbit
//         // Using the vis-viva equation: v = sqrt(G * M * (2/r - 1/a))
//         // Where 'r' is the distance to the Sun, 'a' is the semi-major axis
//         float velocityMagnitude = Mathf.Sqrt(G * GetComponent<Rigidbody>().mass * (2 / distance - 1 / semiMajorAxis));
        
//         // Set the initial tangential velocity direction (perpendicular to the direction towards the Sun)
//         Vector3 directionToSun = objectToAttract.transform.position - transform.position; // vector from earth to sun 
//         Vector3 tangentialDirection = Vector3.Cross(directionToSun, Vector3.up).normalized; // Perpendicular direction vector up is the y-axis

//         // Set initial velocity
//         velocity = tangentialDirection * velocityMagnitude;
//         objectToAttract.GetComponent<Rigidbody>().linearVelocity = velocity; // Apply initial velocity
//     }

//     private void UpdatePath()
//     {
//         // Add the current position of the object to the path
//         positions.Add(objectToAttract.transform.position);

//         // Update the position count of the LineRenderer
//         lineRenderer.positionCount = positions.Count;

//         // Set the positions of the LineRenderer to the stored path positions
//         for (int i = 0; i < positions.Count; i++)
//         {
//             lineRenderer.SetPosition(i, positions[i]);
//         }
//     }

//     private void OnCollisionEnter(Collision collision)
//     {
//         // Uncomment if you want to stop the orbit when collision occurs
//         // collided = true;
//     }
// }


// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlanetGravity : MonoBehaviour
// {
//     public GameObject objectToAttract; // Earth
//     public bool orbit = false;
//     public float G = 1f; // Gravitational constant
//     private bool collided = false;

//     // LineRenderer for orbit path visualization
//     private LineRenderer lineRenderer;
//     private List<Vector3> positions = new List<Vector3>(); // Stores orbit path points

//     // Variables for elliptical orbit
//     private Vector3 initialVelocity;
//     private float semiMajorAxis;
//     private Vector3 velocity;

//     private Earth_picking earthPicking; // Reference to Earth picking script

//     private void Start()
//     {
//         if (orbit)
//             Orbit();

//         // Initialize LineRenderer
//         lineRenderer = objectToAttract.GetComponent<LineRenderer>();
//         if (lineRenderer == null)
//         {
//             lineRenderer = objectToAttract.AddComponent<LineRenderer>();
//         }

//         lineRenderer.positionCount = 0; // Start with no points
//         lineRenderer.startWidth = 0.1f;
//         lineRenderer.endWidth = 0.1f;
//         lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Default material
//         lineRenderer.startColor = Color.green;
//         lineRenderer.endColor = Color.green;

//         // Get Earth_picking script reference
//         earthPicking = objectToAttract.GetComponent<Earth_picking>();
//     }

//     private void FixedUpdate()
//     {
//         if (objectToAttract == null || collided)
//             return;

//         // Stop applying gravity if Earth is picked up
//         if (earthPicking != null && earthPicking.IsPickedUp())
//             return;

//         // Apply gravitational force
//         ApplyGravity();

//         // Update the orbit path
//         UpdatePath();
//     }

//     private void ApplyGravity()
//     {
//         float objAttractMass = objectToAttract.GetComponent<Rigidbody>().mass;
//         float planetMass = GetComponent<Rigidbody>().mass;
//         float distance = Vector3.Distance(gameObject.transform.position, objectToAttract.transform.position);
//         float force = G * (objAttractMass * planetMass) / (distance * distance);

//         // Calculate direction
//         Vector3 direction = transform.position - objectToAttract.transform.position;

//         // Apply force to the object
//         objectToAttract.GetComponent<Rigidbody>().AddForce(direction.normalized * force);
//     }

//     private void Orbit()
//     {
//         float distance = Vector3.Distance(objectToAttract.transform.position, transform.position);
//         semiMajorAxis = distance * 1.5f; // Adjust for elliptical shape

//         // Calculate orbital velocity using the vis-viva equation
//         float velocityMagnitude = Mathf.Sqrt(G * GetComponent<Rigidbody>().mass * (2 / distance - 1 / semiMajorAxis));

//         // Set initial tangential velocity direction (perpendicular to direction towards the Sun)
//         Vector3 directionToSun = objectToAttract.transform.position - transform.position;
//         Vector3 tangentialDirection = Vector3.Cross(directionToSun, Vector3.up).normalized;

//         // Apply initial velocity
//         velocity = tangentialDirection * velocityMagnitude;
//         objectToAttract.GetComponent<Rigidbody>().linearVelocity = velocity;
//     }

//     private void UpdatePath()
//     {
//         // Add the current position of the object to the path
//         positions.Add(objectToAttract.transform.position);

//         // Update LineRenderer
//         lineRenderer.positionCount = positions.Count;
//         for (int i = 0; i < positions.Count; i++)
//         {
//             lineRenderer.SetPosition(i, positions[i]);
//         }
//     }

//     private void OnCollisionEnter(Collision collision)
//     {
//         // Uncomment if you want to stop orbit on collision
//         // collided = true;
//     }
// }


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public GameObject objectToAttract; // Earth
    public bool orbit = false;
    public float G = 1f; // Gravitational constant
    private bool collided = false;

    // LineRenderer for orbit path visualization
    private LineRenderer lineRenderer;
    private List<Vector3> positions = new List<Vector3>(); // Stores orbit path points

    // Variables for elliptical orbit
    private Vector3 initialVelocity;
    private float semiMajorAxis;
    private Vector3 velocity;
    private Vector3 storedVelocity = Vector3.zero; // Stores Earth's velocity when picked up

    private Earth_picking earthPicking; // Reference to Earth picking script

    private void Start()
    {
        if (orbit)
            Orbit();

        // Initialize LineRenderer
        lineRenderer = objectToAttract.GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = objectToAttract.AddComponent<LineRenderer>();
        }

        lineRenderer.positionCount = 0; // Start with no points
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Default material
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;

        // Get Earth_picking script reference
        earthPicking = objectToAttract.GetComponent<Earth_picking>();
    }

    private void FixedUpdate()
    {
        if (objectToAttract == null || collided)
            return;

        Rigidbody earthRb = objectToAttract.GetComponent<Rigidbody>();

        if (earthPicking != null)
        {
            if (earthPicking.IsPickedUp())
            {
                // Store the velocity when picked up
                if (storedVelocity == Vector3.zero) 
                {
                    storedVelocity = earthRb.linearVelocity;
                }
                earthRb.linearVelocity = Vector3.zero; // Stop movement
                return;
            }
            else if (storedVelocity != Vector3.zero)
            {
                // Restore velocity when released
                earthRb.linearVelocity = storedVelocity;
                storedVelocity = Vector3.zero; // Reset stored velocity
            }
        }

        // Apply gravitational force
        ApplyGravity();

        // Update the orbit path
        UpdatePath();
    }

    private void ApplyGravity()
    {
        float objAttractMass = objectToAttract.GetComponent<Rigidbody>().mass;
        float planetMass = GetComponent<Rigidbody>().mass;
        float distance = Vector3.Distance(gameObject.transform.position, objectToAttract.transform.position);
        float force = G * (objAttractMass * planetMass) / (distance * distance);

        // Calculate direction
        Vector3 direction = transform.position - objectToAttract.transform.position;

        // Apply force to the object
        objectToAttract.GetComponent<Rigidbody>().AddForce(direction.normalized * force);
    }

    private void Orbit()
    {
        float distance = Vector3.Distance(objectToAttract.transform.position, transform.position);
        semiMajorAxis = distance * 1.5f; // Adjust for elliptical shape

        // Calculate orbital velocity using the vis-viva equation
        float velocityMagnitude = Mathf.Sqrt(G * GetComponent<Rigidbody>().mass * (2 / distance - 1 / semiMajorAxis));

        // Set initial tangential velocity direction (perpendicular to direction towards the Sun)
        Vector3 directionToSun = objectToAttract.transform.position - transform.position;
        Vector3 tangentialDirection = Vector3.Cross(directionToSun, Vector3.up).normalized;

        // Apply initial velocity
        velocity = tangentialDirection * velocityMagnitude;
        objectToAttract.GetComponent<Rigidbody>().linearVelocity = velocity;
    }

    private void UpdatePath()
    {
        // Add the current position of the object to the path
        positions.Add(objectToAttract.transform.position);

        // Update LineRenderer
        lineRenderer.positionCount = positions.Count;
        for (int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Uncomment if you want to stop orbit on collision
        // collided = true;
    }
}

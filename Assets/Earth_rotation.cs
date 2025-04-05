// using UnityEngine;

// public class CircularOrbit : MonoBehaviour
// {
//     public Transform sun; // Reference to the Sun (center of orbit)
//     public Rigidbody earthRigidbody; // Reference to the Earth's Rigidbody
//     public LineRenderer lineRenderer; // Reference to the LineRenderer to visualize the path

//     public float G = 0.01f; // Gravitational constant (scaled for Unity)
//     public float sunMass =1000f ; // Mass of the Sun (scaled)
//     public float earthMass = 100f; // Mass of Earth (scaled)

//     void Start()
//     {
//         SetInitialVelocity();

//         // Initialize LineRenderer
//         if (lineRenderer == null)
//         {
//             lineRenderer = gameObject.AddComponent<LineRenderer>();
//         }
//         lineRenderer.positionCount = 0; // Start with no points
//     }

//     void FixedUpdate()
//     {
//         ApplyCentripetalForce();
//         UpdatePath();
//     }

//     // Set the initial tangential velocity for circular motion
//     void SetInitialVelocity()
//     {
//         // Calculate the distance between the Earth and the Sun
//         Vector3 directionToSun = sun.position - earthRigidbody.position;
//         float distance = directionToSun.magnitude;

//         // Calculate the initial velocity using the centripetal force formula
//         float velocity = Mathf.Sqrt(G * sunMass / distance); // Circular velocity v = sqrt(G * M / r)

//         // Get a perpendicular direction (tangential to the orbit)
//         Vector3 tangentialDirection = Vector3.Cross(directionToSun, Vector3.up).normalized;

//         // Set the velocity of the Earth (tangential to the orbit)
//         earthRigidbody.linearVelocity = tangentialDirection * velocity;
//     }

//     // Apply centripetal force (gravitational force) to keep Earth in orbit
//     void ApplyCentripetalForce()
//     {
//         // Direction from Earth to the Sun
//         Vector3 directionToSun = sun.position - earthRigidbody.position;
//         float distance = directionToSun.magnitude;

//         // Calculate the gravitational force as centripetal force
//         float forceMagnitude = G * (sunMass * earthMass) / (distance * distance);
//         Vector3 force = directionToSun.normalized * forceMagnitude;

//         // Apply the force to Earth
//         earthRigidbody.AddForce(force);

//         // Debugging: Draw a line to visualize the direction of the centripetal force (red)
//         Debug.DrawRay(earthRigidbody.position, force.normalized * 2f, Color.red); // Visualize the force direction

//         // Debugging: Draw a line to visualize the direction of the velocity (green)
//         Debug.DrawRay(earthRigidbody.position, earthRigidbody.linearVelocity.normalized * 2f, Color.green); // Visualize the velocity direction

//         // Debugging: Print the force magnitude to check if it's being applied correctly
//         Debug.Log("Centripetal Force Magnitude: " + forceMagnitude);

//         // Debugging: Check the velocity vector and ensure it's tangential
//         Debug.Log("Velocity: " + earthRigidbody.linearVelocity);
//     }

//     // Update the path (optional for visualizing Earth's orbit)
//     void UpdatePath()
//     {
//         // Add new position to the LineRenderer to visualize Earth's path
//         if (lineRenderer.positionCount == 0 || Vector3.Distance(earthRigidbody.position, lineRenderer.GetPosition(lineRenderer.positionCount - 1)) > 0.1f)
//         {
//             lineRenderer.positionCount++; // Increase the position count for the path
//             lineRenderer.SetPosition(lineRenderer.positionCount - 1, earthRigidbody.position); // Set the last point of the path to Earth's current position
//         }
//     }

//     public void Pause()
//     {
//         // Disable this script to stop the Update method from running
//         this.enabled = false;
//     }

//     public void Resume()
//     {
//         // Enable the script to resume the Update method
//         this.enabled = true;
//     }
// }


// using UnityEngine;
// public class CircularOrbit : MonoBehaviour
// {
//     public Transform sun;
//     public Rigidbody earthRigidbody;
//     public LineRenderer lineRenderer;
//     public float G = 0.01f;
//     public float sunMass = 1000f;
//     public float earthMass = 100f;

//     private bool isPaused = false;
//     private Vector3 storedVelocity;

//     void Start()
//     {
//         SetInitialVelocity();

//         if (lineRenderer == null)
//         {
//             lineRenderer = gameObject.AddComponent<LineRenderer>();
//         }
//         lineRenderer.positionCount = 0;
//     }

//     void FixedUpdate()
//     {
//         if (!isPaused)
//         {
//             ApplyCentripetalForce();
//         }
//         UpdatePath();
//     }

//     void SetInitialVelocity()
//     {
//         Vector3 directionToSun = sun.position - earthRigidbody.position;
//         float distance = directionToSun.magnitude;
//         float velocity = Mathf.Sqrt(G * sunMass / distance);
//         Vector3 tangentialDirection = Vector3.Cross(directionToSun, Vector3.up).normalized;
//         earthRigidbody.linearVelocity = tangentialDirection * velocity;
//     }

//     void ApplyCentripetalForce()
//     {
//         Vector3 directionToSun = sun.position - earthRigidbody.position;
//         float distance = directionToSun.magnitude;
//         float forceMagnitude = G * (sunMass * earthMass) / (distance * distance);
//         Vector3 force = directionToSun.normalized * forceMagnitude;
//         earthRigidbody.AddForce(force);

//         Debug.DrawRay(earthRigidbody.position, force.normalized * 2f, Color.red);
//         Debug.DrawRay(earthRigidbody.position, earthRigidbody.linearVelocity.normalized * 2f, Color.green);
//     }

//     void UpdatePath()
//     {
//         if (lineRenderer.positionCount == 0 || Vector3.Distance(earthRigidbody.position, lineRenderer.GetPosition(lineRenderer.positionCount - 1)) > 0.1f)
//         {
//             lineRenderer.positionCount++;
//             lineRenderer.SetPosition(lineRenderer.positionCount - 1, earthRigidbody.position);
//         }
//     }

//     public void Pause()
//     {
//         if (!isPaused)
//         {
//             storedVelocity = earthRigidbody.linearVelocity;  // Store current velocity
//             earthRigidbody.linearVelocity = Vector3.zero;   // Stop Earth's movement
//             isPaused = true;
//         }
//     }

//     public void Resume()
//     {
//         if (isPaused)
//         {
//             earthRigidbody.linearVelocity = storedVelocity;  // Restore stored velocity
//             isPaused = false;
//         }
//     }
// }


using UnityEngine;

public class CircularOrbit : MonoBehaviour
{
    public Transform sun;
    public Rigidbody earthRigidbody;
    public LineRenderer lineRenderer;
    public float G = 0.01f;
    public float sunMass = 1000f;
    public float earthMass = 100f;

    private bool isPaused = false; // New flag to track if motion is paused

    void Start()
    {
        SetInitialVelocity();

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.positionCount = 0;
    }

    void FixedUpdate()
    {
        if (!isPaused) // Prevent movement when paused
        {
            ApplyCentripetalForce();
            UpdatePath();
        }
    }

    public void Pause() // Stop the orbit
    {
        isPaused = true;
        earthRigidbody.linearVelocity = Vector3.zero; // Stop movement
        earthRigidbody.angularVelocity = Vector3.zero;
        Debug.Log("Orbit Paused");
    }

    public void Resume() // Resume the orbit
    {
        isPaused = false;
        SetInitialVelocity(); // Restore velocity
        Debug.Log("Orbit Resumed");
    }

    void SetInitialVelocity()
    {
        Vector3 directionToSun = sun.position - earthRigidbody.position;
        float distance = directionToSun.magnitude;
        float velocity = Mathf.Sqrt(G * sunMass / distance);
        Vector3 tangentialDirection = Vector3.Cross(directionToSun, Vector3.up).normalized;
        earthRigidbody.linearVelocity = tangentialDirection * velocity;
    }

    void ApplyCentripetalForce()
    {
        if (isPaused) return;

        Vector3 directionToSun = sun.position - earthRigidbody.position;
        float distance = directionToSun.magnitude;
        float forceMagnitude = G * (sunMass * earthMass) / (distance * distance);
        Vector3 force = directionToSun.normalized * forceMagnitude;
        earthRigidbody.AddForce(force);
    }

    void UpdatePath()
    {
        if (lineRenderer.positionCount == 0 || Vector3.Distance(earthRigidbody.position, lineRenderer.GetPosition(lineRenderer.positionCount - 1)) > 0.1f)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, earthRigidbody.position);
        }
    }
}

// using System.Collections.Generic;
// using UnityEngine;

// public class HandTrackedCameraControl : MonoBehaviour
// {
//     public Camera mainCamera;
//     public Transform thumb, index, middle;

//     private float minPosition = -10f, maxPosition = 10f;  // Camera movement limits
//     private float minZoom = 30f, maxZoom = 60f;  // Zoom limits (FOV)
//     private float targetCameraPosition;  // Target X position of the camera
//     private float targetZoom;  // Target zoom (FOV)
//     private Vector3 previousThumbPosition = Vector3.zero;
//     private float movementThreshold = 0.01f;  // Sensitivity for horizontal movement
//     private float zoomThreshold = 0.01f;  // Sensitivity for zoom movement
//     private float smoothSpeed = 3f;  // Smoothness factor
//     private float threshold = 0.4f;  // Distance threshold to check if fingers are touching

//     private List<float> thumbMovements = new List<float>();
//     private List<float> thumbZoomMovements = new List<float>();

//     void Start()
//     {
//         thumbMovements.Clear();
//         thumbZoomMovements.Clear();

//         // Set initial position and zoom
//         targetCameraPosition = mainCamera.transform.position.x;
//         targetZoom = mainCamera.fieldOfView;
//     }

//     void Update()
//     {
//         if (IsFingersTouching())
//         {
//             Vector3 currentThumbPosition = thumb.position;

//             if (previousThumbPosition != Vector3.zero)
//             {
//                 float thumbMovementX = currentThumbPosition.x - previousThumbPosition.x;
//                 float thumbMovementY = currentThumbPosition.y - previousThumbPosition.y;

//                 // Ignore small movements (reduce noise)
//                 if (Mathf.Abs(thumbMovementX) > movementThreshold)
//                 {
//                     StoreThumbMovement(thumbMovementX);
//                     float avgThumbMovementX = GetAverageThumbMovement();

//                     if (avgThumbMovementX < 0)
//                         MoveLeft();
//                     else if (avgThumbMovementX > 0)
//                         MoveRight();
//                 }

//                 if (Mathf.Abs(thumbMovementY) > zoomThreshold)
//                 {
//                     StoreThumbZoomMovement(thumbMovementY);
//                     float avgThumbMovementY = GetAverageThumbZoomMovement();

//                     if (avgThumbMovementY > 0)
//                         ZoomIn();
//                     else if (avgThumbMovementY < 0)
//                         ZoomOut();
//                 }
//             }

//             previousThumbPosition = currentThumbPosition;
//         }

//         SmoothCameraMovement();
//         SmoothZoom();
//     }

//     bool IsFingersTouching()
//     {
//         float distanceBetweenThumbAndIndex = Vector3.Distance(thumb.position, index.position);
//         float distanceBetweenIndexAndMiddle = Vector3.Distance(index.position, middle.position);

//         return distanceBetweenThumbAndIndex < threshold && distanceBetweenIndexAndMiddle < threshold;
//     }

//     void StoreThumbMovement(float movement)
//     {
//         thumbMovements.Add(movement);
//         if (thumbMovements.Count > 5)
//             thumbMovements.RemoveAt(0);
//     }

//     float GetAverageThumbMovement()
//     {
//         if (thumbMovements.Count == 0) return 0;
//         float sum = 0f;
//         foreach (float movement in thumbMovements)
//             sum += movement;
//         return sum / thumbMovements.Count;
//     }

//     void StoreThumbZoomMovement(float movement)
//     {
//         thumbZoomMovements.Add(movement);
//         if (thumbZoomMovements.Count > 5)
//             thumbZoomMovements.RemoveAt(0);
//     }

//     float GetAverageThumbZoomMovement()
//     {
//         if (thumbZoomMovements.Count == 0) return 0;
//         float sum = 0f;
//         foreach (float movement in thumbZoomMovements)
//             sum += movement;
//         return sum / thumbZoomMovements.Count;
//     }

//     void MoveLeft()
//     {
//         targetCameraPosition = Mathf.Clamp(targetCameraPosition - 0.3f, minPosition, maxPosition);
//     }

//     void MoveRight()
//     {
//         targetCameraPosition = Mathf.Clamp(targetCameraPosition + 0.3f, minPosition, maxPosition);
//     }

//     void ZoomIn()
//     {
//         targetZoom = Mathf.Clamp(targetZoom - 1f, minZoom, maxZoom);
//     }

//     void ZoomOut()
//     {
//         targetZoom = Mathf.Clamp(targetZoom + 1f, minZoom, maxZoom);
//     }

//     void SmoothCameraMovement()
//     {
//         mainCamera.transform.position = new Vector3(
//             Mathf.Lerp(mainCamera.transform.position.x, targetCameraPosition, Time.deltaTime * smoothSpeed),
//             mainCamera.transform.position.y,
//             mainCamera.transform.position.z
//         );
//     }

//     void SmoothZoom()
//     {
//         mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetZoom, Time.deltaTime * smoothSpeed);
//     }
// }


// using System.Collections.Generic;
// using UnityEngine;

// public class HandTrackedCameraControl : MonoBehaviour
// {
//     public Camera mainCamera;
//     public Transform handTrackingObject;
//     public Transform thumb, index, middle;

//     private float minPosition = -10f, maxPosition = 10f;
//     private float minZoom = 30f, maxZoom = 60f;
//     private float targetCameraPosition;
//     private float targetZoom;
//     private Vector3 previousThumbPosition = Vector3.zero;
//     private float movementThreshold = 0.01f;
//     private float zoomThreshold = 0.01f;
//     private float smoothSpeed = 2f;
//     private float threshold = 0.4f;

//     private List<float> thumbMovements = new List<float>();
//     private List<float> thumbZoomMovements = new List<float>();

//     void Start()
//     {
//     // targetCameraPosition = 0f;
//     targetZoom = mainCamera.fieldOfView;
//     }   


// void Update()
// {
//     if (IsFingersTouching())
//     {
//         Vector3 currentThumbPosition = thumb.position;
//         if (previousThumbPosition != Vector3.zero)
//         {
//             float thumbMovementX = currentThumbPosition.x - previousThumbPosition.x;
//             float thumbMovementY = currentThumbPosition.y - previousThumbPosition.y;

//             if (Mathf.Abs(thumbMovementX) > movementThreshold)
//             {
//                 StoreThumbMovement(thumbMovementX);
//                 float avgThumbMovementX = GetAverageThumbMovement();

//                 if (avgThumbMovementX < 0)
//                     MoveLeft();
//                 else if (avgThumbMovementX > 0)
//                     MoveRight();
//             }

//             if (Mathf.Abs(thumbMovementY) > zoomThreshold)
//             {
//                 StoreThumbZoomMovement(thumbMovementY);
//                 float avgThumbMovementY = GetAverageThumbZoomMovement();

//                 if (avgThumbMovementY > 0)
//                     ZoomIn();
//                 else if (avgThumbMovementY < 0)
//                     ZoomOut();
//             }
//         }

//         previousThumbPosition = currentThumbPosition; 
//     }

//     SmoothCameraMovement();
//     SmoothZoom();
//     KeepHandsInView();
// }


//     bool IsFingersTouching()
//     {
//         float distanceBetweenThumbAndIndex = Vector3.Distance(thumb.position, index.position);
//         float distanceBetweenIndexAndMiddle = Vector3.Distance(index.position, middle.position);
//         return distanceBetweenThumbAndIndex < threshold && distanceBetweenIndexAndMiddle < threshold;
//     }

//     void StoreThumbMovement(float movement)
//     {
//         thumbMovements.Add(movement);
//         if (thumbMovements.Count > 5)
//             thumbMovements.RemoveAt(0);
//     }

//     float GetAverageThumbMovement()
//     {
//         if (thumbMovements.Count == 0) return 0;
//         float sum = 0f;
//         foreach (float movement in thumbMovements)
//             sum += movement;
//         return sum / thumbMovements.Count;
//     }

//     void StoreThumbZoomMovement(float movement)
//     {
//         thumbZoomMovements.Add(movement);
//         if (thumbZoomMovements.Count > 5)
//             thumbZoomMovements.RemoveAt(0);
//     }

//     float GetAverageThumbZoomMovement()
//     {
//         if (thumbZoomMovements.Count == 0) return 0;
//         float sum = 0f;
//         foreach (float movement in thumbZoomMovements)
//             sum += movement;
//         return sum / thumbZoomMovements.Count;
//     }

//     void MoveLeft()
//     {
//         targetCameraPosition = Mathf.Clamp(targetCameraPosition - 1f, minPosition, maxPosition);
//     }

//     void MoveRight()
//     {
//         targetCameraPosition = Mathf.Clamp(targetCameraPosition + 1f, minPosition, maxPosition);
//     }

//     void ZoomIn()
//     {
//         targetZoom = Mathf.Clamp(targetZoom - 1f, minZoom, maxZoom);
//     }

//     void ZoomOut()
//     {
//         targetZoom = Mathf.Clamp(targetZoom + 1f, minZoom, maxZoom);
//     }

//     void SmoothCameraMovement()
//     {
//         mainCamera.transform.position = new Vector3(
//             Mathf.Lerp(mainCamera.transform.position.x, targetCameraPosition, Time.deltaTime * smoothSpeed),
//             mainCamera.transform.position.y,
//             mainCamera.transform.position.z
//         );
//     }

//     void SmoothZoom()
//     {
//         mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetZoom, Time.deltaTime * smoothSpeed);
//     }

//     void KeepHandsInView()
//     {
//         Vector3 cameraPosition = mainCamera.transform.position;
//         handTrackingObject.position = new Vector3(cameraPosition.x, handTrackingObject.position.y, handTrackingObject.position.z);
//     }
// }


using System.Collections.Generic;
using UnityEngine;

public class HandTrackedCameraControl : MonoBehaviour
{
    public Camera mainCamera;
    public Transform handTrackingObject;
    public Transform thumb, index, middle;

    private float minRotation = -30f, maxRotation = 30f;
    private float minZoom = 30f, maxZoom = 60f;
    private float targetCameraRotation;
    private float targetZoom;
    private Vector3 previousThumbPosition = Vector3.zero;
    private float movementThreshold = 0.01f;
    private float zoomThreshold = 0.01f;
    private float smoothSpeed = 2f;
    private float threshold = 0.4f;

    private List<float> thumbMovements = new List<float>();
    private List<float> thumbZoomMovements = new List<float>();

    void Start()
    {
        targetZoom = mainCamera.fieldOfView;
        targetCameraRotation = mainCamera.transform.eulerAngles.y;
    }

    void Update()
    {
        if (IsFingersTouching())
        {
            Vector3 currentThumbPosition = thumb.position;
            if (previousThumbPosition != Vector3.zero)
            {
                float thumbMovementX = currentThumbPosition.x - previousThumbPosition.x;
                float thumbMovementY = currentThumbPosition.y - previousThumbPosition.y;

                if (Mathf.Abs(thumbMovementX) > movementThreshold)
                {
                    StoreThumbMovement(thumbMovementX);
                    float avgThumbMovementX = GetAverageThumbMovement();

                    if (avgThumbMovementX < 0)
                        RotateLeft();
                    else if (avgThumbMovementX > 0)
                        RotateRight();
                }

                if (Mathf.Abs(thumbMovementY) > zoomThreshold)
                {
                    StoreThumbZoomMovement(thumbMovementY);
                    float avgThumbMovementY = GetAverageThumbZoomMovement();

                    if (avgThumbMovementY > 0)
                        ZoomIn();
                    else if (avgThumbMovementY < 0)
                        ZoomOut();
                }
            }

            previousThumbPosition = currentThumbPosition;
        }

        SmoothCameraRotation();
        SmoothZoom();
        KeepHandsInView();
    }

    bool IsFingersTouching()
    {
        float distanceBetweenThumbAndIndex = Vector3.Distance(thumb.position, index.position);
        float distanceBetweenIndexAndMiddle = Vector3.Distance(index.position, middle.position);
        return distanceBetweenThumbAndIndex < threshold && distanceBetweenIndexAndMiddle < threshold;
    }

    void StoreThumbMovement(float movement)
    {
        thumbMovements.Add(movement);
        if (thumbMovements.Count > 5)
            thumbMovements.RemoveAt(0);
    }

    float GetAverageThumbMovement()
    {
        if (thumbMovements.Count == 0) return 0;
        float sum = 0f;
        foreach (float movement in thumbMovements)
            sum += movement;
        return sum / thumbMovements.Count;
    }

    void StoreThumbZoomMovement(float movement)
    {
        thumbZoomMovements.Add(movement);
        if (thumbZoomMovements.Count > 5)
            thumbZoomMovements.RemoveAt(0);
    }

    float GetAverageThumbZoomMovement()
    {
        if (thumbZoomMovements.Count == 0) return 0;
        float sum = 0f;
        foreach (float movement in thumbZoomMovements)
            sum += movement;
        return sum / thumbZoomMovements.Count;
    }

    void RotateLeft()
    {
        targetCameraRotation = Mathf.Clamp(targetCameraRotation - 2f, minRotation, maxRotation);
    }

    void RotateRight()
    {
        targetCameraRotation = Mathf.Clamp(targetCameraRotation + 2f, minRotation, maxRotation);
    }

    void ZoomIn()
    {
        targetZoom = Mathf.Clamp(targetZoom - 1f, minZoom, maxZoom);
    }

    void ZoomOut()
    {
        targetZoom = Mathf.Clamp(targetZoom + 1f, minZoom, maxZoom);
    }

    void SmoothCameraRotation()
    {
        mainCamera.transform.rotation = Quaternion.Lerp(
            mainCamera.transform.rotation,
            Quaternion.Euler(mainCamera.transform.eulerAngles.x, targetCameraRotation, mainCamera.transform.eulerAngles.z),
            Time.deltaTime * smoothSpeed
        );
    }

    void SmoothZoom()
    {
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetZoom, Time.deltaTime * smoothSpeed);
    }

    void KeepHandsInView()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        handTrackingObject.position = new Vector3(cameraPosition.x, handTrackingObject.position.y, handTrackingObject.position.z);
    }
}

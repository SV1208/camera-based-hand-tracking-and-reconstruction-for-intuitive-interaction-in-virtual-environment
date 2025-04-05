# Camera-based Hand Tracking and Reconstruction for Intuitive Interaction in Virtual Environment

## Members:
- **Rohit Singh Raghuvanshi** 
- **Avijeet Parth Soni** 
- **Shivanshu Vishwakarma**

---
## Introduction
This project focuses on developing a camera-based hand tracking system to enable intuitive interactions within a virtual 3D environment. Using accessible technology, we aim to provide a cost-effective alternative to VR and AR hardware for immersive digital experiences. By leveraging computer vision and machine learning, we enable users to control and manipulate the world and articles present in Unity using natural hand gestures.

## Overview
We use OpenCV to capture real-time video from a standard webcam, and MediaPipe to detect key landmarks on the user's hand. These landmarks provide 21 points per hand, outlining the fingers and palm. The system is capable of tracking hand movements frame by frame, allowing for smooth and accurate gesture recognition.

The hand tracking data from MediaPipe is in 2D image coordinates. We apply post-processing techniques by analyzing the relative size of the hand and the spread of landmarks. We infer its position and scale from the camera. The processed 3D coordinates are transmitted to a Unity environment in real time. A virtual hand model is animated to reflect the user’s real hand movements. This integration allows users to interact with virtual objects using gestures, providing an immersive experience without needing VR controllers.

We implemented several intuitive interactions using hand gestures. Users can pick up and move objects by performing grip-like motions, rotate and zoom the Unity camera by swiping. These features simulate a touchless control system based entirely on hand movement.

As a proof of concept, we developed a mini solar system simulation within Unity. The environment includes the Sun and Earth. Users can reach out and touch the planets to reveal educational information, grab and reposition the Earth to change its orbit, and rotate the scene by moving their hand. This demo illustrates the potential of gesture-based learning tools.

---

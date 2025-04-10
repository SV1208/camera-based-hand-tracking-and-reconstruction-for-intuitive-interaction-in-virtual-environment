import cv2
import socket
import mediapipe as mp

# Initialize video capture
cap = cv2.VideoCapture(0)
cap.set(3, 1280)
cap.set(4, 720)
success, img = cap.read()
h, w, _ = img.shape

# Setup UDP socket
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 6060)

# Initialize MediaPipe Hands
mp_hands = mp.solutions.hands
mp_drawing = mp.solutions.drawing_utils
hands = mp_hands.Hands(
    static_image_mode=False,
    max_num_hands=2,
    min_detection_confidence=0.8,
    min_tracking_confidence=0.8
)

while True:
    success, img = cap.read()
    if not success:
        continue

    img_rgb = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    result = hands.process(img_rgb)
    data = []

    if result.multi_hand_landmarks:
        for hand_landmarks in result.multi_hand_landmarks:
            for lm in hand_landmarks.landmark:
                cx, cy, cz = int(lm.x * w), int(lm.y * h), int(lm.z * w)
                data.extend([cx, h - cy, cz])
            sock.sendto(str.encode(str(data)), serverAddressPort)
            mp_drawing.draw_landmarks(img, hand_landmarks, mp_hands.HAND_CONNECTIONS)

    cv2.imshow("Image", img)
    key = cv2.waitKey(1)
    if key == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()

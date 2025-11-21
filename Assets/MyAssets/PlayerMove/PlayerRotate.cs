using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float mouseSensitivity = 200f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // 좌우 회전 (몸 회전)
        transform.Rotate(Vector3.up * mouseX);
    }
}
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 1f; // Distância da câmera ao personagem
    public float sensitivityX = 100f;
    public float sensitivityY = 100f;
    public float minY = -20f; // Ângulo mínimo no eixo Y
    public float maxY = 60f; // Ângulo máximo no eixo Y

    private float rotationY = 0f;
    private float rotationX = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, 0, 0);

        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

        target.rotation = rotation;
    }
}

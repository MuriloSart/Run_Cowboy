using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 1f; // Dist�ncia da c�mera ao personagem
    public float sensitivityX = 100f;
    public float sensitivityY = 100f;
    public float minY = -20f; // �ngulo m�nimo no eixo Y
    public float maxY = 60f; // �ngulo m�ximo no eixo Y

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

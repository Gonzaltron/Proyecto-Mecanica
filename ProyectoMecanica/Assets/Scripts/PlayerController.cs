using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpForce;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float sensibilidad;
    [SerializeField] float sensitivityFactor;
    [SerializeField] Slider sensitivity;
    [SerializeField] TMP_Text senText;
    GameObject camera;
    float xRotation;
    float yRotation;
    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        speed = walkSpeed;
        camera = this.transform.GetChild(0).gameObject;
        sensitivity.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }

        if(Input.GetKey(KeyCode.W))
        {
            this.transform.position = this.transform.position + Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = this.transform.position + Vector3.forward * -walkSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = this.transform.position + Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = this.transform.position + Vector3.left * -speed * Time.deltaTime;
        }


        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        xRotation -= mouseY; // Invertir el eje Y para comportamiento est�ndar
        xRotation = Mathf.Clamp(xRotation, -89.9f, 89.9f); // Limitar la vista vertical
        yRotation -= mouseX;
        this.transform.rotation = Quaternion.Euler(0, -yRotation, 0);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotar c�mara vertical
    }


    public void ChangeSensitivity()
    {
        sensibilidad = sensitivity.value * sensitivityFactor;
        senText.text = "Sensibilidad: " + sensitivity.value.ToString("F2");
    }
}

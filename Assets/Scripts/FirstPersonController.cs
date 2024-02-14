using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 500f;
    public float mouseSensitivity = 1000f;
    public GameObject projectilePrefab;
    public GameObject projectileContainer;
    public Transform shootPoint;
    public float shootForce = 10f;

    private Rigidbody rb;
    private Camera playerCamera;
    private Vector3 movement;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = transform.right * horizontal + transform.forward * vertical;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Shooting input
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
    }

    void Shoot()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = playerCamera.ScreenPointToRay(screenCenter);

        Vector3 shootDirection = ray.direction;

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position + shootDirection, Quaternion.identity);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(shootDirection.normalized * shootForce, ForceMode.Impulse);

        projectile.transform.parent = projectileContainer.transform;
    }


}


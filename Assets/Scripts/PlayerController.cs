using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float health = 100;
    private float speed = 40.0f;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rb;
    private float rotationSpeed = 75.0f;
    Vector3 angleVelocity;
    public GameObject cube;
    [SerializeField]
    private bool godMode = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        angleVelocity = new Vector3(verticalInput * rotationSpeed, 0, horizontalInput * -rotationSpeed);

        // move the plane forward at a constant rate
        rb.position = rb.position + transform.forward * speed * Time.deltaTime;

        //Control plane rotation
        Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("EnemyRocket"))
        {
            TakeDamage();
        }
        else
        {
            Instantiate(cube, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    private void TakeDamage()
    {
        if (health <= 0 && godMode == false)
        {
            Instantiate(cube, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        health -= 20;
    }
}

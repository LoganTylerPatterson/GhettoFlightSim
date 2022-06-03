using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryToKillPlayer : MonoBehaviour
{
    Transform playerTransform;
    Rigidbody rb;
    [SerializeField]
    private float maximumSpeed = 30f;
    [SerializeField]
    private ParticleSystem explosion;
    private float timeToDie = 3;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BlowUp();
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        Vector3 deltaPosition = maximumSpeed * dir * Time.deltaTime;
        rb.MovePosition(transform.position + deltaPosition);
        transform.LookAt(playerTransform);
        if(timer >= timeToDie)
        {
            BlowUp();
            Destroy(gameObject);
        }
    }

    private void BlowUp()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        explosion.Play();
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 10);
        foreach (Collider hitCollider in hitColliders)
        {
            hitCollider.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
        }
    }
}

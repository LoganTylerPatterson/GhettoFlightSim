using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearMissileController : MonoBehaviour
{
    private float health = 100f;
    private float upwardSpeed = 10f;
    [SerializeField]
    private ParticleSystem explosionParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position + transform.up * Time.deltaTime;
        transform.position = newPosition;
    }

    public void TakeDamage()
    {
        health -= 20;
        if(health <= 1)
        {
            BlowUp();
        }
    }

    private void BlowUp()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Instantiate(explosionParticles, gameObject.transform.position, Quaternion.identity);
        explosionParticles.Play();
        Destroy(gameObject, explosionParticles.main.duration);
    }
}

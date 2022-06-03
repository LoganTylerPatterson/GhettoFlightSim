using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosion;

    private int timeToDie = 5;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToDie)
        {
            BlowUp();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {    
       BlowUp();     
    }

    private void BlowUp()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.Euler(0,0,0));
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        explosion.Play();
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 30);
        foreach(Collider hitCollider in hitColliders)
        {
            hitCollider.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
        }
        Destroy(gameObject, explosion.main.duration);
    }
}

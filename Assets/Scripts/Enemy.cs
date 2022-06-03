using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    GameObject player;
    [SerializeField]
    private ParticleSystem explosionParticles;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void TakeDamage()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Instantiate(explosionParticles, gameObject.transform.position, Quaternion.identity);
        explosionParticles.Play();
        Destroy(gameObject, explosionParticles.main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}

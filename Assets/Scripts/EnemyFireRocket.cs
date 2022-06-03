using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireRocket : MonoBehaviour
{

    [SerializeField]
    private GameObject rocket;
    private GameObject player;
    private float distanceToHit = 200;
    private float distance;
    private Transform rocketStart;
    float timer;
    int waitingTime = 4;
  
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = GameObject.Find("Player");
        rocketStart = transform.Find("EnemyRocketStart");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if(distance < distanceToHit)
        {
            if(timer >= waitingTime)
            {
                Instantiate(rocket, rocketStart.transform.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
}

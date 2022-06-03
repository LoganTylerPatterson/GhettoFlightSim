using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject rocketPrefab;
    [SerializeField]
    private GameObject rocketRight;
    [SerializeField]
    private GameObject rocketLeft;
   
    //For missile shananigans
    private bool rocketToFire;
    Vector3 betterRotation;
    Vector3 force;



    // Start is called before the first frame update
    void Start()
    {

        betterRotation = rocketLeft.transform.eulerAngles - new Vector3(0, 135, 0);
        rocketToFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        force = transform.forward * 100;
        ShootRocket();
    }

    void ShootRocket()
    {
        Vector3 positionToFireLeft = rocketLeft.transform.position - (10 * rocketLeft.transform.up);
        Vector3 positionToFireRight = rocketRight.transform.position - (10 * rocketRight.transform.up);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rocketToFire == false)
            {
                GameObject instance = Instantiate(rocketPrefab, positionToFireLeft, Quaternion.Euler(betterRotation));
                instance.transform.forward = gameObject.transform.right;
                instance.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                rocketToFire = true;
            }
            else
            {
                GameObject instance = Instantiate(rocketPrefab, positionToFireRight, Quaternion.Euler(betterRotation));
                instance.transform.forward = gameObject.transform.right;
                instance.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                rocketToFire = false;
            }
        }
    }
}

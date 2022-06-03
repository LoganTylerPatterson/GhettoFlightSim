using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    [SerializeField]
    private GameObject target;
    [SerializeField]
    Vector3 offset;
    private Space offsetPositionSpace;
    private GameObject player;
    private void Start()
    {
        offset = new Vector3(0, 0, -40);
        target = GameObject.Find("Empty");
        //player = GameObject.Find("Player");

    }
    

    private void LateUpdate()
    {
        Refresh();
    }

    void Refresh()
    {
        
        transform.position = target.transform.TransformPoint(offset);
        transform.LookAt(target.transform);
    }
}
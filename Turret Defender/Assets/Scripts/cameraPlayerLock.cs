using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayerLock : MonoBehaviour
{

    //Variables
    public GameObject player;
    public float smooth = .3f;
    public float height = 3f;

    private Vector3 velocity = Vector3.zero;

    //Methods
    private void Update()
    {
        /*
       Vector3 pos = new Vector3();
       pos.x = player.transform.position.x;
       pos.z = player.transform.position.z - height;
       pos.y = player.transform.position.y + height;

       transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
        */
    }
}

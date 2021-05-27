using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Variables
    public float bulletSpeed = 10f;
    public float dist;
    public float maxRange = 5f;

    private GameObject triggeringEnemy;
    public float damage = 20f;
    public bool deflecting = false;

    private GameObject player;
    private GameObject shield;

    //Methods
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        dist += 1 * Time.deltaTime;

        if (dist >= maxRange) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
            //print("hit");
            Destroy(this.gameObject);
        } 
        
        if(other.tag == "Player")
        {
            player = other.gameObject;
            player.GetComponent<Player>().health -= 20;
            Destroy(this.gameObject);
        }

        if (other.tag == "Shield")
        {
            shield = other.gameObject;

            if (deflecting)
                Instantiate(this.transform, shield.transform.position, shield.transform.rotation);

            Destroy(this.gameObject);
        }
    }

}

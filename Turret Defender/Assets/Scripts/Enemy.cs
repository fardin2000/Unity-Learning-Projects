using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    public float health = 100f;
    public float pointsValue = 50f;

    public GameObject player;

    public float waitTime = 2f;
    private float currentWait = 0f;
    private bool shot = true;
    public GameObject bullet;
    public Transform firePoint;
    private Transform bulletSpawned;

    private Transform Gun;

    //Methods
    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        Gun = this.transform.GetChild(0);
        firePoint = Gun.transform.GetChild(2);
    }

    private void Update() 
    {


        //Check DeadOrAlive
        if (health <= 0)
        {
            Die();
        }
        //lookatPlayer
        this.transform.LookAt(player.transform);

        //ShootAfterWait
        if (currentWait == 0)
            Shoot();

        if (shot && currentWait < waitTime)
            currentWait += 1 * Time.deltaTime;

        if (currentWait >= waitTime)
            currentWait = 0f;
    }

    public void Die() {
        //print("Enemy " + this.gameObject.name + " has died!");
        Destroy(this.gameObject);
        player.GetComponent<Player>().points += pointsValue;
    }

    public void Shoot()
    {
        shot = true;
        //print("shot");
        bulletSpawned = Instantiate(bullet.transform, firePoint.transform.position, firePoint.transform.rotation);
    }
}

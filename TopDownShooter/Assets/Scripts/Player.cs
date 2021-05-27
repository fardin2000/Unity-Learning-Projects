using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float movementSpeed;
    //public Camera camera;

    public GameObject player;

    public GameObject firePoint;
    public float waitTime = 1f;
    public GameObject bullet;

    public static float maxHealth = 100f;
    public float health;
    public float points;

    //Methods
    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        //Point To Mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        //Movement
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        //Player Death
        if (health <= 0)
            Die();

    }

    public void Shoot()
    {
        Instantiate(bullet.transform, firePoint.transform.position, firePoint.transform.rotation);
    }

    public void Die()
    {
        print("dead");
    }

}

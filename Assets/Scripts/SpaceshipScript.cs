using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField]GameObject Bullet; 
    [SerializeField] float force = 10f;
    Rigidbody2D rb;
    float horizontal;
    bool CanShoot = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InstantiateBullet()
    {
        GameObject NewBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        CanShoot = false;
        
        StartCoroutine(EnableShoot()); //Se tiene que llamar a la corutina con un start
    }

    IEnumerator EnableShoot()
    {
        Debug.Log("voy a esperar 1s");
        yield return new WaitForSeconds(1f);
        Debug.Log("ya puedes disparar");
        CanShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && CanShoot)
        {
            InstantiateBullet();
        }
    }

    private void FixedUpdate()
    {
        // Movimiento de la nave horizontal
        horizontal = Input.GetAxis("Horizontal");
        rb.AddForce (Vector3.right * horizontal * force);

        //Límite de la pantalla
        float pos = Mathf.Clamp(transform.position.x, -7f, 7f);
        transform.position = new Vector3 (pos, transform.position.y, transform.position.z);

        if (transform.position.x <= -7f || transform.position.x >= 7f) 
        { 
            rb.linearVelocityX = 0f; 
        }
    }
 
}

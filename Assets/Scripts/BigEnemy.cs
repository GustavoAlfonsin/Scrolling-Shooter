using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BigEnemy : Controller_Enemy
{
    public bool goingUp;
    public bool forward;
    private Rigidbody rb;
    private static int vida = 8;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = true;
    }

    public override void Update()
    {
        if (vida <= 0)
        {
            Destroy(this.gameObject);
            Controller_Hud.points++;
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
        base.Update();
    }
    void FixedUpdate()
    {
        if (rb.transform.position.x > 28)
        {
            rb.AddForce(new Vector3(-1, 0, 0) * enemySpeed);
        }
        else
        {
            enemySpeed = 1f;
            if (goingUp)
            {
                rb.AddForce(new Vector3(0, 1, 0) * enemySpeed, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(new Vector3(0, -1, 0) * enemySpeed, ForceMode.Impulse);
            }
        }
    }

    internal override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            goingUp = true;
        }
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            goingUp = false;
        }
        //if (collision.gameObject.CompareTag("Projectile"))
        //{
        //    vida -= 2;
        //    Destroy(collision.gameObject); //destruye el proyectil del jugador
        //    UnityEngine.Debug.Log($"{vida}");
        //}
        //if (collision.gameObject.CompareTag("Laser"))
        //{
        //    vida -= 4;
        //}
        base.OnCollisionEnter(collision);
    }
    
}

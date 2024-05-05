using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Controller_Enemy
{
    public bool goingUp;
    public bool forward;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = true;
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
            //rb.velocity = Vector3.zero;
        }
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            goingUp = false;
            //rb.velocity = Vector3.zero;
        }
        base.OnCollisionEnter(collision);
    }

    
}

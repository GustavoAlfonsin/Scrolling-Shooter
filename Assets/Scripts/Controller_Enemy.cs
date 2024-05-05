using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public float enemySpeed;

    public float xLimit;

    private float shootingCooldown;

    public GameObject enemyProjectile;

    public GameObject powerUp;

    void Start()
    {
        shootingCooldown = UnityEngine.Random.Range(1, 10);
    }

    public virtual void Update()
    {
        shootingCooldown -= Time.deltaTime;
        CheckLimits();
        ShootPlayer();
    }

    void ShootPlayer()
    {
        if (Controller_Player._Player != null) // Si el jugador no fue eliminado
        {
            if (shootingCooldown <= 0) // Y el "sootingCooldown es menor igual a 0
            {
                Instantiate(enemyProjectile, transform.position, Quaternion.identity); // Instancia un proyectil en la posición del enemigo
                shootingCooldown = UnityEngine.Random.Range(1, 10); // Reestablece el valor del tiempo
            }
        }
    }


    private void CheckLimits() // Elimina el enemigo una vez pasado el limite en X
    {
        if (this.transform.position.x < xLimit)
        {
            Destroy(this.gameObject);
        }
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GeneratePowerUp(); // Genera el powerUp
            Destroy(collision.gameObject); //destruye el proyectil del jugador
            Destroy(this.gameObject); //destruye el objeto enemigo
            Controller_Hud.points++; // suma puntaje
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            GeneratePowerUp();
            Destroy(this.gameObject);
            Controller_Hud.points++;
        }
    }

    private void GeneratePowerUp()
    {
        int rnd = UnityEngine.Random.Range(0, 3); //es para definir la posibilidad de encontrar un powerUP
        if (rnd == 2)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
    }
}

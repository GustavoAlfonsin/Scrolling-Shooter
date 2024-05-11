using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Controller_Player._Player.gameObject.SetActive(true);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            // Quita todos los powerUps adquiridos por el jugador y restablece la velocidad incial
            Controller_Player._Player.destroyAllEnemy = false;
            Controller_Hud.gameOver = false;
            Controller_Player._Player.laserOn = false;
            Controller_Player._Player.speed = Controller_Player._Player.velocidadInicial;
            Controller_Player._Player.forceField = false;
            Controller_Player._Player.missiles = false;
            Controller_Player._Player.doubleShoot = false;
            
        }
    }
}

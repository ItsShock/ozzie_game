using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.y < -4.0f)
            {
                GameOver();
            }
        }
    }
        public void GameOver()
        {
            SceneManager.LoadScene(2);
        }

        public void WygrajPoziom()
        {
            SceneManager.LoadScene(0);
        }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadazanieKamery : MonoBehaviour
{
    GameObject player;
    Vector3 pozycjaGracza;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(player != null)
        {
            pozycjaGracza = player.transform.position;
        }
    }

    private void LateUpdate()
    {
        transform.position = pozycjaGracza + new Vector3(5.3f, 2.26f, -10);
    }
}

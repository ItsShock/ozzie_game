using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodazanieKamery : MonoBehaviour
{
    GameObject player;
    Vector3 pozycjaGracza;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            pozycjaGracza = player.transform.position;
        }
    }
    private void LateUpdate()
    {
        //transform.position = pozycjaGracza + new Vector3(5.3f, 1.26f, -10f) ;
        transform.position = new Vector3(pozycjaGracza.x + 5.3f, transform.position.y, transform.position.z);
    }
}

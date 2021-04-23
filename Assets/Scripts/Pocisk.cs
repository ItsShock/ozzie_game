using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocisk : MonoBehaviour
{
    float silaPocisku;
    public void InicjalizujPocisk(float sila)
    {
        silaPocisku = sila;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Stats>() != null)
        {
            collision.gameObject.GetComponent<Stats>().OdbierzObrazenia(silaPocisku);
        }

        Destroy(gameObject);
    }
}

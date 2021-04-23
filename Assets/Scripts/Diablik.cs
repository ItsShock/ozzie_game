using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diablik : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    Vector3 nastepnaPozycja;
    float predkosc = 4f;
    void Start()
    {
        nastepnaPozycja = pos1.position;
    }

    
    void Update()
    {
        float step = predkosc * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nastepnaPozycja, step);
        if(transform.position.x == nastepnaPozycja.x)
        {
            if(nastepnaPozycja == pos1.position)
            {
                nastepnaPozycja = pos2.position;
            }
            else
            {
                nastepnaPozycja = pos1.position;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<Stats>().OdbierzObrazenia(GetComponent<Stats>().PobierzWartoscAtaku());
        }
    }
}

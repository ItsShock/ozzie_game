using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciwnik : MonoBehaviour
{
    [SerializeField] GameObject pociskPrefab;
    float silaAtaku = 1f;
    Stats stats;
    void Start()
    {
        stats = gameObject.GetComponent<Stats>();
        InvokeRepeating("WystrzelPocisk", 0.5f, 1f);
    }

    void WystrzelPocisk()
    {
        silaAtaku = stats.PobierzWartoscAtaku();
        GameObject pocisk = Instantiate(pociskPrefab, gameObject.transform);
        pocisk.transform.SetParent(null);   
        pocisk.transform.position = gameObject.transform.position;
        pocisk.GetComponent<Pocisk>().InicjalizujPocisk(silaAtaku);
        pocisk.GetComponent<Rigidbody2D>().AddForce(new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x > 0.1 ? 500f : -500f, 0f), ForceMode2D.Force);
        Destroy(pocisk, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<Stats>().OdbierzObrazenia(GetComponent<Stats>().PobierzWartoscAtaku());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzelanie : MonoBehaviour
{
    [SerializeField] GameObject pociskPrefab;
    float silaAtaku = 1f;
    GameObject pocisk;
    float predkoscZwiekszaniaAtaku = 1.5f;
    float silaWystrzelonegoPocisku = 1f;
    float masaPocisku = 1f;
    Stats stats;
    void Start()
    {
        stats = gameObject.GetComponent<Stats>();
    }

    void Update()
    {
        WystrzelPociskMocy();
    }

    void WystrzelPociskMocy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            silaAtaku = stats.PobierzWartoscAtaku();
            pocisk = Instantiate(pociskPrefab, gameObject.transform);
            pocisk.transform.SetParent(null);
            
        }
        if (Input.GetMouseButton(0))
        {
            if(stats.PobierzWartoscMagii() > 0)
            {
                stats.ZwiekszSileAtaku();
                pocisk.transform.localScale += new Vector3(1, 1, 1) * predkoscZwiekszaniaAtaku * Time.deltaTime;
                pocisk.transform.position = gameObject.transform.position;
                silaWystrzelonegoPocisku += 3 * predkoscZwiekszaniaAtaku * Time.deltaTime;
                masaPocisku += predkoscZwiekszaniaAtaku * Time.deltaTime;

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(pocisk != null)
            {
                silaAtaku = stats.PobierzWartoscAtaku();
                pocisk.GetComponent<Pocisk>().InicjalizujPocisk(silaAtaku);
                pocisk.GetComponent<Rigidbody2D>().AddForce(new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x >= -0.1 ? 500f * silaWystrzelonegoPocisku : -500f * silaWystrzelonegoPocisku, 0f), ForceMode2D.Force);
                pocisk.GetComponent<Rigidbody2D>().mass = masaPocisku;
                Destroy(pocisk, 1.5f);
                stats.ResetujSileAtaku();
            }
        }

    }
}

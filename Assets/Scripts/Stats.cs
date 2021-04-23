using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float atak_bazowy = 3f;
    float atak;
    public float bazoweHP = 5f;
    float HP;
    public float obrona_bazowa = 1f;
    float obrona;
    public float magia_bazowa = 10f;
    float magia;

    float wspolczynnikZwiekszeniaObrony = 2f;
    float wpolczynnikZwiekszeniaAtaku = 2f;
    void Start()
    {
        HP = bazoweHP;
        atak = atak_bazowy;
        obrona = obrona_bazowa;
        magia = magia_bazowa;
    }

    public float PobierzMagieBazowa()
    {
        return magia_bazowa;
    }

    public float PobierzBazoweHP()
    {
        return bazoweHP;
    }
    public void OdbierzObrazenia(float obrazenia)
    {
        float ostateczneObrazenia = obrazenia - obrona;
        if(ostateczneObrazenia > 0)
        {
            if(HP > ostateczneObrazenia)
            {
                HP -= ostateczneObrazenia;
            }
            else
            {
                Gin();
            }
        }
    }

    public float PobierzWartoscAtaku()
    {
        return atak;
    }

    public float PobierzWartoscMagii()
    {
        return magia;
    }

    public float PobierzWartoscHP()
    {
        return HP;
    }

    public float PobierzWartoscObrony()
    {
        return obrona;
    }

    public void UsunTarcze()
    {
        obrona = obrona_bazowa;
    }
    public void ResetujSileAtaku()
    {
        atak = atak_bazowy;
    }

    public void PobierzMagie(float wspolczynikZmiany)
    {
       magia -= wspolczynikZmiany * Time.deltaTime;

    }

    public void OdnawiajMagie()
    {
        if(magia < magia_bazowa)
        {
            magia += 0.5f * Time.deltaTime;
        }
    }

    public void ZwiekszSileAtaku()
    {
        if (magia > 0)
        {
            atak += wpolczynnikZwiekszeniaAtaku * Time.deltaTime;
            PobierzMagie(wpolczynnikZwiekszeniaAtaku);
        }
    }

    public void ZwiekszObrone()
    {
        if(magia > 0)
        {
            obrona += wspolczynnikZwiekszeniaObrony * 0.45f * Time.deltaTime;
            PobierzMagie(wspolczynnikZwiekszeniaObrony);
        }
    }
    void Gin()
    {
        if (gameObject.transform.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

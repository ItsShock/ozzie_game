using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarcza : MonoBehaviour
{
    Stats stats;
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            stats.UsunTarcze();
        }
        if (Input.GetMouseButton(1))
        {
            stats.ZwiekszObrone();
        }
        if (Input.GetMouseButtonUp(1))
        {
            StartCoroutine( WylaczTarcze());
        }
    }

    IEnumerator WylaczTarcze()
    {
        yield return new WaitForSeconds(10f);
        stats.UsunTarcze();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject gmanager;
    [SerializeField] Slider sliderHP;
    [SerializeField] Slider sliderMagia;
    [SerializeField] Slider sliderAtak;
    [SerializeField] Slider sliderObrona;

    Stats stats;
    
    void Start()
    {
        stats = GetComponent<Stats>();
        sliderHP.maxValue = stats.PobierzBazoweHP();
        sliderMagia.maxValue = stats.PobierzMagieBazowa();
    }

    void Update()
    {
        sliderHP.value = stats.PobierzWartoscHP();
        sliderMagia.value = stats.PobierzWartoscMagii();
        sliderAtak.value = stats.PobierzWartoscAtaku();
        sliderObrona.value = stats.PobierzWartoscObrony();
        stats.OdnawiajMagie();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            gmanager.GetComponent<GameManager>().WygrajPoziom();
        }
    }
}

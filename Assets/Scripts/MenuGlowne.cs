using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGlowne : MonoBehaviour
{
    public void ZacznijGre()
    {
        SceneManager.LoadScene(1);
    }

    public void OpuscGre()
    {
        Application.Quit();
    }
}

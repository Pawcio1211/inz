using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Badania()
    {
        SceneManager.LoadScene("Badania");
    }

    public void Trening()
    {
        SceneManager.LoadScene("Trening");
    }
}

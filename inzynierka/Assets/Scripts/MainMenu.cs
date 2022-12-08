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

    public void Ustawienia_menu()
    {
        SceneManager.LoadScene("Ustawienia_Menu");
    }

    public void Cofnij_menu()
    {
        SceneManager.LoadScene("Menu3D");
    }
}

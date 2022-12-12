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

    public void Ustawienia_trening()
    {
        SceneManager.LoadScene("Ustawienia_Menu");
    }

    public void Cofnij_menu()
    {
        SceneManager.LoadScene("Menu3D");
    }

    public void OsX()
    {
        SceneManager.LoadScene("TreningX");
    }

    public void OsY()
    {
        SceneManager.LoadScene("TreningY");
    }
}

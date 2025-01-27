using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void TerminarJuego()
    {
        Application.Quit();

    }
    public void VolverAMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void MenuOpciones()
    {
        
    }
}

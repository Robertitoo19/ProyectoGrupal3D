using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private GameObject chest;

    [SerializeField] private TMP_Text feedBackText;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePanel(); 
        }
    }
    public void SubmitPassword()
    {
        string input = passwordInput.text; // Obtener la contraseña introducida

        //Validar la contraseña con el PuzzleManager
        if (PuzzleManager.instance.ValidatePassword(input))
        {
            chest.GetComponent<Chest>().Open();
            feedBackText.text = "Correct The chest is opening...";
            ClosePanel();
        }
        else
        {
            Debug.Log("fallo contraseña");
            feedBackText.text = "Incorrect password.";
        }
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

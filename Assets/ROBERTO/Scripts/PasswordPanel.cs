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
    public void SubmitPassword()
    {
        string input = passwordInput.text; // Obtener la contraseña introducida

        //Validar la contraseña con el PuzzleManager
        if (PuzzleManager.instance.ValidatePassword(input))
        {
            chest.GetComponent<Chest>().Interact();
            feedBackText.text = "Correcto! El cofre se está abriendo...";
        }
        else
        {
            feedBackText.text = "Contraseña incorrecta.";
        }
    }
}

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
        string input = passwordInput.text; // Obtener la contrase�a introducida

        //Validar la contrase�a con el PuzzleManager
        if (PuzzleManager.instance.ValidatePassword(input))
        {
            chest.GetComponent<Chest>().Interact();
            feedBackText.text = "Correcto! El cofre se est� abriendo...";
        }
        else
        {
            feedBackText.text = "Contrase�a incorrecta.";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    [SerializeField] private int[] correctPassword;
   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool ValidatePassword(string inputPassword)
    {
        // Verificar que la longitud del input sea correcta
        if (inputPassword.Length != correctPassword.Length)
        {
            return false;
        }

        // Validar que los números coincidan con la contraseña correcta
        for (int i = 0; i < correctPassword.Length; i++)
        {
            if (inputPassword[i] - '0' != correctPassword[i]) // Convertir carácter a número
            {
                return false;
            }
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{
    //[SerializeField]
    //private GameManagerSO gM;


    //[SerializeField]
    //private GameObject mainMenu;

    //[SerializeField]
    //private TMP_Text textoMonedas;
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        mainMenu.SetActive(!mainMenu.activeSelf);
    //    }
    //}

    //public void OnSaveButtonClicked()
    //{
        
    //    SaveSystem.Save(gM);
    //}

    //public void OnLoadButtonClicked()
    //{
    //    StartCoroutine(LoadSceneAndData());

    //}
    //private IEnumerator LoadSceneAndData()
    //{
    //    PersistentData dataToLoad = SaveSystem.Load(); //Primero cargo los datos

    //    gM.Items = dataToLoad.Items; //Y tengo en cuenta aquellos antes de cargar el nivel.

    //    AsyncOperation operation = SceneManager.LoadSceneAsync(0);
    //    yield return new WaitUntil(() => operation.isDone);

    //    foreach(ItemSO item in dataToLoad.PersistentItems) 
    //    {
    //        gM.NewItem(item);

    //    }
    //    textoMonedas.text = "Coins: " + dataToLoad.Monedas;

    //    gM.currentPlayer.transform.position = new Vector3(dataToLoad.LastPositionX, dataToLoad.LastPositionY);

    //}
}

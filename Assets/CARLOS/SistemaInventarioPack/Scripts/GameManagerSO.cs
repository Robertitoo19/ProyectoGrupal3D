using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
[CreateAssetMenu(menuName = "MiGameManager")]
public class GameManagerSO : ScriptableObject
{
    [NonSerialized]
    private Dictionary<int, bool> items = new Dictionary<int, bool>();

    [NonSerialized]
    private int monedas;

    [NonSerialized]
    private Vector3 initPlayerPosition = new Vector3(-4.5f, -3.5f, 0);

    [NonSerialized]
    private Vector3 initPlayerRotation = new Vector3(0, 1, 0);

    [NonSerialized]
    public List<ItemSO> persistentItems = new List<ItemSO>();

    public event Action<ItemSO> OnNewItem;

    public Vector3 InitPlayerPosition { get => initPlayerPosition; set => initPlayerPosition = value; }
    public Vector3 InitPlayerRotation { get => initPlayerRotation;}
    public int Monedas { get => monedas; set => monedas = value; }
    public Dictionary<int, bool> Items { get => items; set => items = value; }

    [NonSerialized]
    public Player currentPlayer;

    public void LoadNewScene(Vector3 newPosition, Vector2 newRotation, int newSceneIndex)
    {
        //Guardado de datos.
        initPlayerPosition = newPosition;
        initPlayerRotation = newRotation;   

        SceneManager.LoadScene(newSceneIndex);
    }

    public void NewItem(ItemSO itemData)
    {
        persistentItems.Add(itemData);
        OnNewItem?.Invoke(itemData);
    }
}

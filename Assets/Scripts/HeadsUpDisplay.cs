using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadsUpDisplay : MonoBehaviour
{
    private List<GameObject> hearts;
    [SerializeField] private GameObject healthContainer;
    [SerializeField] private Text heldItemDisplay;
    [SerializeField] private GameObject heartPrefab;

    private void Start()
    {
        int healthValue = 3;

        for(int i = 0; i < healthValue; i++)
        {
            Instantiate(heartPrefab, healthContainer.transform);
        }
    }

    public void UpdateHeldItem(string itemName)
    {
        heldItemDisplay.text = "Held Item: " + itemName;
    }

    public void TakeDamage()
    {
        
    }
}

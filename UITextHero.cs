using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode]

public class UITextHero : MonoBehaviour
{
    private PlayerInventory playerInventory;
    public int playerEnergy;
    // Start is called before the first frame update
    void Awake()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        playerEnergy = playerInventory.collectedEnergy;
        GetComponent<TextMeshProUGUI>().text=playerEnergy.ToString();
        
    }
}

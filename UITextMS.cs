using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode]

public class UITextMS : MonoBehaviour
{
    private MotherShip motherShip;
    public int msEnergy;
    public int energyNeeded;
    // Start is called before the first frame update
    void Awake()
    {
        motherShip = GameObject.Find ("MotherShip").GetComponent<MotherShip>();
    }

    // Update is called once per frame
    void Update()
    {
        msEnergy = motherShip.collectedEnergy;
        energyNeeded = motherShip.neededEnergy;

        GetComponent<TextMeshProUGUI>().text = msEnergy + " / " + energyNeeded;
    }
}

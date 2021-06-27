using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameControler : MonoBehaviour
{
    public Text CrystalCounterText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCrystalCounterText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCrystalCounterText()
    {
        var Crystals = FindObjectsOfType<CrystalScript>();


        var CrystalCount = Crystals.Length;

        var CrystalInactive = Crystals.Count(Crystal => !Crystal.Active);

        var text = CrystalInactive + "/" + CrystalCount;
        CrystalCounterText.text = text;
    }
}

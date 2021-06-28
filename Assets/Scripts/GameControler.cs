using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameControler : MonoBehaviour
{
    public Text CrystalCounterText;
    public Text CountDownText;
    public Text EndGameText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCrystalCounterText();
        EndGameText.enabled = false;
        StartCoroutine(CountDownCoroutine());
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountDownCoroutine()
    {
        CountDownText.enabled = true;
        FindObjectOfType<Sphere>().CanMove = false;

        for (int i = 5; i > 0; i--)
        {
            CountDownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        CountDownText.text = "Start!";
        FindObjectOfType<Sphere>().CanMove = true;
        yield return new WaitForSeconds(1f);

        CountDownText.enabled = false;
    }

    public void UpdateCrystalCounterText()
    {
        var Crystals = FindObjectsOfType<CrystalScript>();


        var CrystalCount = Crystals.Length;

        var CrystalInactive = Crystals.Count(Crystal => !Crystal.Active);

        var text = CrystalInactive + "/" + CrystalCount;
        CrystalCounterText.text = text;
    }
    public void CheckIfEndOfGame()
    {
        var EndOfGame = FindObjectsOfType<CrystalScript>().All(Crystal => !Crystal.Active);
        if (!EndOfGame)
            return;
        EndGame(true);
    }

    public void EndGame(bool win)
    {
        EndGameText.enabled = true;
        EndGameText.text = win ? "WIN" : "LOOSE";
    }
}

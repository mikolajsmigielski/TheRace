using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public bool Active = true;
    

    //rotating crystal
    void Update()
    {
        transform.rotation = Quaternion.Euler(45f, Time.timeSinceLevelLoad * 60f, 45f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Active)
            return;
        if (other.name != "Sphere")
            return;
        GetComponent<AudioSource>().Play();

        GetComponent<Renderer>().enabled = false;

        Active = false;

        FindObjectOfType<GameControler>().UpdateCrystalCounterText();
    }
}

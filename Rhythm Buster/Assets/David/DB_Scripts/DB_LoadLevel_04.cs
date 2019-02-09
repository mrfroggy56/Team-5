using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_LoadLevel_04 : MonoBehaviour
{
    int score = 10000;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level4", 1);        // Unlocks Level 2
        PlayerPrefs.SetInt("Level3_score", score);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        // wait 2 seconds
        yield return new WaitForSeconds(2f);
        // Go bAck to menu select
        Application.LoadLevel(0);
    }
}

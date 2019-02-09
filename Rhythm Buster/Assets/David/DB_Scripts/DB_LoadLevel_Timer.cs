using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_LoadLevel_Timer : MonoBehaviour
{
    int score = 10000;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level2", 1);        // Unlocks Level 2
        PlayerPrefs.SetInt("Level1_score", score);
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

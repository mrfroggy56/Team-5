using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_LoadLevel_03 : MonoBehaviour
{
    int score = 10000;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level3", 1);        // Unlocks Level 2
        PlayerPrefs.SetInt("Level2_score", score);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        // wait 2 seconds
        yield return new WaitForSeconds(2f);
        // Go bAck to menu select
        Application.LoadLevel(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_LoadLevel_02 : MonoBehaviour
{
    public float countDownTimer;
    public float TimerValue = 8f;
    // Start is called before the first frame update
    void Start()
    {
        // CountdownTimer is always gonna equal whatever the Timer value 
        countDownTimer = TimerValue;
    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Music_Notes") == null)
        {
            // Decrease float value to start the timer
            countDownTimer -= Time.deltaTime;
            // Is the timer equal to 0 or more
            if(countDownTimer <= 0)
            {
                // Call the relevant code to unlock the level and change back to the Level Select scene
                PlayerPrefs.SetInt("Level2", 1);        // Unlocks Level 2
                PlayerPrefs.SetInt("Level1_score", DB_GM.Score);
                StartCoroutine(Timer());
            }
        }
        else if(GameObject.FindGameObjectWithTag("Music_Notes"))
        {
            countDownTimer = TimerValue;
        }
            
        
    }

    IEnumerator Timer()
    {
        // wait 2 seconds
        yield return new WaitForSeconds(2f);
        DB_GM.Score = 0;
        // Go bAck to menu select
        Application.LoadLevel(1);
    }
}

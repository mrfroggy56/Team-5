using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_LoadLevel_03 : MonoBehaviour
{
    public float countDownTimer;
    public float Timervalue = 8f;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = Timervalue;
    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Music_Notes") == null)
        {
            countDownTimer -= Time.deltaTime;

            if(countDownTimer <=0)
            {
                PlayerPrefs.SetInt("Level3", 1);        // Unlocks Level 2
                PlayerPrefs.SetInt("Level2_score", DB_GM.Score);
                StartCoroutine(Timer());
            }
        }
        else if(GameObject.FindGameObjectWithTag("Music_Notes"))
        {
            countDownTimer = Timervalue;
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

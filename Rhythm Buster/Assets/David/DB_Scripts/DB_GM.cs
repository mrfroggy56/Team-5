using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DB_GM : MonoBehaviour
{
    // These booleans are to find out if music notes are in the trigger area where they can be played and destroyed
    public static bool canPlayGreenDrums;
    public static bool canPlayYellowDrum;
    public static bool canPlayOrangeDrum;
    public static bool canPlayPurpleHighkick;
    public static bool canPlayBlueTamberine;
    // The score value we add in a script where music notes die
    public static int Score;

    // Score Text Reference
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        // Finds the Text Component that is required to show the score
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Making sure the Text element knows it needs to write Score: and add when Score value increases/decreases
        scoreText.text = "Score:" + Score;
    }
}

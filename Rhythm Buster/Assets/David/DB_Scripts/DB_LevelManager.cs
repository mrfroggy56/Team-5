using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DB_LevelManager : MonoBehaviour
{
    // Use to view the class in the inspector
    [System.Serializable]
    public class Level
    {
        public string levelText;
        // int to allow and see what levels have been unlocked
        // if the value is 0 its a locked level
        public int unLocked;
        // Boolean that when true lets locked levels be interacted with
        public bool IsInteractable;
    }
    public GameObject levelButton;
    public Transform Spacer;
    // List that holds the value of every single level in the game
    public List<Level> LevelList;

    // Start is called before the first frame update
    void Start()
    {
        // Functions Called On Start
        //DeleteAll();      // Use this function when you dont want playerprefs to store the int values
        FillList();
    }

    void FillList()
    {
        // For each Variable classafied as level in the List LevelList
        foreach(var level in LevelList)
        {
            // foreach variablein level list we spawn our button as a GameObject type
            GameObject newButton = Instantiate(levelButton) as GameObject;
            // Making a reference for the level button script. And finding the script
            DB_LevelButton button = newButton.GetComponent<DB_LevelButton>();
            // Setting information Setting the DB_LevelButton Text variable to the text variable in Level class
            button.LevelText.text = level.levelText;
            // if the player preference value int is equal to the leve; text value which is 1
            // if the Playerprefs value is 0 level locked
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
            {
                level.unLocked = 1;     // Level is unlocked
                level.IsInteractable = true;    // Button can be interacted with when the boolean is true
                
            }
            // Set buttons locked status to the levels locked status
            button.unlocked = level.unLocked;
            // Find the buttton componenet and assign its interactable value to the level boolean. 
            // if boolean is true then when can click and interact
            // if boolean false then we can do anything with the Button GameObjects
            button.GetComponent<Button>().interactable = level.IsInteractable;
            // Allowing the button on click to figure out what level to load using the LoadLevel Function 
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel("Level" + button.LevelText.text)); 
            // Turn on visual level complection indecators if past a value which is held by the player prefs and is an int of score
            if(PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > 25)
            {
                button.MusicNote1.SetActive(true);
            }

            // These are the set scores that players need to reach to unlock the visual GameObjects that show them how well they did
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 50)
            {
                button.MusicNote2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 100)
            {
                button.MusicNote3.SetActive(true);
            }

            // Every newButton GameObject spawned now is spawned on their parent which is the spacer Panel.
            newButton.transform.SetParent(Spacer);
        }
        // Call SaveAll Function
        SaveAll();
    }

    void SaveAll()
    {
        // if level one already excists 
        if(PlayerPrefs.HasKey("Level1"))
        {
            // return the value
            return;
        }
       else
        {
            // Fill an array with gameObjects that are tagged LevelButton
            GameObject[] allbuttons = GameObject.FindGameObjectsWithTag("LevelButton");
            // Using a loop to allow the array to fill up from buttons
            foreach (GameObject buttons in allbuttons)
            {
                // Requaring all the variables from the button script
                DB_LevelButton button = buttons.GetComponent<DB_LevelButton>();
                // Setting what level we are currently on and storing what levels have been unlocked
                PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
            }
        }
    }

    void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    void LoadLevel(string buildIndex_Value)
    {
        Application.LoadLevel(buildIndex_Value);
    }
}

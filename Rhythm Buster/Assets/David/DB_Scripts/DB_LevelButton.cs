using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DB_LevelButton : MonoBehaviour
{
    public Text LevelText;
    // is the level unlocked? 
    public int unlocked;
    // These GameObjects are the visual GameObjects that show how much completion is done in a level
    public GameObject MusicNote1;
    public GameObject MusicNote2;
    public GameObject MusicNote3;
}

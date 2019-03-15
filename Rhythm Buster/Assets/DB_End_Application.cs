using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_End_Application : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Ended");
    }
}

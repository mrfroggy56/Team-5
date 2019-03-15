using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DB_Change_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }
}

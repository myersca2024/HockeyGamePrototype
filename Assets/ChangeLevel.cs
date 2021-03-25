using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string sceneName;

    public void buttonChangeLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}

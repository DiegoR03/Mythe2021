using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public string level;

    public void LoadLevel1()
    {
        SceneManager.LoadScene(level);

        Time.timeScale = 1f;
    }
}

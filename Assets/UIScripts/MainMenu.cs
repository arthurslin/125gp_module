using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
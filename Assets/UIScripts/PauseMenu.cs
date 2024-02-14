using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public static bool paused;
    public Button resumeGame;
    public Button gotoMainMenu;
    public Slider hp;
    void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && hp.value != 0f) {
            if(paused) {
                ResumeGame();    
            }
            else {
                PauseGame(); 
            }
        }
    }
    public void PauseGame() {
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void ResumeGame() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void goMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void playerSuicide() {
        hp.value = 0f;
    }
}



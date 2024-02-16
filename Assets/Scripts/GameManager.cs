using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPContainer;
    public Slider hp;
    public GameObject pauseMenu;
    public GameObject gameOver;
    public GameObject[] disableGameOver;
 
    void Start()
    {
        StartCoroutine(playerProjectilePooling());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hp.value);
        if (hp.value == 0f)
        {
            pauseMenu.SetActive(true);
            PauseMenu.paused = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            foreach (GameObject obj in disableGameOver) {
                obj.SetActive(false);
            }
            gameOver.SetActive(true);
        }
    }
    IEnumerator playerProjectilePooling()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (playerPContainer.transform.childCount > 5)
            {
                Transform oldestChild = playerPContainer.transform.GetChild(0);
                Destroy(oldestChild.gameObject);
            }
        }
    }

}

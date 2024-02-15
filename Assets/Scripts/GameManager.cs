using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPContainer;
    
    void Start()
    {
        StartCoroutine(playerProjectilePooling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator playerProjectilePooling() {

        while (true) {
            yield return new WaitForSeconds(0.5f);
            if (playerPContainer.transform.childCount > 5) {
                Transform oldestChild = playerPContainer.transform.GetChild(0);
                Destroy(oldestChild.gameObject);
            }
        }
    }
}

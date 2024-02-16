using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProjectile : MonoBehaviour
{

    private Slider hp;
    void Start()
    {
        // since projectile is instantiated we can't use the slider as a prefab, so we have to find it
        // I should probably use a singleton for this...
        hp = GameObject.FindWithTag("hp").GetComponent<Slider>(); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hp.value = hp.value - 1;
            Destroy(gameObject);
        }
    }
}

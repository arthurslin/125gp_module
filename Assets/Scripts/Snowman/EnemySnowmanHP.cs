using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnowmanHP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (transform.childCount > 9)
        {
            Destroy(gameObject);
        }
    }
}

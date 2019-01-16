using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class expand : MonoBehaviour
{
    bool Expand = false;

    [Range(0.1f, 10f)]
   public float rate = 0.2f;


    void Update()
    {
        if (Expand)
        {
            Vector3 s = transform.localScale;
            s += new Vector3(Time.deltaTime*rate, Time.deltaTime* rate);
            transform.localScale = s;

        }

        if(transform.localScale.x > 30)
        {
            //changeScene
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Expand = true;

    }
}

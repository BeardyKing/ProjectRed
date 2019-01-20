using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToCredits : MonoBehaviour
{
	public LoadLevel loadLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			loadLevel.SelectLevelWait2(3);
		}
	}
}

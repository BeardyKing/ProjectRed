using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrozenObjects : MonoBehaviour {

    public GameObject objectFrozen1;
    public GameObject objectFrozen2;

    public GameObject GUI1;
    public GameObject GUI2;


    public Color[] colors =
    {
        Color.blue,
        Color.yellow

    };



    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {




        getStaticData();
        setUISprites();


        debugCancel(); // remove later


     

    }


    void getStaticData()
    {
        objectFrozen1 = StaticData.FrozenObjectOne;
        objectFrozen2 = StaticData.FrozenObjectTwo;
    }

    void setUISprites()
    {

        GUI1.transform.localScale = new Vector2(0.5f, 0.5f);
        GUI2.transform.localScale = new Vector2(0.5f, 0.5f);
        if (objectFrozen1)
        {
            GUI1.GetComponent<Image>().sprite = objectFrozen1.GetComponent<SpriteRenderer>().sprite;

        }
        else
        {
            GUI1.GetComponent<Image>().sprite = null;

        }

        if (objectFrozen2)
        {
            GUI2.GetComponent<Image>().sprite = objectFrozen2.GetComponent<SpriteRenderer>().sprite;

        }
        else
        {
            GUI2.GetComponent<Image>().sprite = null;
        }
    }

    void debugCancel()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StaticData.FrozenObjectOne = null;
            StaticData.FrozenObjectTwo = null;
        }


    }
}

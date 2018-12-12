using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavePlatformsManager : MonoBehaviour {

    GameObject[] textures;
    GameObject[] tiles;

    [Range(0, 1)]
    public float textureAlpha = 0.5f;


    public bool updateSprites = true;


	void Start () {


        AddSpriteMasks();

    }
	
	// Update is called once per frame
	void Update () {
        GetObjects();
        SetAlpha();
     

	}

    void GetObjects()
    {
        textures = GameObject.FindGameObjectsWithTag("caveTexture");
        tiles = GameObject.FindGameObjectsWithTag("caveTile");
    }

    void SetAlpha()
    {
        foreach (var texture in textures)
        {
            Color temp = texture.GetComponent<SpriteRenderer>().color;
            temp.a = textureAlpha;
            texture.GetComponent<SpriteRenderer>().color = temp;
        }
    }

    void AddSpriteMasks()
    {

        tiles = GameObject.FindGameObjectsWithTag("caveTile");
        foreach (var tile in tiles)
        {
            tile.AddComponent<createMask>();
        }
    }
}

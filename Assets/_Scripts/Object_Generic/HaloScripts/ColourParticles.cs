using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourParticles : MonoBehaviour
{

    // Use this for initialization
    ParticleSystem particles;
    FrozenObjects frozenObjects;


    bool findShape = true;

    ParticleSystem.MainModule main;
    ParticleSystem.EmissionModule emission;
    ParticleSystem.ShapeModule shape;

   
    public  Color[] colors  = new Color[]

    {
        Color.blue ,
        Color.yellow
    };



    public GameObject player;

    float rate = 300;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        main = particles.main;
        emission = particles.emission;
        shape = particles.shape;
        frozenObjects = GameObject.Find("EventHandeler").GetComponent<FrozenObjects>();
        colors = frozenObjects.colors;


        //temp maybenot
        player = GameObject.Find("player");


    }

    // Up

    void Update()
    {

        updateParticleSystem();


    }

    void updateParticleSystem()
    {
        if (StaticData.FrozenObjectOne == gameObject)
        {

            main.startColor = colors[0];
            emission.rateOverTime = rate;
            print("make some particles here");
            if (findShape)
            {
                shape.sprite = GetComponent<SpriteRenderer>().sprite;
                findShape = false;
            }


        }
        else if (StaticData.FrozenObjectTwo == gameObject)
        {
            main.startColor = colors[1];

            emission.rateOverTime = rate;

            if (findShape)
            {
                shape.sprite = GetComponent<SpriteRenderer>().sprite;
                findShape = false;
            }

        }else if(player.GetComponent<PlayerController>().playerState == "aim")
        {
            main.startColor = Color.white;
            emission.rateOverTime = rate;

            if (findShape)
            {
                shape.sprite = GetComponent<SpriteRenderer>().sprite;
                findShape = false;
            }
        }
        else
        {
           // main.startColor = new Color(00, 0, 0, 0);
            emission.rateOverTime = 0;
            findShape = true;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourParticles : MonoBehaviour
{

    // Use this for initialization

    public ParticleSystem particles;

    ParticleSystem.MainModule main;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        main = particles.main;
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

            main.startColor = Color.blue;
            print("make some particles here");


        }
        else if (StaticData.FrozenObjectTwo == gameObject)
        {
            main.startColor = Color.yellow;

        }
        else
        {
            main.startColor = new Color(00, 0, 0, 0);

        }
    }
}

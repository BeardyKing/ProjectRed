using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {


    public GameObject player;
    public Transform[] Spawnpoint = new Transform[1];
    public int CurrentSpawnPoint = 0;

  
    private void OnTriggerEnter2D(Collider2D other)
    {

        //print(other.gameObject.name);

        if(other.gameObject == player){
            other.gameObject.GetComponent<Animator>().SetTrigger("die");
            player.GetComponent<PlayerController>().playerState = "Respawn";
        }

    }


    public void die()
    {
      
        {
            player.gameObject.GetComponent<Animator>().SetTrigger("die");
            player.GetComponent<PlayerController>().playerState = "Respawn";
        }
    }

    public void spawn(){
        player.transform.position = Spawnpoint[CurrentSpawnPoint].transform.position;
    }
}

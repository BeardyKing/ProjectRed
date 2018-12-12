using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour {


     int spawnIndex = 0;

    public Respawn respawn;



    private void Start()
    {  
        for (int i = 0; i < respawn.Spawnpoint.Length; i++)
        {
            if(this.gameObject == respawn.Spawnpoint[i].gameObject)
            {
                spawnIndex = i;
                break;
            }
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(respawn.CurrentSpawnPoint < spawnIndex)
            {
                respawn.CurrentSpawnPoint = spawnIndex;
            }
        }
    }





}

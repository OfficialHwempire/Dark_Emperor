using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
   
    
   public Vector2 playerPos;
   public Vector2 direction;

   public float enemyLife =10.0f;
   public float enemyLifeCounter=0;



   public  float enemyVelocity;
    void Start(){
        if(GameObject.Find("Player") == null)
        {
            return;
        }
        enemyLife = StaticInfo.enemyLifeTime;
    playerPos = GameObject.Find("Player").transform.position;
        enemyVelocity = StaticInfo.enemySpeed + StaticInfo.enemySpeedCoefficient*StaticInfo.phase;
    direction = (playerPos - (Vector2)transform.position).normalized;


    }
    // Update is called once per frame
    void Update()
    {
      
        enemyLifeCounter += Time.deltaTime;
       transform.Translate(direction * enemyVelocity * Time.deltaTime);
         if(enemyLifeCounter >= enemyLife)
        {
            Destroy(this.gameObject);
        }
    }
}

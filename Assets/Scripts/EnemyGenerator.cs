using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy1Prefab;

    public GameObject enemy2Prefab;

    public GameObject enemy3Prefab;
    public float enemyCoolTime;

    public float enemyMinCoolTime;
    public float enemyMaxCoolTime;
    public float enemyCoolDownTimer;
    public bool isEnemy=false;
    public float phaseInterval ;
    void Start(){
        SetRandomCoolDown();
        if(this.gameObject.tag =="enemy"){
                    isEnemy = true;
        }
        
        enemyMinCoolTime = StaticInfo.enemyCoolTime;
        enemyMaxCoolTime = StaticInfo.enemyMaxCoolTime;
        
        
    }
    void Update(){

        enemyCoolDownTimer += Time.deltaTime;
        if(enemyCoolDownTimer > enemyCoolTime){
            if(isEnemy){
                SpawnEnemy1();
            }
            else{
            switch(StaticInfo.phase){
                case 0:
                    SpawnEnemy1();
                    break;
                case 1:
                    int enemyType2 = Random.Range(1,3);
                    if(enemyType2 == 1){
                        SpawnEnemy1();
                    }
                    else if(enemyType2 == 2){
                        SpawnEnemy2();
                    }
                    break;
                default :
                    int enemyType3 = Random.Range(1,4);
                    if(enemyType3 == 1){
                        SpawnEnemy1();
                    }
                    else if(enemyType3 == 2){
                        SpawnEnemy2();
                    }
                    else{
                        SpawnEnemy3();
                    }
                    break;
            }
            }
            
            SetRandomCoolDown();
            enemyCoolDownTimer = 0.0f;
        }

    }
    void SetRandomCoolDown(){
        enemyCoolTime = Random.Range(enemyCoolTime, enemyMaxCoolTime);

    }
    void SpawnEnemy1(){
        Instantiate(enemy1Prefab, transform.position, Quaternion.identity);
    }

    void SpawnEnemy2(){
        Instantiate(enemy2Prefab, transform.position, Quaternion.identity);
    }

    void SpawnEnemy3(){
        Instantiate(enemy3Prefab, transform.position, Quaternion.identity);
    }
}

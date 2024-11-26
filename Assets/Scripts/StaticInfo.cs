using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaticInfo:MonoBehaviour 
{
    // Start is called before the first frame update
    public DirGenerator dirGenerator;
    public static float playTime =0.0f;
    public static float enemySpeed =0.2f;

    public static float enemySpeedCoefficient = 0.1f;
    public static float enemy2Speed = 0.05f;

    public static float enemy2SpeedCoefficient = 0.05f;

    public static float enemy3Speed = 0.05f;

    public static float enemy3SpeedCoefficient = 0.05f;
    
    public static float enemyLifeTime = 120.0f;

    public static float enemyCoolTime = 10f;

    public static float enemyMaxCoolTime =20f;
    public static float dirCoolTime =4.0f;
    
    public static float preDirCoolTime =7.0f;

    public static float dirCoolDownTimer= 0.0f;

    public static int currentDirCount = 0;

    public static int currentPreDirCount = 0;

    public static int killCount =0;

    public static float phaseTimeInterval =60.0f;

    public static int phase =0;
    
    

    private int maxCallsPerFrame = 1;
    private int currentCallsThisFrame = 0;

       void Start(){
        ResetStaticVariables();
        InvokeRepeating("dirCreate", 0.0f, dirCoolTime);
        InvokeRepeating("preDirCreate", 0.0f, preDirCoolTime);
       }
    void dirCreate(){
        dirGenerator.GenerateDir();
    }
    
    void preDirCreate(){
        dirGenerator.GeneratePreDir();
    }
    void Update(){
        playTime += Time.deltaTime;
        if(playTime>=phaseTimeInterval && playTime<phaseTimeInterval*2){
            phase =1;
        }
        else if(playTime>=phaseTimeInterval*2 && playTime< phaseTimeInterval*3){
            phase =2;
        }
        else if(playTime>=phaseTimeInterval*3 && playTime< phaseTimeInterval*4){
            phase =3;
        }
        else if(playTime>=phaseTimeInterval*4 && playTime< phaseTimeInterval*5){
            phase =4;
            dirCoolTime =3.0f;
            preDirCoolTime =6.0f;
            enemyCoolTime = 8.0f;
        }
        else if(playTime>=phaseTimeInterval*5 && playTime< phaseTimeInterval*6){
            phase =5;
        }
        else if(playTime>=phaseTimeInterval*6 && playTime< phaseTimeInterval*7){
            phase =6;
            dirCoolTime=2.5f;
            preDirCoolTime =5.0f;
             enemyCoolTime = 6.0f;
        }
        else if(playTime>=phaseTimeInterval*7 && playTime< phaseTimeInterval*8){
            phase =7;
        }
        else if(playTime>=phaseTimeInterval*8 && playTime< phaseTimeInterval*9){
            phase =8;
        }
        else if(playTime>=phaseTimeInterval*9 && playTime< phaseTimeInterval*10){
            phase =9;
        }
        else if(playTime>=phaseTimeInterval*10 ){
            phase =10;
        }
      
    }

        public static void ResetStaticVariables()
    {
        playTime = 0.0f;
        dirCoolTime = 4.0f;
        preDirCoolTime = 7.0f;
        phase = 0;
        currentPreDirCount = 0;
        currentDirCount = 0;
        killCount = 0;
        enemyCoolTime = 10f;
    }

 



}

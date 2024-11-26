using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPage : MonoBehaviour
{
    private static ResultPage instance;

    public int killCount = 0;
    public float playTime =0;
    
    
    public static ResultPage Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ResultPage>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<ResultPage>();
                    singletonObject.name = typeof(ResultPage).ToString() + " (Singleton)";

                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}

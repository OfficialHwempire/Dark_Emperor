using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            ResultPage.Instance.killCount = StaticInfo.killCount;
            ResultPage.Instance.playTime = StaticInfo.playTime;
            Destroy(this.gameObject);
             UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");
        }
        }
    
   
}

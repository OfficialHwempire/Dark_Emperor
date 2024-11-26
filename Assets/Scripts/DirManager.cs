using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DirManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public TextMeshPro textMeshPro;

    
    public List<GameObject> enemyList = new List<GameObject>(); 



    void Start()
    {
        textMeshPro = this.GetComponentInChildren<TextMeshPro>();
        
    }
    public void SetName(string dirName){
        textMeshPro.text = dirName;
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            enemyList.Add(other.gameObject);
        }
        Debug.Log("enemy is entering");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            enemyList.Remove(other.gameObject);
        }
    }
    public void removeEnemy(){
        for (int i = enemyList.Count - 1; i >= 0; i--)
        {
            Destroy(enemyList[i]);
            StaticInfo.killCount++;
        }
        // 리스트를 비웁니다.
        enemyList.Clear();
    }
}

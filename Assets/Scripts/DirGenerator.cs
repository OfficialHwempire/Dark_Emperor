using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DirGenerator:MonoBehaviour
{
  public List<string> dirNames = new List<string>();

  public List<string> seenDirNames = new List<string>();

 public List<string> currentDirNames = new List<string>();    
 public Dictionary<string,GameObject> currentDirs = new Dictionary<string, GameObject>();
 public Dictionary<string,GameObject> currentPreDirs = new Dictionary<string, GameObject>();
    
    public GameObject dirPrefab;

    public GameObject preDirPrefab;

    public float maxWidth =100f;

    public float minWidth =0.0f;
    public float maxHeight =100f;
    public float minHeight = 0.0f;
    public int maxDir = 10;
    public int maxPreDir = 10;
    
        // Start is called before the first frame update
    void Start(){}
    void Update(){}
    public void GenerateDir()
    {
      
      if(StaticInfo.currentDirCount >= maxDir)
      {
        return;
      }
      List<string> availableDirNames = dirNames.Except(currentDirNames).ToList();
      if(availableDirNames.Count == 0)
      {
        return;
      }
      Vector2 randomPos = new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
      GameObject newDir = Instantiate(dirPrefab, randomPos, Quaternion.identity);
      string randomName = availableDirNames[Random.Range(0, availableDirNames.Count)];
      DirManager dirManager = newDir.GetComponent<DirManager>();
     
     dirManager.SetName(randomName );
      currentDirNames.Add(randomName);
        currentDirs.Add(randomName, newDir);
        if(!seenDirNames.Contains(randomName))
      {
        seenDirNames.Add(randomName);
      }
      StaticInfo.currentDirCount ++;

    }
    public void GeneratePreDir()
    { 
        if(StaticInfo.currentPreDirCount >= maxPreDir)
        {
            return;
        }  
        List<string> availablePreDirNames = dirNames.Except(currentDirNames).ToList();
         if(availablePreDirNames.Count == 0)
      {
        return;
      }
    Vector2 randomPos = new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
      GameObject newPreDir= Instantiate(preDirPrefab, randomPos, Quaternion.identity);
      
        string randomName = availablePreDirNames[Random.Range(0, availablePreDirNames.Count)];
      DirManager dirManager = newPreDir.GetComponent<DirManager>();
     
     dirManager.SetName(randomName );
      currentDirNames.Add(randomName);
        currentPreDirs.Add(randomName, newPreDir);
      if(!seenDirNames.Contains(randomName))
      {
        seenDirNames.Add(randomName);
      }
      StaticInfo.currentPreDirCount ++;
    }

    public void RemoveDir(string dirName)
    {
        currentDirNames.Remove(dirName);
        currentDirs.Remove(dirName);
    }

    public void RemovePreDir(string dirName)
    {
        currentDirNames.Remove(dirName);
        currentPreDirs.Remove(dirName);
    }

    public void mkdir(string dirName)
    {
      GameObject currentDir = currentPreDirs[dirName];
      Vector2 currentPos = currentDir.transform.position;
      Destroy(currentDir);
      GameObject createdDir = Instantiate(dirPrefab, currentPos, Quaternion.identity);
      createdDir.GetComponent<DirManager>().SetName(dirName); 
      currentPreDirs.Remove(dirName);
      currentDirs.Add(dirName, createdDir);
    
        
    }

}

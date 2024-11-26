using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TypeController : MonoBehaviour
{
    // Start iscalled befor
    private static string CdString = "cd";
    private static string MkdirString = "mk";

    private static string RmDirString = "rm";

    public AudioSource explosionSource;
    public AudioSource okaySource;
    public AudioSource tpSource;

    public AudioSource mkSource;
    public Dictionary<string, string> macroDict = new Dictionary<string, string>();

    public int tabCount =0;
    public string tabTempString = string.Empty;

    public DirGenerator dirGenerator;
    public GameObject playerPrefab;
    TMP_InputField inputField;
   void Start(){

    inputField=this.GetComponent<TMP_InputField>();
    inputField.text =string.Empty;
    inputField.onEndEdit.AddListener(delegate {GetInputEnter();});
    inputField.Select();
   }

   void Update(){
    if(Input.GetKeyDown(KeyCode.Tab))
    {
        string currentText = inputField.text;
        string newtext;
        if(tabCount>0 || tabTempString.Length>0)
        {
            newtext = GetInputTab(tabTempString);
        }
        else{
        newtext = GetInputTab(currentText);
       
        }
         inputField.text = newtext;
        inputField.caretPosition = inputField.text.Length;
    }
   }
   string GetInputTab(string inputFieldText){
    string [] currentTexts = inputFieldText.Split(' ');
    string parsingText = currentTexts[currentTexts.Length-1];
    if(parsingText.Length == 0)
    {
        return inputFieldText;
    }
    var filterTexts = dirGenerator.currentDirNames.Where(n=>n.StartsWith(parsingText)).ToList();
    if(filterTexts.Count == 0)
    {
        return inputFieldText;
    }
    // if(tabCount>=filterTexts.Count-1)
    // {
    //     tabCount = 0;
    // }
    string result = filterTexts[tabCount];
    tabTempString = inputFieldText;
    if(filterTexts.Count-1>tabCount){
        tabCount++;
    }
    else{
        tabCount = 0;
    }
    currentTexts[currentTexts.Length - 1] = result;
    return string.Join(" ", currentTexts);
    
    
    
   }
      void GetInputEnter(){
    string currentText = inputField.text;
    Debug.Log(currentText);
    inputField.text = string.Empty;
    inputField.Select();
    inputField.ActivateInputField();
    if(currentText.Length == 0)
    {
        return;
    }
    TypeParse(currentText);
     tabCount = 0;
     tabTempString = string.Empty;

   }

   void TypeParse(string typeString){
        if (typeString == "boom")
    {
        // currentDirs.Keys를 리스트로 복사
        List<string> keys = new List<string>(dirGenerator.currentDirs.Keys);

        // 리스트를 사용하여 안전하게 컬렉션 수정
        foreach (var element in keys)
        {
            RmDirAction(element);
        }
       
        return;
    }
    if(macroDict.ContainsKey(typeString))
    {
        TypeParse(macroDict[typeString]);
        
        return;
    }
    string [] typeParts = typeString.Split(' ');
    if(typeParts.Length ==4 && typeParts[0]=="ai" &&(typeParts[1]=="cd" || typeParts[1]=="mk" || typeParts[1]=="rm"))
    {
        string registerString = typeParts[3];
        string macroString = typeParts[1] + " " + typeParts[2];
        
        macroDict.Add(registerString, macroString); 
        okaySource.Play();
        
        return;

    }
    if(typeParts.Length!=2)
    {
        
        Debug.Log("Invalid Command");
       
        return;
    }
    switch(typeParts[0])
    {
        case "cd":
            CdAction(typeParts[1]);
            break;
        case "mk":
            MkdirAction(typeParts[1]);
            break;
        case "rm":
            RmDirAction(typeParts[1]);
            break;
        default:
            Debug.Log("Invalid Command");
            break;
    }
   
    return;

   }
   void CdAction(string dirName){
    if(dirName ==".."){
                    StaticInfo.ResetStaticVariables();
            UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
    if(!dirGenerator.currentDirs.ContainsKey(dirName))
    {
        Debug.Log("Invalid Directory");
        return;
    }
    tpSource.Play();
    GameObject DestinationDir = dirGenerator.currentDirs[dirName];
    Vector2 DestinationPos = DestinationDir.transform.position;
    playerPrefab.transform.position = new Vector3(DestinationPos.x, DestinationPos.y, playerPrefab.transform.position.z);
    dirGenerator.RemoveDir(dirName);
    Destroy(DestinationDir);
    StaticInfo.currentDirCount--;
    



   }
   
   void MkdirAction(string preDirName){
    if(!dirGenerator.currentPreDirs.ContainsKey(preDirName))
    {
        Debug.Log("Invalid Directory");
        return;
    }
    mkSource.Play();
    dirGenerator.mkdir(preDirName);
    StaticInfo.currentPreDirCount--;
    StaticInfo.currentDirCount++;


   }

   void RmDirAction(string dirName){
        if(!dirGenerator.currentDirs.ContainsKey(dirName))
    {
        Debug.Log("Invalid Directory");
        return;
    }
    explosionSource.Play();
      GameObject DestinationDir = dirGenerator.currentDirs[dirName];
      DestinationDir.GetComponent<DirManager>().removeEnemy();
        dirGenerator.RemoveDir(dirName);
    Destroy(DestinationDir);
    StaticInfo.currentDirCount--;
    

   }


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField inputField;
    public TextMeshProUGUI descriptionText;

    void Start()
    {
        inputField = this.GetComponent<TMP_InputField>();
        inputField.Select();
        inputField.onEndEdit.AddListener(delegate { GetInputEnter(inputField.text); });
    }
    void GetInputEnter(string currentText){
        
        inputField.text =string.Empty;
        inputField.Select();
        inputField.ActivateInputField();
        if(currentText == "cd game")
        {
            StaticInfo.ResetStaticVariables();
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }
        else if(currentText == "cd ..")
        {
            Application.Quit();
        }
        else
        {
            descriptionText.text = "Please listen carefully, type 'cd game'";
        }

    }
}

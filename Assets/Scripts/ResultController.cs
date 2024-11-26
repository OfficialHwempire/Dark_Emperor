using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultController : MonoBehaviour
{
    // Start is called before the first frame update
 public TMP_InputField inputField;
public TextMeshProUGUI resultText;

    void Start()
    {
        inputField = this.GetComponent<TMP_InputField>();
        inputField.onEndEdit.AddListener(delegate { GetInputEnter(inputField.text); });
        inputField.Select();
        resultText.text = "You have killed " + ResultPage.Instance.killCount + " enemies in " + ResultPage.Instance.playTime + " seconds.";
    }
    void GetInputEnter(string currentText){
        inputField.text =string.Empty;
        inputField.Select();
        inputField.ActivateInputField();
        if(currentText == "cd ..")
        {
            ResultPage.Instance.killCount = 0;
            ResultPage.Instance.playTime = 0;
            StaticInfo.ResetStaticVariables();
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }

    }
}

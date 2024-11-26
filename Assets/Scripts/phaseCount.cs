using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class phaseCount : MonoBehaviour
{
    // Start is called before the first frame update
  public GameObject phaseCountText;
  public GameObject enemyCountText;

  void Update(){
    phaseCountText.GetComponent<TextMeshProUGUI>().text = "Phase: " + StaticInfo.phase;
    enemyCountText.GetComponent<TextMeshProUGUI>().text = "Enemies: " + StaticInfo.killCount;
  }

}

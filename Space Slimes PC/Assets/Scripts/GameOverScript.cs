using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour { 
    public Text PointsText;

  public void Setup(int score)
    {
        gameObject.SetActive(true);
        PointsText.text= "POINTS :"+score.ToString();

    }

  
}

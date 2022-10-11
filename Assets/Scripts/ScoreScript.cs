using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
     public TextMeshProUGUI scoreDisplay;
     public int score = 0;
     public TextMeshProUGUI timerText;
     private float secondsCount;
     private int minuteCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerUI();
        scoreDisplay.text = score.ToString();
    }
     //call this on update
     public void UpdateTimerUI(){
         //set timer UI
         secondsCount += Time.deltaTime;
         timerText.text = minuteCount +"m:"+(int)secondsCount + "s";
         if(secondsCount >= 60){
             minuteCount++;
             secondsCount = 0;
         }else if(minuteCount >= 60){
             minuteCount = 0;
         }    
     }

}

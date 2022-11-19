using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timers : MonoBehaviour{
    public float startTime;
    public float currentTime;
    public TMP_Text timerTMP;

    // Start is called before the first frame update
    void Start(){
        RestartTimer();
    }

    // Update is called once per frame
    void Update(){
        UpdateTimer();
    }

    public void RestartTimer(){
        currentTime = startTime;
        
    }

    public void UpdateTimer(){
        if(currentTime <= 0){
            return;
        }
        currentTime -= Time.deltaTime;
        if(timerTMP != null) timerTMP.text = "Sisa waktu : "+currentTime;
    }
}

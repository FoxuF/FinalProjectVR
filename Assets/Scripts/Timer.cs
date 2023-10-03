using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timeOn;
    public Text timerText;
    public static Timer instance { get; private set; }
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeOn = true;
        timeLeft =60;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeOn==true)
        {
            if(timeLeft > 0)
            {
                timeLeft = timeLeft-Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timeOn = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
       

    }

    private void UpdateTimer(float currentTime)
    {
        timerText.text = string.Format("Time: " + currentTime);
        //Debug.Log("time: " + currentTime);
    }
}

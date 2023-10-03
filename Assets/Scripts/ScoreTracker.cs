using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text score;
    void Start()
    {
        score.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + Player.instance.score.ToString() + "\n";
        
        
    }
}

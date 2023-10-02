using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public uint score = 0;
    public static Player instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        health -= damage;
    }

    public void ReduceScore(int scoreReduce)
    {
        score -= 100;
        if (score < 0)
        {
            score = 0;
        }
        Debug.Log("Huvos");
    }
    public void AddScore(int scoreAdd)
    {
        score += 100;
        Debug.Log("Tan");
    }
}

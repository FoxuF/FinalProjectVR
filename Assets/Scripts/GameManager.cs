using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public int HP;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        HP = Player.health;
    }

    // Update is called once per frame
    void Update()
    {
        HP = Player.health;
        DetectPlayerHP();
        UpdateHP();
    }

    private void DetectPlayerHP()
    {
        if(HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void UpdateHP()
    {
        hpText.text = string.Format("HP: " + HP);
    }
}
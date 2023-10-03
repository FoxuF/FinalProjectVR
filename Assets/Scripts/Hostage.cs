using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{
    public int health = 1;
    public SpriteRenderer someSprite;
    private Collider myCollider;
    public AudioSource audioPlayer;
    public Transform target;
    
    private float spawnTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        someSprite = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider>();
        target = Player.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (someSprite.enabled == false)
        {
            
            SpawnTimer();
        }
    }

    public void Damage(int damage)
    {
        someSprite.enabled = false;
        myCollider.enabled = false;
        audioPlayer.Play();
    }
    private void SpawnTimer()
    {
        if (spawnTime > 0)
        {
            spawnTime = spawnTime - Time.deltaTime;

        }
        else
        {
            EnableSprite();
        }

    }
    private void EnableSprite()
    {
        someSprite.enabled = true;
        myCollider.enabled = true;
        spawnTime = Random.Range(3, 8);
    }
}

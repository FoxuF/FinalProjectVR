using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health = 1;
    private float spawnTime ;
    public Transform FirePoint;
    public GameObject Fire;
    public SpriteRenderer someSprite;
    private Collider myCollider;
    public AudioSource audioPlayer;
    public AudioSource fireSound;
    public Transform target;
    
    private float fireRate= 4.5f;
    // esto es ngierada
    public bool canFire = false;

    public bool firstSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(5, 10);
        someSprite = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider>();
        target = Player.instance.transform;
        canFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstSpawn)
        {
            firstSpawn = false;
            canFire = false;
            StartCoroutine(FireRateHandler());
        }
        if (someSprite.enabled == false)
        {
            
            SpawnTimer();
        }
        else
        {
            
            transform.LookAt(target);
            RaycastHit hit;
            if (canFire)
            {

                canFire = false;
                if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 200))
                {
                    Debug.Log("Shooting");
                    GameObject a = Instantiate(Fire, FirePoint.position, Quaternion.identity);
                    Destroy(a, 1);
                    fireSound.Play();
                    Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                        Color.green);
                    Player player = hit.transform.GetComponent<Player>();

                    if (player != null)
                    {
                        player.Damage(1);
                    }

                }

                StartCoroutine(FireRateHandler());
            }
        }
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
            firstSpawn = true;
        }

    }

    private void EnableSprite()
    {
        someSprite.enabled = true;
        myCollider.enabled = true;
        spawnTime = Random.Range(5, 10);
    }

    public void Damage(int damage)
    {
        someSprite.enabled = false;
        myCollider.enabled = false;
        audioPlayer.Play();
    }

    public void Shoot()
    {
        FireRateHandler();
    }
    
    IEnumerator FireRateHandler()
    {
        //RaycastHit hit;
        float timeToNextFire = fireRate;
        
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;

    }
}

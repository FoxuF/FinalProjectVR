using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20.0f;
    public Transform FirePoint;

    public GameObject Fire;

    public GameObject HitPoint;

    public AudioSource audioPlayer;
    
    private float fireRate= 2.5f;

    private bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Shooting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs args)
    {
        
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.transform.eulerAngles = spawnPoint.eulerAngles;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }
    
    public void Shooting(ActivateEventArgs args)
    {
        
        RaycastHit hit;
        if (canFire)
        {
            canFire = false;
            if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
            {
                
                Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                    Color.yellow);

                GameObject a = Instantiate(Fire, FirePoint.position, Quaternion.identity);
                audioPlayer.Play();
                GameObject b = Instantiate(HitPoint, hit.point, Quaternion.identity);

                Destroy(a, 1);
                Destroy(b, 1);
                Enemy enemy = hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.Damage(2);
                }
                StartCoroutine(FireRateHandler());
            }

            
        }
    }
    
    IEnumerator FireRateHandler()
    {
        float timeToNextFire = 1.0f / fireRate;
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;
    }
}

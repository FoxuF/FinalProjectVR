using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireOnActivate : MonoBehaviour
{
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

    public void Shooting(ActivateEventArgs args)
    {
        
        RaycastHit hit;
        if (canFire)
        {
            canFire = false;
            GameObject a = Instantiate(Fire, FirePoint.position, Quaternion.identity); 
            audioPlayer.Play();
            if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 200))
            {
                
                Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                    Color.yellow);

                
               
                GameObject b = Instantiate(HitPoint, hit.point, Quaternion.identity);

                Destroy(a, 1);
                Destroy(b, 1);
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                Hostage hostage = hit.transform.GetComponent<Hostage>();
                if (enemy != null)
                {
                    enemy.Damage(1);
                    Player.instance.AddScore(100);
                }
                if (hostage != null)
                {
                    hostage.Damage(1);
                    Player.instance.ReduceScore(100);
                }
                
            }
            canFire = true;
            StartCoroutine(FireRateHandler());
            
        }
        
    }
    
    IEnumerator FireRateHandler()
    {
        float timeToNextFire = 1.0f / fireRate;
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetRayController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public float lifeSpan = 0.03f; // Keep at 0.03
    public float attractSpeed = 5;
    private GameObject player;
    private Transform firePoint;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        lineRenderer.enabled = false;

        player = GameObject.Find("Player");
        print(player.name);
        firePoint = player.transform.Find("Place Position");
        print(firePoint.name);
        
        
        //play the sound effect 
        SoundManagerController.PlaySoundEffect("freezeray"); 
        
        //wait to play the sound effect 
        System.Threading.Thread.Sleep(10);

        StartCoroutine(Shoot());

        //Invoke("SelfDestruct", freezeRayLifeSpan);
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            GameObject other = hitInfo.transform.gameObject;
            if (other.CompareTag("Magnetizable"))
            {
                if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) {
                    rb.velocity = -firePoint.right * attractSpeed;
                }
            }

            Vector3 hitPointPos = new Vector3(hitInfo.point.x, hitInfo.point.y, 0f);

            print("Player Position" + player.transform.position);
            print("HitPoint Position" + hitPointPos);


            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, hitPointPos);
        }
        else
        {
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, player.transform.position + player.transform.right * 100);
        }


        lineRenderer.enabled = true;

        yield return new WaitForSeconds(lifeSpan);

        SelfDestruct();
    }

    void SelfDestruct() {
        gameObject.SetActive(false);
    }
}

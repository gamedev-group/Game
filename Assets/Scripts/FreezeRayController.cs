using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRayController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public float freezeRayLifeSpan = 0.03f;
    public GameObject iceCube;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        //play the sound effect 
        SoundManagerController.PlaySoundEffect("freezeray"); 
        
        //wait to play the sound effect 
        System.Threading.Thread.Sleep(10);

        Shoot();

        Invoke("SelfDestruct", freezeRayLifeSpan);
    }

    private void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right);

        if (hitInfo)
        {
            if (hitInfo.transform.TryGetComponent<DoesDamage>(out DoesDamage enemy))
            {
                Instantiate(iceCube, hitInfo.transform.position, Quaternion.identity);
                if (enemy.TryGetComponent<PatrollBehavior>(out PatrollBehavior pB)) {
                    pB.enabled = false;
                }
                if (enemy.TryGetComponent<Animator>(out Animator animator)) {
                    animator.enabled = false;
                }
                enemy.contactDamage = 0;
            }

            print(transform.position);
            print(hitInfo.point);

            lineRenderer.SetPosition(0, (transform.position.x - hitInfo.point.x) * -Vector2.right);
            lineRenderer.SetPosition(1, Vector2.zero);
        }
        else
        {
            lineRenderer.SetPosition(0, Vector2.zero);
            lineRenderer.SetPosition(1, transform.position + transform.right * 100);
        }
    }

    void SelfDestruct() {
        gameObject.SetActive(false);
    }
}

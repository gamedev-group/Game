using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRayController : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public float freezeRayLifeSpan = 0.03f;
    public GameObject iceCube;

    private void Start()
    {
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //play the sound effect 
            SoundManagerController.PlaySoundEffect("freezeray"); 
            //wait to play the sound effect 
            System.Threading.Thread.Sleep(10);

            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

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
            }

            print(firePoint.position);
            print(hitInfo.point);

            lineRenderer.SetPosition(0, Vector2.zero);
            lineRenderer.SetPosition(1, hitInfo.point.x * Vector2.right);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;
        yield return new WaitForSeconds(freezeRayLifeSpan);
        lineRenderer.enabled = false;
    }

}

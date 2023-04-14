using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRayController : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public float freezeRayLifeSpan = 0.03f;

    private void Start()
    {
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            DoesDamage enemy = hitInfo.transform.GetComponent<DoesDamage>();

            if (enemy != null)
            {
                //TODO: Replace current version of enemy with a version of the enemy thats trapped
                // in an ice cube. This object should essentially be a platform.
                print("Hit enemy");
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
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

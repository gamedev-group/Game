/***************************************************************
*file: FreezeRayController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This script is resposible for the functionality of the
*freeze ray gadget. It sends out a ray and if the object that is
*hit can be frozen it will freeze the enemy.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRayController : MonoBehaviour
{
    private LineRenderer lineRenderer; //The line that displays the Freeze Ray effect
    public float freezeRayLifeSpan = 0.03f; //Duration of Freeze Ray effect on enemy
    public GameObject iceCube; //The ice cube game object created when Freeze Ray hits an enemy
    private GameObject player; //The game object for the player
    private Transform firePoint; //The point from which the Freeze Ray is fired



    private void Awake() {
        //Get the Line Renderer component
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        lineRenderer.enabled = false; //Hide the Freeze Ray line

        player = GameObject.Find("Player"); //Get the Player game object
        firePoint = player.transform.Find("Place Position"); //Get the point from which the Freeze Ray is fired

        //play the sound effect 
        SoundManagerController.PlaySoundEffect("freezeray");
        //wait to play the sound effect 
        System.Threading.Thread.Sleep(10);

        StartCoroutine(Shoot()); //Fire the Freeze Ray

        //Invoke("SelfDestruct", freezeRayLifeSpan);
    }

    IEnumerator Shoot()
    {
        // shoot a raycast from the fire point of the player
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        // check if raycast hit anything
        if (hitInfo)
        {
            // check if the hit object has a DoesDamage component, meaning it is an enemy
            if (hitInfo.transform.TryGetComponent<DoesDamage>(out DoesDamage enemy))
            {
                print("Hit Enemy");
                // create an ice cube prefab at the hit point
                Instantiate(iceCube, hitInfo.transform.position, Quaternion.identity);

                // disable certain enemy behaviors to freeze them
                if (enemy.TryGetComponent<PatrollBehavior>(out PatrollBehavior pB)) {
                    pB.enabled = false;
                }
                if (enemy.TryGetComponent<MoveBackForth>(out MoveBackForth mBF)) {
                    mBF.enabled = false;
                }
                if (enemy.TryGetComponent<Animator>(out Animator animator)) {
                    animator.enabled = false;
                }
                if (enemy.TryGetComponent<DoesDamage>(out DoesDamage dD)){ 
                    dD.enabled = false;
                }
                if (enemy.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }

            // get the position of the hit point
            Vector3 hitPointPos = new Vector3(hitInfo.point.x, hitInfo.point.y, 0f);


            print("Player Position" + player.transform.position);
            print("HitPoint Position" + hitPointPos);

            // set the start and end positions of the line renderer to player position and hit point position respectively
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, hitPointPos);
        }
        else
        {
            // if raycast did not hit anything, set end position of line renderer far ahead
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, player.transform.position + player.transform.right * 100);
        }


        // enable the line renderer to display the freeze ray
        lineRenderer.enabled = true;

        // wait for the freeze ray lifespan before disabling the freeze ray game object
        yield return new WaitForSeconds(freezeRayLifeSpan);
        SelfDestruct();
    }


    //function:SelfDestruct
    //purpose:this method makes the linerender object inactive
    void SelfDestruct() {
        gameObject.SetActive(false);
    }
}

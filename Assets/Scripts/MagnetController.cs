using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //check if 
        //      the magnet has been activated or not 
        //      the horizontal distance between the player and the object is less than or is it greater than 1.4 
        //      the vertical distance between the player and the object is less than or greater than 0.55 
        if(collision.gameObject.TryGetComponent<Block>(out Block block1) && GameManager.instance.hasMagnet == true && (Mathf.Abs(transform.parent.position.x - collision.gameObject.transform.position.x) < 1.4) &&  (Mathf.Abs(transform.parent.position.y - collision.gameObject.transform.position.y) < 0.55))
        {
            //deactivate the magnet 
            GameManager.instance.hasMagnet = false; 
            block1.SetHasTarget(false); 
            //if the object is a Ramp, then destory its Rigidbody2D
            if(collision.gameObject.tag == "Ramp" && collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        else if(collision.gameObject.TryGetComponent<Block>(out Block block) && GameManager.instance.hasMagnet == true )
        {
            //the target position is the position of the player 
            block.SetTarget(transform.parent.position, true); 
            //sound effect of magnet
            SoundManagerController.PlaySoundEffect("magnet"); 
        }
        else if(collision.gameObject.TryGetComponent<Block>(out Block block2))
        {
            //magnet is not activated 
            block2.SetHasTarget(false); 
        }
    }
}

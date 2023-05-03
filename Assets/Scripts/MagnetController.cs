/***************************************************************
*file: Block.cs
*author: Group
*class: CS 4700 – Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: The purpose of this script is to control the movement
*of in-game blocks using a magnet. When the magnet is activated,
*this script is responsible for checking if the player is close
*enough to the block and if so, it moves the block towards the
*player. If the block is a Ramp, its Rigidbody2D component is
*destroyed. If the magnet is not activated or the block is too
*far away from the player, the block is not affected by the magnet.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{

    //function: OnTriggerStay2D
    //purpose: The purpose of the OnTriggerStay2D function is
    //to handle the interaction between a magnet and a block when
    //they collide. It checks the activation status of the magnet and
    //the distance between the magnet and the block to perform the necessary actions.
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

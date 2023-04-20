using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Block>(out Block block) && GameManager.instance.hasMagnet == true && (Mathf.Abs(transform.parent.position.x - collision.gameObject.transform.position.x) > 1.5))
        {
            block.SetTarget(transform.parent.position, true); 
            print("Yesss");
        }
        else if(collision.gameObject.TryGetComponent<Block>(out Block block2) && GameManager.instance.hasMagnet == true &&(Mathf.Abs(transform.parent.position.x - collision.gameObject.transform.position.x) <= 1.5))
        {
            GameManager.instance.hasMagnet = false; 
            block2.SetHasTarget(false); 
            print("nooooo"); 
        }
        else if(collision.gameObject.TryGetComponent<Block>(out Block block3))
        {
            block3.SetHasTarget(false); 
        }
    }
}

//((Time.time - ItemPlacer.magnetStartTime) < 3f
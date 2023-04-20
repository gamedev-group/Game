using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Block>(out Block block) && GameManager.instance.hasMagnet == true && ((Time.time - ItemPlacer.magnetStartTime) < 3f))
        {
            print(Time.time - ItemPlacer.magnetStartTime); 

            block.SetTarget(transform.parent.position, true); 
        }
        else if(collision.gameObject.TryGetComponent<Block>(out Block block2) && GameManager.instance.hasMagnet == true && ((Time.time - ItemPlacer.magnetStartTime) >= 3f))
        {
            GameManager.instance.hasMagnet = false; 
            block2.SetHasTarget(false); 
            print(Time.time - ItemPlacer.magnetStartTime); 
        }
        else if(collision.gameObject.TryGetComponent<Block>(out Block block3))
        {
            block3.SetHasTarget(false); 
        }
    }
}

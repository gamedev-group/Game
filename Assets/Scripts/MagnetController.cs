using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Block>(out Block block) && GameManager.instance.hasMagnet == true && (Mathf.Abs(transform.parent.position.y - collision.gameObject.transform.position.y) > 0.5))
        {
            block.SetTarget(transform.parent.position, true); 
        }
        else if(collision.gameObject.TryGetComponent<Block>(out Block block1) && GameManager.instance.hasMagnet == true && (Mathf.Abs(transform.parent.position.y - collision.gameObject.transform.position.y) <= 0.5))
        {
            GameManager.instance.hasMagnet = false; 
            block1.SetHasTarget(false); 
            if(collision.gameObject.tag == "Ramp")
            {
                Destroy(collision.gameObject.GetComponent<Rigidbody2D>()); 
            }
        }
        else if(collision.gameObject.TryGetComponent<Block>(out Block block2))
        {
            block2.SetHasTarget(false); 
        }
    }
}
//(Mathf.Abs(transform.parent.position.x - collision.gameObject.transform.position.x) > 1.2) &&  

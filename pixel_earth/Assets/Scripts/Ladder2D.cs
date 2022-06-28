using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Collider2D ladderCollider;
    [HideInInspector]
    public Vector3 boundsCenter;
    // Start is called before the first frame update
    void Start()
    {
        //t = transform;
        ladderCollider = GetComponent<Collider2D>();
        if (ladderCollider)
        {
            ladderCollider.isTrigger = true;
            ladderCollider.gameObject.layer = 2; //Set ladder collider layer to IgnoreRaycast
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ladderCollider)
            {
                boundsCenter = ladderCollider.bounds.center;
            }
            other.SendMessage("AssignLadder", this, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("RemoveLadder", this, SendMessageOptions.DontRequireReceiver);
        }
    }

}

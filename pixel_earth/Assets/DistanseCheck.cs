using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanseCheck : MonoBehaviour
{
    private Animator anim;
    float distance;
    Vector3 player;
    Vector3 entry;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        entry = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("sprite_hero").transform.position;
        distance = Vector3.Distance(player, entry);
        anim.SetFloat("Distance", distance);
    }
}

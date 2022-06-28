using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [Header("Distance from door")]
    public float distance;
    Vector3 player;
    Vector3 entry;
    // Start is called before the first frame update
    void Start()
    {
        entry = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("sprite_hero").transform.position;
        distance = Vector3.Distance(player, entry);
        if(distance < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

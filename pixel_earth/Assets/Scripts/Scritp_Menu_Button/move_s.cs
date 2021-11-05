using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move_s : MonoBehaviour
{

    public GameObject Menu;
    public GameObject Start_move;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(true);
        Start_move.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLevelPanel()
    {
        Menu.SetActive(false);
        Start_move.SetActive(true);
    }

    public void ShowMenuPanel()
    {
        Menu.SetActive(true);
        Start_move.SetActive(false);
    }

}


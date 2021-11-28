using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takeFPSincamera : MonoBehaviour
{
    public Text fpsText;
    public static float fps;

    public PlayerControler PlayerControler
    {
        get => default;
        set
        {
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fps = 1.0f / Time.deltaTime;
        fpsText.GetComponent<Text>().text = "fps" + (int)fps; 
    }
}

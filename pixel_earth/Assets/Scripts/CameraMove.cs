using UnityEngine;
//using System.Timers;
using System.Threading;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    public PlayerControler PlayerControler
    {
        get => default;
        set
        {
        }
    }

    void Update()
    { 
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+0, -20f);
    }
}

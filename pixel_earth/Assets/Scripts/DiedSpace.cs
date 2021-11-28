using UnityEngine;

public class DiedSpace : MonoBehaviour
{
    public GameObject Respawn;

    public PlayerControler PlayerControler
    {
        get => default;
        set
        {
        }
    }

    void OnTriggerEntre2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = Respawn.transform.position;
        }
    }
}

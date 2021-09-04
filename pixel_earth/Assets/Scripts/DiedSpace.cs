using UnityEngine;

public class DiedSpace : MonoBehaviour
{
    public GameObject Respawn;
    void OnTriggerEntre2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = Respawn.transform.position;
        }
    }
}

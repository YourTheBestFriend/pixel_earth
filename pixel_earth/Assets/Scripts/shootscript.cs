using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootscript : MonoBehaviour
{
    public Transform Gun;
    public Transform ShootPoint; 
    public GameObject patron;
    public float patronSpeed;
    public float fireRate;
    float ReadyForNextShoot;
    Vector2 direction;

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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouse();

        if (Input.GetMouseButton(0))
        {
            if (Time.time > ReadyForNextShoot)
            {
                ReadyForNextShoot = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    void FaceMouse()
    {
        Gun.transform.right = direction;
    }
    void Shoot()
    {
        GameObject PatronIns = Instantiate(patron, ShootPoint.position, ShootPoint.rotation);
        PatronIns.GetComponent<Rigidbody2D>().AddForce(PatronIns.transform.right * patronSpeed);
        Destroy(PatronIns, 3); // Delete object PatronIns
    }
}

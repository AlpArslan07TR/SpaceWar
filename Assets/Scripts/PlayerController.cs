using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    Rigidbody physic;
    AudioSource audio_shot;
    [SerializeField] int speed;
    [SerializeField] int tilt;
    [SerializeField] float nextfire;
    [SerializeField] float FireRate;

    public Boundary boundary;
    public GameObject LaserShot;
    public GameObject Laser;
    

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audio_shot = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (Input.GetButton("Fire1")&& Time.time> nextfire)
        {
            nextfire = Time.time + FireRate;
            Instantiate(Laser, LaserShot.transform.position, LaserShot.transform.rotation);
            audio_shot.Play();
        }
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(moveHorizontal, 0, moveVertical);

        physic.velocity = mov*speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x,boundary.xMin,boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax)
            );

        physic.position = position;
        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x*tilt);
    }
}

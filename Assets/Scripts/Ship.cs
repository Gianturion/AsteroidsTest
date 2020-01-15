using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody rigibody;
    public float rotationVelocity=45;
    public float acceleration;
    public GameObject shotReference;
    public int Life;
   

    private void Awake()
    {
    }
    void Rotate(float direction)                                       //Ship rotation
    {
        rigibody.AddTorque(transform.up * rotationVelocity * Time.deltaTime * direction);
        //transform.Rotate(Vector3.up * rotationVelocity * Time.deltaTime * direction);
    }

    void Shot()                                                        //projectiles
    {
        GameObject newShot = Instantiate(shotReference, transform.position, transform.localRotation);
    }

    void Accelerate()                                                  //RigidBody movement speed
    {
        rigibody.AddForce(transform.forward * acceleration * Time.deltaTime);
        //transform.Translate(Vector3.forward * acceleration * Time.deltaTime);
    }

    void Die()
    {

    }

    void CrossScreen()
    {
        Camera cam = FindObjectOfType<Camera>();
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);

        if (screenPoint.x > 1)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(0, screenPoint.y, screenPoint.z));
        }
        else if (screenPoint.x < 0)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(1, screenPoint.y, screenPoint.z));
        }
        else if (screenPoint.y > 1)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(screenPoint.x, 0, screenPoint.z));
        }
        else if (screenPoint.y < 0)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(screenPoint.x, 1, screenPoint.z));
        }
    }

    private void onTriggerEnter(Collider collider)                      //Ship + Asteroid collision
    {
        if (collider.gameObject.tag == "Asteroid")
        {
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()                                                       //Ship keybindings
    {
        if (Input.GetKey(KeyCode.A)) Rotate(-1);
        if (Input.GetKey(KeyCode.D)) Rotate(1);
        if (Input.GetKey(KeyCode.W)) Accelerate();
        if (Input.GetKeyDown(KeyCode.Space)) Shot();
    }
}

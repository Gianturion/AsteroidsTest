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
    void Rotate(float direction)
    {
        rigibody.AddTorque(transform.up * rotationVelocity * Time.deltaTime * direction);
        //transform.Rotate(Vector3.up * rotationVelocity * Time.deltaTime * direction);
    }

    void Shot()
    {
        GameObject newShot = Instantiate(shotReference, transform.position, transform.localRotation);
    }

    void Accelerate()
    {
        rigibody.AddForce(transform.forward * acceleration * Time.deltaTime);
        //transform.Translate(Vector3.forward * acceleration * Time.deltaTime);
    }

    void Die()
    {

    }

    void CrossScreen()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) Rotate(-1);
        if (Input.GetKey(KeyCode.D)) Rotate(1);
        if (Input.GetKey(KeyCode.W)) Accelerate();
        if (Input.GetKeyDown(KeyCode.Space)) Shot();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float velocity = 50;
    public Vector3 direction = Vector3.forward;


    void Move()
    {
        transform.Translate(direction * velocity * Time.deltaTime, Space.World);
    }

    void SplitAsteroid()
    {

    }

    void DestroyAsteroid()
    {

    }

    void Die()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

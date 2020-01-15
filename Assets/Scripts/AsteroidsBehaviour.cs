using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsBehaviour : MonoBehaviour
{
    public Transform player;

    public void CreateAsteroid()
    {
        player = FindObjectOfType<Ship>().transform;

        transform.position = player.position + player.right * Random.Range(-30f, 30f) + player.up * Random.Range(-30f, 30f) + player.forward * Random.Range(-30f, 30f);
        transform.rotation = Quaternion.Euler(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
        transform.localScale = new Vector3(Random.Range(0.5f, 3f), Random.Range(0.5f, 3f), Random.Range(0.5f, 3f));

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f)) * 100);
        rb.AddTorque(new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f) * 10));
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 200)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Shot>())
        {
            Destroy(other.gameObject);

            if (transform.localScale.sqrMagnitude > 5)
            {
                SplitAsteroid(transform.localScale / 2, transform.right, transform.position);
                SplitAsteroid(transform.localScale / 2, -transform.right, transform.position);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void SplitAsteroid(Vector3 size, Vector3 position, Vector3 parentPosition)
    {
        GameObject asteroid = GameObject.CreatePrimitive(PrimitiveType.Cube);
        asteroid.AddComponent<AsteroidsBehaviour>().player = player;

        asteroid.transform.parent = GameObject.Find("Map").transform;

        asteroid.transform.position = transform.position + position;
        asteroid.transform.localScale = size;

        Rigidbody rb = asteroid.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddExplosionForce(100, parentPosition, 10);
    }
}

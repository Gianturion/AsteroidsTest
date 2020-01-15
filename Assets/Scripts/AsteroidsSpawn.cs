using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawn : MonoBehaviour
{
    Transform Arena;

    // Start is called before the first frame update
    void Start()
    {
        GameObject m = GameObject.Find("Arena");
        if (m == null)
        {
            m = new GameObject("Arena");
        }
        Arena = m.transform;

        CreateMap();
    }

    void CreateMap()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject asteroid = GameObject.CreatePrimitive(PrimitiveType.Cube);
            asteroid.AddComponent<AsteroidsBehaviour>().CreateAsteroid();

            asteroid.transform.parent = Arena;
        }
    }
}

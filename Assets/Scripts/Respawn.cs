using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3Value spawnPoint;

    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = spawnPoint.value;
        }
    }
}

using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3Value spawnPoint;
    public Vector3Value startPoint;

    private void Awake()
    {
        spawnPoint.value = startPoint.value;
        gameObject.transform.position = startPoint.value;
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = spawnPoint.value;
        }
    }
}

using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3Value spawnPoint;
    public Vector3Value startPoint;

    public delegate void RespawnAction();
    public static event RespawnAction OnRespawn;

    private void Awake()
    {
        spawnPoint.value = startPoint.value;
        gameObject.transform.position = startPoint.value;
    }

    private void Update()
    {
        if (transform.position.y < spawnPoint.value.y - 15)
        {
            transform.position = spawnPoint.value;

            if (OnRespawn != null) OnRespawn();
        }
    }
}

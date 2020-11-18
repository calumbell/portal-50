using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3Value playerSpawnLocation;
    private Vector3 checkpointLocation;

    public delegate void CheckpointAction();
    public static event CheckpointAction OnCheckpointActivated;

    private void Start()
    {
        // Apply offset to respawn location
        checkpointLocation = new Vector3(
            gameObject.transform.position.x + 0,
            gameObject.transform.position.y + 4,
            gameObject.transform.position.z + 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        if (playerSpawnLocation.value == checkpointLocation)
            return;

        playerSpawnLocation.value = checkpointLocation;

        if (OnCheckpointActivated != null)
            OnCheckpointActivated();
    }
}


using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    public Vector3Value playerSpawnLocation;
    private Vector3 checkpointLocation;
    private bool debounce;

    public delegate void CheckpointAction();
    public static event CheckpointAction OnCheckpointActivated;

    private void Start()
    {
        // Apply offset to respawn location
        checkpointLocation = new Vector3(
            gameObject.transform.position.x + 0,
            gameObject.transform.position.y + 4,
            gameObject.transform.position.z + 0);

        debounce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || debounce) return;

        if (playerSpawnLocation.value == checkpointLocation) return;

        playerSpawnLocation.value = checkpointLocation;

        if (OnCheckpointActivated != null) OnCheckpointActivated();

        StartCoroutine(debounceCoroutine());
    }

    IEnumerator debounceCoroutine()
    {
        debounce = true; 
        yield return new WaitForSeconds(3);
        debounce = false;
    }
}


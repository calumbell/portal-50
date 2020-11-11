using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3Value playerSpawnLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerSpawnLocation.value = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y + 4,
                gameObject.transform.position.z);
        }
    }
}

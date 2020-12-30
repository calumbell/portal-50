using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public delegate void GameOverAction();
    public static event GameOverAction OnGameOver;

    public Vector3Value worldSpawn;
    public Vector3Value currentSpawnPoint;

    private bool debounce;

    private void OnEnable()
    {
        debounce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || debounce) return;

        StartCoroutine(GameOverCoroutine(other));

    }

    IEnumerator GameOverCoroutine(Collider player)
    {
        debounce = true;
        if (OnGameOver != null) OnGameOver();
        yield return new WaitForSeconds(10);
        currentSpawnPoint.value = worldSpawn.value;
        player.transform.position = worldSpawn.value;
        debounce = false;
    }
}

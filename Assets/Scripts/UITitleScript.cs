using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UITitleScript : MonoBehaviour
{
    public Text title;

    private void OnEnable()
    {
        Checkpoint.OnCheckpointActivated += CheckpointUpdateMessage;
        GameOver.OnGameOver += GameOverMessage;
    }

    private void OnDisable()
    {
        Checkpoint.OnCheckpointActivated -= CheckpointUpdateMessage;
        GameOver.OnGameOver -= GameOverMessage;
    }

    void CheckpointUpdateMessage()
    {
        if (title == null)return;

        StartCoroutine(CheckpointUpdateMessageCoroutine());
    }

    private IEnumerator CheckpointUpdateMessageCoroutine()
    {
        title.text = "Checkpoint Reached!";
        title.enabled = true;
        title.color = new Color(0, 0.4f, 1);

        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.1f);
            title.enabled = !title.enabled;
            title.color = new Color(
                i / 20.0f,
                0.4f,
                1 - (i / 20.0f));
        }

        title.enabled = false;
        
    }

    private void GameOverMessage()
    {
        if (title == null) return;

        StartCoroutine(GameOverMessageCoroutine());
    }

    private IEnumerator GameOverMessageCoroutine()
    {
        title.enabled = true;
        title.text = "Congradulations!";
        yield return new WaitForSeconds(2.5f);
        title.text = "One more time!";
        yield return new WaitForSeconds(2.5f);
        int countdown = 5;
        while (countdown > 0)
        {
            title.text = countdown.ToString();
            countdown--;
            yield return new WaitForSeconds(1);
        }

        title.enabled = false;
    }
}

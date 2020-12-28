using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UITitleScript : MonoBehaviour
{
    public Text title;

    private void OnEnable()
    {
        Checkpoint.OnCheckpointActivated += CheckpointUpdateMessage;
    }

    private void OnDisable()
    {
        Checkpoint.OnCheckpointActivated -= CheckpointUpdateMessage;
    }

    void CheckpointUpdateMessage()
    {
        if (title == null)return;

        StartCoroutine(CheckpointUpdateMessageCoroutine());
    }

    private IEnumerator CheckpointUpdateMessageCoroutine()
    {
        title.text = "Checkpoint Triggered!";
        title.enabled = true;

        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.1f);
            title.enabled = !title.enabled;
        }

        title.enabled = false;
        
    }
}

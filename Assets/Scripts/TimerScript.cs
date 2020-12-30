using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float currentTime;
    private bool running;

    public Text counterDisplay;

    private void OnEnable()
    {
        if (counterDisplay == null) gameObject.GetComponent<Text>();
        currentTime = 0f;
        counterDisplay.text = currentTime.ToString();
        running = true;

        GameOver.OnGameOver += pauseAndReset;
    }

    private void OnDisable()
    {
        GameOver.OnGameOver -= pauseAndReset;
    }

    void Update()
    {
        if (!running) return;

        UpdateTimer();
    }

    private void pauseAndReset()
    {
        StartCoroutine(resetCoroutine());
    }

    IEnumerator resetCoroutine()
    {
        running = false;
        yield return new WaitForSeconds(10);
        ResetTimer();
        running = true;
    }

    private void ResetTimer()
    {
        currentTime = 0;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        counterDisplay.text = time.ToString();
    }

    private void UpdateTimer()
    {
        currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        counterDisplay.text = time.ToString();
    }
}

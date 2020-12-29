using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image panel;

    public float time;
    public Color colour;

    private void OnEnable()
    {
        Respawn.OnRespawn += FadeInAndOut;
    }

    private void OnDisable()
    {
        Respawn.OnRespawn -= FadeInAndOut;
    }

    void FadeInAndOut()
    {
        StartCoroutine(FadeCoroutine(panel, time, colour));
    }

    private IEnumerator FadeCoroutine(Image panel, float time, Color colour)
    {
        float i = 0;
        while (i < time)
        {
            i += Time.deltaTime;
            panel.color = new Color(colour.r, colour.g, colour.b, i / time);
            yield return null;
        }

        while (i > 0)
        {
            i -= Time.deltaTime;
            panel.color = new Color(colour.r, colour.g, colour.b, i / time);
            yield return null;
        }
    }
}

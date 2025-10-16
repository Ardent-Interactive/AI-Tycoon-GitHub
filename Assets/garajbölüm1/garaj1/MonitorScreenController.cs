using UnityEngine;
using System.Collections;

public class MonitorScreenController : MonoBehaviour
{
    public Texture[] screenImages;
    public float transitionTime = 1f;
    public float displayTime = 3f;
    public Renderer screenRenderer;

    private int currentIndex = 0;
    private Material mat;

    void Start()
    {
        mat = screenRenderer.material;
        StartCoroutine(Slideshow());
    }

    IEnumerator Slideshow()
    {
        while (true)
        {
            Texture next = screenImages[currentIndex];
            yield return StartCoroutine(FadeTo(next));

            currentIndex = (currentIndex + 1) % screenImages.Length;
            yield return new WaitForSeconds(displayTime);
        }
    }

    IEnumerator FadeTo(Texture newTex)
    {
        // Fade out
        for (float t = 0; t < 1; t += Time.deltaTime / transitionTime)
        {
            Color c = mat.color;
            c.a = Mathf.Lerp(1, 0, t);
            mat.color = c;
            yield return null;
        }

        mat.mainTexture = newTex;

        // Fade in
        for (float t = 0; t < 1; t += Time.deltaTime / transitionTime)
        {
            Color c = mat.color;
            c.a = Mathf.Lerp(0, 1, t);
            mat.color = c;
            yield return null;
        }
    }
}

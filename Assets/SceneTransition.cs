using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;  // Nama scene yang ingin dimuat
    public float fadeDuration = 1f;  // Durasi fade
    public float waitTime = 3f;  // Waktu tunggu sebelum pindah scene

    private Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();  // Mengambil komponen Image untuk efek fade
        if (fadeImage != null)
        {
            fadeImage.color = new Color(0f, 0f, 0f, 1f);  // Mulai dengan layar hitam penuh
        }
        StartCoroutine(FadeOutAndChangeScene());
    }

    IEnumerator FadeOutAndChangeScene()
    {
        // Fade out (fade ke transparan)
        yield return StartCoroutine(Fade(1f, 0f));

        // Tunggu beberapa detik
        yield return new WaitForSeconds(waitTime);

        // Fade in (fade ke hitam)
        yield return StartCoroutine(Fade(0f, 1f));

        // Pindah ke scene yang ditentukan
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);  // Mengubah alpha warna hitam
            yield return null;
        }

        fadeImage.color = new Color(0f, 0f, 0f, endAlpha);  // Pastikan alpha selesai pada nilai akhir
    }
}

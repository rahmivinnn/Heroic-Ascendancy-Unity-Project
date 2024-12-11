using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonSceneLoader : MonoBehaviour
{
    public string sceneToLoad;  // Nama scene yang ingin dimuat
    public Button loadButton;  // Tombol yang digunakan untuk memicu pindah scene
    public GameObject loadingScreen;  // GameObject untuk layar loading (bisa berupa UI Panel dengan text/loading bar)

    void Start()
    {
        if (loadButton != null)
        {
            loadButton.onClick.AddListener(OnButtonClick);  // Menambahkan listener untuk tombol
        }

        if (loadingScreen != null)
        {
            loadingScreen.SetActive(false);  // Menyembunyikan layar loading di awal
        }
    }

    void OnButtonClick()
    {
        StartCoroutine(LoadSceneAsync());  // Memulai coroutine untuk load scene
    }

    IEnumerator LoadSceneAsync()
    {
        // Menampilkan layar loading
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        // Memulai proses loading scene secara asinkron
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Tunggu sampai scene selesai loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Setelah loading selesai, sembunyikan layar loading jika ada
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(false);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Fungsi ini akan dipanggil ketika tombol diklik
    public void ExitApplication()
    {
        // Jika sedang dalam editor, Unity tidak bisa keluar aplikasi, gunakan Debug.Log
#if UNITY_EDITOR
        Debug.Log("Exit application called, but it won't close in the editor.");
#else
        // Keluar dari aplikasi jika build selesai
        Application.Quit();
#endif
    }
}
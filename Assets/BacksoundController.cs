using UnityEngine;
using UnityEngine.UI; // Untuk menangani UI seperti tombol

public class BackSoundController : MonoBehaviour
{
    public AudioSource backSound; // Referensi ke AudioSource untuk backsound
    public Button toggleButton;  // Referensi ke Button
    public Text buttonText;      // Referensi ke teks pada tombol

    private bool isPlaying = true; // Status apakah backsound sedang menyala atau tidak

    void Start()
    {
        // Pastikan referensi sudah diatur di Inspector
        if (backSound == null || toggleButton == null || buttonText == null)
        {
            Debug.LogError("Referensi belum diatur dengan benar di Inspector.");
            return;
        }

        // Menambahkan listener ke tombol untuk menangani klik
        toggleButton.onClick.AddListener(ToggleBackSound);

        // Menampilkan teks awal pada tombol
        buttonText.text = "Turn Off BackSound";
    }

    void ToggleBackSound()
    {
        if (isPlaying)
        {
            backSound.Pause(); // Pause backsound
            buttonText.text = "Turn On BackSound"; // Ubah teks tombol
        }
        else
        {
            backSound.Play(); // Mulai backsound
            buttonText.text = "Turn Off BackSound"; // Ubah teks tombol
        }

        isPlaying = !isPlaying; // Toggle status
    }
}
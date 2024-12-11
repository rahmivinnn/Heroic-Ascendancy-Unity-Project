using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Jika menggunakan UI Text
// using TMPro; // Jika menggunakan TextMeshPro

public class TypingEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f; // Kecepatan mengetik
    public string fullText; // Teks lengkap yang ingin ditampilkan
    private string currentText = ""; // Teks yang sedang ditampilkan
    public Text uiText; // Referensi ke UI Text
    // public TextMeshProUGUI uiText; // Jika menggunakan TextMeshPro

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            currentText += letter; // Tambahkan huruf ke teks saat ini
            uiText.text = currentText; // Perbarui UI Text
            yield return new WaitForSeconds(typingSpeed); // Tunggu sebelum menampilkan huruf berikutnya
        }
    }
}
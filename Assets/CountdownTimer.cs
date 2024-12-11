using UnityEngine;
using UnityEngine.UI; // Pastikan untuk menggunakan namespace ini untuk UI
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText; // Drag and drop UI Text di sini dari Inspector
    private float timeRemaining;
    private int currentWave = 1;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        // Set waktu untuk wave 1 (18 menit)
        timeRemaining = 18 * 60; // 18 menit dalam detik

        while (currentWave <= 5)
        {
            while (timeRemaining > 0)
            {
                UpdateCountdownText();
                yield return new WaitForSeconds(1f);
                timeRemaining--;
            }

            // Setelah waktu habis, lanjut ke wave berikutnya
            currentWave++;
            if (currentWave <= 5)
            {
                // Set waktu untuk wave 2 hingga wave 5 (2 menit)
                timeRemaining = 2 * 60; // 2 menit dalam detik
            }
        }

        // Tampilkan pesan selesai
        countdownText.text = "Waves selesai!";
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
using UnityEngine;

public class AutoMoveUpDown : MonoBehaviour
{
    public float speed = 0.5f; // Kecepatan gerakan karakter
    public float moveRange = 1.0f; // Jarak maksimal ke atas dan ke bawah

    private Vector3 startPosition; // Posisi awal karakter
    private bool movingUp = true; // Apakah karakter sedang bergerak ke atas

    void Start()
    {
        // Simpan posisi awal karakter
        startPosition = transform.position;
    }

    void Update()
    {
        // Hitung posisi target berdasarkan arah gerakan
        float newY = transform.position.y + (movingUp ? speed : -speed) * Time.deltaTime;

        // Periksa apakah karakter mencapai batas atas atau bawah
        if (movingUp && newY >= startPosition.y + moveRange)
        {
            newY = startPosition.y + moveRange;
            movingUp = false; // Ganti arah ke bawah
        }
        else if (!movingUp && newY <= startPosition.y - moveRange)
        {
            newY = startPosition.y - moveRange;
            movingUp = true; // Ganti arah ke atas
        }

        // Terapkan posisi baru ke karakter
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
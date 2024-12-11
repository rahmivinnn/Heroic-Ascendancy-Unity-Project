using UnityEngine;

public class TapToSpawnFire : MonoBehaviour
{
    // Prefab gambar api yang dimasukkan melalui Inspector
    public GameObject firePrefab;

    // Kamera utama untuk konversi posisi layar ke dunia
    private Camera mainCamera;

    void Start()
    {
        // Mendapatkan kamera utama
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Mengecek jika layar disentuh
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SpawnFireAtTouchPosition(Input.GetTouch(0).position);
        }
    }

    void SpawnFireAtTouchPosition(Vector2 touchPosition)
    {
        // Mengubah posisi layar menjadi posisi dunia
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, mainCamera.nearClipPlane + 1));

        // Membuat instance gambar api di posisi dunia
        Instantiate(firePrefab, worldPosition, Quaternion.identity);
    }
}

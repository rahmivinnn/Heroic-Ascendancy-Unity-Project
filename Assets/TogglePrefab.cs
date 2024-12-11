using UnityEngine;
using UnityEngine.UI; // Untuk UI

public class TogglePrefab : MonoBehaviour
{
    // Referensi ke prefab atau objek yang akan di-toggle
    public GameObject prefab;

    // Tombol untuk klik (opsional, dapat dihubungkan dari Inspector)
    public Button toggleButton;

    // Status awal prefab (aktif atau tidak)
    private bool isPrefabActive;

    void Start()
    {
        // Pastikan prefab tidak null
        if (prefab == null)
        {
            Debug.LogError("Prefab belum diatur!");
            return;
        }

        // Inisialisasi status awal prefab
        isPrefabActive = prefab.activeSelf;

        // Tambahkan listener ke tombol jika disediakan
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(TogglePrefabVisibility);
        }
    }

    // Fungsi untuk toggle prefab
    public void TogglePrefabVisibility()
    {
        if (prefab != null)
        {
            // Ubah status aktif prefab
            isPrefabActive = !isPrefabActive;
            prefab.SetActive(isPrefabActive);
        }
    }
}

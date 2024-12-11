using UnityEngine;
using TMPro; // Pastikan TextMeshPro sudah di-import ke dalam proyek

public class Floating3DText : MonoBehaviour
{
    public string displayText = "Hello, Unity!";
    public Font font;
    public Color textColor = Color.white;
    public Color shadowColor = Color.black;
    public Vector3 shadowOffset = new Vector3(0.1f, -0.1f, 0);

    private GameObject textObject;
    private GameObject shadowObject;

    void Start()
    {
        // Buat objek teks utama
        textObject = new GameObject("MainText");
        textObject.transform.SetParent(transform);
        textObject.transform.localPosition = Vector3.zero;

        TextMeshPro textMeshPro = textObject.AddComponent<TextMeshPro>();
        textMeshPro.text = displayText;
        textMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF"); // Pastikan font TextMeshPro tersedia
        textMeshPro.color = textColor;
        textMeshPro.fontSize = 3;
        textMeshPro.alignment = TextAlignmentOptions.Center;

        // Buat objek teks untuk shadow
        shadowObject = new GameObject("ShadowText");
        shadowObject.transform.SetParent(transform);
        shadowObject.transform.localPosition = shadowOffset;

        TextMeshPro shadowMeshPro = shadowObject.AddComponent<TextMeshPro>();
        shadowMeshPro.text = displayText;
        shadowMeshPro.font = textMeshPro.font;
        shadowMeshPro.color = shadowColor;
        shadowMeshPro.fontSize = textMeshPro.fontSize;
        shadowMeshPro.alignment = textMeshPro.alignment;
    }
}
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float jumpForce = 5f;          // Kekuatan lompatan
    public float moveSpeed = 3f;         // Kecepatan gerak horizontal
    public KeyCode jumpKey = KeyCode.Space;    // Tombol untuk lompat
    public KeyCode attackKey = KeyCode.F;      // Tombol untuk menyerang

    private bool isGrounded = true;      // Mengecek apakah karakter di tanah
    private Rigidbody2D rb;             // Referensi ke Rigidbody2D
    private SpriteRenderer spriteRenderer;

    // Sprites untuk idle dan attack (atau gunakan warna untuk contoh sederhana)
    public Color idleColor = Color.white;
    public Color attackColor = Color.red;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer tidak ditemukan di GameObject ini.");
        }
    }

    void Update()
    {
        // Gerakan Horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));

        // Lompat
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // Serangan
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Ubah warna menjadi merah untuk mensimulasikan serangan
        if (spriteRenderer != null)
        {
            spriteRenderer.color = attackColor;
            Invoke("ResetColor", 0.2f); // Kembali ke warna normal setelah 0.2 detik
        }

        // Tambahkan logika serangan di sini (misalnya deteksi musuh, menembakkan peluru, dll.)
        Debug.Log("Attack! Peluru atau logika serangan bisa ditambahkan di sini.");
    }

    void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = idleColor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Mengecek apakah karakter menyentuh tanah
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
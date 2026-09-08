using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [Header("Cài đặt Di chuyển")]
    public float speed = 3f;                   // Tốc độ rơi

    [Header("Hiệu ứng & Âm thanh")]
    public GameObject explosionPrefab;        // Prefab hiệu ứng nổ (Particle System)

    void Update() 
    {
        // Tự động rơi xuống theo trục Y
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        // Tự hủy khi rơi qua mép dưới màn hình (Y < -6)
        if (transform.position.y < -6f) 
        {
            Destroy(gameObject);
        }
    }

    // Hàm tự động gọi khi có vật thể dạng Trigger đi vào vùng va chạm
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        AudioManager.Instance.PlayExplosionSound();
        // Trường hợp 1: Đạn bắn trúng Enemy
        if (collision.CompareTag("Bullet")) 
        {
            Die();
            
            // Cộng điểm thông qua GameManager
            if (GameManager.instance != null) 
            {
                GameManager.instance.AddScore(10);
            }

            Destroy(collision.gameObject); // Xóa viên đạn
            Destroy(gameObject);           // Xóa Enemy này
        }
        
        // Trường hợp 2: Enemy đâm vào Player
        if (collision.CompareTag("Player")) 
        {
            Die();

            // Gọi màn hình Game Over
            if (GameManager.instance != null) 
            {
                GameManager.instance.GameOver();
            }

            Destroy(collision.gameObject); // Xóa Player
            Destroy(gameObject);           // Xóa Enemy
        }
    }

    // Hàm xử lý chung khi Enemy bị tiêu diệt
    void Die() 
    {
        // 1. Tạo hiệu ứng nổ (Particle System)
        if (explosionPrefab != null) 
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // 2. Phát âm thanh nổ thông qua AudioManager (nếu có)
        if (AudioManager.Instance != null) 
        {
            AudioManager.Instance.PlayExplosionSound();
        }
    }
}
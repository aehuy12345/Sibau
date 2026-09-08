using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [Header("Cài đặt Di chuyển")]
    public float moveSpeed = 8f;         // Tốc độ di chuyển
    private Vector2 screenBounds;        // Luân lưu tọa độ mép màn hình

    [Header("Cài đặt Bắn")]
    public GameObject bulletPrefab;      // Kéo Prefab đạn vào đây
    public Transform firePoint;          // Vị trí đạn nòng súng thoát ra

    void Start() 
    {
        // Tính toán khoảng cách tối đa từ tâm ra viền màn hình dựa vào Main Camera
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update() 
    {
        // 1. Nhận đầu vào từ phím A/D hoặc Mũi tên Trái/Phải (-1 đến 1)
        float moveInput = Input.GetAxisRaw("Horizontal");

        // 2. Di chuyển Player theo chiều ngang
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

        // 3. Giới hạn (Clamp) tọa độ X trong vùng nhìn thấy của Camera
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + 0.5f, screenBounds.x - 0.5f);
        transform.position = viewPos;

        // 4. Nhấn phím Space để sinh đạn
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        AudioManager.Instance.PlayShootSound();
        if (bulletPrefab != null) 
        {
            // Xác định vị trí bắn: Nếu không gán firePoint thì lấy vị trí Player
            Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        }
    }
}
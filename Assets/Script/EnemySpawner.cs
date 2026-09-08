using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject enemyPrefab;    // Kéo Prefab Enemy vào đây
    public float spawnInterval = 1.5f; // Thời gian lặp lại việc tạo kẻ địch (giây)
    public float xBound = 2.5f;        // Giới hạn sinh ngẫu nhiên theo chiều ngang

    void Start() 
    {
        // Gọi hàm SpawnEnemy liên tục: Bắt đầu sau 1 giây, lặp lại mỗi spawnInterval giây
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy() 
    {
        if (enemyPrefab != null) 
        {
            // Tạo tọa độ X ngẫu nhiên từ -xBound đến +xBound
            float randomX = Random.Range(-xBound, xBound);
            Vector3 spawnPos = new Vector3(randomX, 6f, 0f);

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
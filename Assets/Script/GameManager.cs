using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour 
{
    // Khởi tạo Singleton để gọi GameManager từ bất kỳ đâu
    public static GameManager instance;

    [Header("Giao diện UI (TextMeshPro)")]
    public TMP_Text scoreText;        // Dùng TMP_Text thay vì Text thông thường
    public GameObject gameOverPanel;
    public GameObject startPanel;     // Bảng UI "Tap to Play"

    private int score = 0;
    private bool isGameStarted = false; // Biến kiểm tra xem game đã bắt đầu chưa

    void Awake() 
    {
        // Đảm bảo chỉ có 1 instance của GameManager
        if (instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start() 
    {
        // Khi mới vào game: Dừng thời gian và hiển thị bảng Tap to Play
        Time.timeScale = 0f;
        if (startPanel != null) 
        {
            startPanel.SetActive(true);
        }
    }

    void Update() 
    {
        // Nếu game chưa bắt đầu và người chơi nhấn phím bất kỳ hoặc click chuột/chạm màn hình
        if (!isGameStarted && (Input.anyKeyDown || Input.GetMouseButtonDown(0))) 
        {
            StartGame();
        }
    }

    // Hàm bắt đầu trò chơi
    public void StartGame() 
    {
        isGameStarted = true;
        Time.timeScale = 1f; // Cho phép thời gian trong game chạy lại bình thường

        if (startPanel != null) 
        {
            startPanel.SetActive(false); // Ẩn màn hình Tap to Play
        }
    }

    // Hàm thêm điểm số
    public void AddScore(int amount) 
    {
        score += amount;
        if (scoreText != null) 
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Hàm gọi khi Player chết
    public void GameOver() 
    {
        if (gameOverPanel != null) 
        {
            gameOverPanel.SetActive(true); // Hiển thị bảng Game Over
        }
        Time.timeScale = 0f; // Dừng toàn bộ thời gian trong game
    }

    // Hàm tải lại Game khi nhấn nút Replay
    public void ReplayGame() 
    {
        Time.timeScale = 1f; // Trả lại thời gian bình thường trước khi Load lại Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
using UnityEngine;

public class BackgroundScroll : MonoBehaviour 
{
    public float scrollSpeed = 0.3f; // Tốc độ cuộn
    private MeshRenderer meshRenderer;

    void Start() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update() 
    {
        // Thay đổi Offset của Texture theo thời gian để tạo cảm giác di chuyển
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        meshRenderer.material.mainTextureOffset = offset;
    }
}
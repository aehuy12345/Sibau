using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f; // Tốc độ đạn bay

    void Update()
    {
        // Thêm Space.World để đạn luôn bay lên theo trục Y của màn hình (thế giới)
        // bất kể bản thân viên đạn hoặc FirePoint có bị xoay góc nào.
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        Debug.Log("Vi tri Y hiện tại của đạn: " + transform.position.y);
        // Kiểm tra nếu đạn bay vượt quá mép trên màn hình (Y > 6) thì xóa
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
}
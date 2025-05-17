using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    void Start() {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speedX, speedY);
    }
}

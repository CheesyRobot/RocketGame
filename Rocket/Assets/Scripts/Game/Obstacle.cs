using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private bool random;
    [SerializeField] public int minHeight;
    [SerializeField] public int maxHeight;
    void Start() {
        if (random) {
            speedX = Random.Range(-speedX, speedX);
            speedY = Random.Range(-speedY, speedY);
        }
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speedX, speedY);
    }
}

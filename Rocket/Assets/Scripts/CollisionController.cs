using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "AirBalloon") {
            player.RestoreHealth(-10);
        }
    }
}

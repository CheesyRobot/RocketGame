using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private float damageMultiplier;
    //[SerializeField] private Player player;
    [SerializeField] private LayerMask CollidableMask;
    private bool onCooldown = false;
    private float timer = 0;
    private void OnCollisionEnter2D(Collision2D collision) {
        // if (collision.gameObject.layer == collisionLayer)
        if (!onCooldown && collision.gameObject.name != "Ground")
        {
            float damage = (GetComponent<Rigidbody2D>().linearVelocity - collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity).magnitude;
            GetComponent<Player>().RestoreHealth(-damage * damageMultiplier);
            StartCoroutine(hitCooldown(1));
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (timer <= 1f) {
        timer += Time.deltaTime;
        }
        else {
            timer = 0;
            StartCoroutine(DisableCollision(1f));
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        timer = 0;
    }

    private IEnumerator hitCooldown(float duration) {
        onCooldown = true;
        yield return new WaitForSeconds(duration);
        onCooldown = false;
    }

    public void SetHitCooldown(float duration) {
        StartCoroutine(hitCooldown(duration));
    }

    IEnumerator DisableCollision(float duration) {
        GetComponent<Rigidbody2D>().excludeLayers = CollidableMask;
        yield return new WaitForSeconds(duration);
        GetComponent<Rigidbody2D>().excludeLayers = 0;
    }
}

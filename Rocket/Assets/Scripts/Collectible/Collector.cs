using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius;
    [SerializeField] private float coinRadius;
    [SerializeField] private LayerMask interactionMask;

    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(interactionPoint.position, interactionRadius, interactionMask);
        if (collider != null)
        {
            var interactable = collider.GetComponent<ICollectible>();
            if (interactable != null)
            {
                interactable.Collect(this);
            }
        }
        
        // separate check for coin magnet
        collider = Physics2D.OverlapCircle(interactionPoint.position, coinRadius, interactionMask);
        if (collider != null)
        {
            var interactable = collider.GetComponent<Coin>();
            if (interactable != null)
            {
                interactable.Collect(this);
            }
        }
    }

    public void SetRadius(float radius) {
        coinRadius = radius;
    }

    public void ResetRadius() {
        coinRadius = interactionRadius;
    }
}

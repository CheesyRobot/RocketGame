using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactionMask;

    private Collider2D collider;
    void Update()
    {
        collider = Physics2D.OverlapCircle(interactionPoint.position, interactionRadius, interactionMask);
        if (collider != null)
        {
            var interactable = collider.GetComponent<ICollectible>();
            if (interactable != null)
            {
                interactable.Collect(this);
            }
        }
    }
}

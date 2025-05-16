using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField] private int amount;
    public bool Collect(Collector collector) {
        Destroy(gameObject);
        return true;
    }
}

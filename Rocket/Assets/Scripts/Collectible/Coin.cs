using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField] private int amount;
    public bool Collect(Collector collector) {
        collector.GetComponent<Player>().AddCoins(amount);
        Destroy(gameObject);
        return true;
    }

    public void SetValues(int amount) {
        this.amount = amount;
    }
}

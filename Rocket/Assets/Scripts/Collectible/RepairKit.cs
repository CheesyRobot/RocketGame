using UnityEngine;

public class RepairKit : MonoBehaviour, ICollectible
{
    [SerializeField] private int amount;
    public bool Collect(Collector collector) {
        collector.GetComponent<Player>().RestoreHealth(amount);
        Destroy(gameObject);
        return true;
    }
}

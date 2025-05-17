using UnityEngine;

public class Magnet : MonoBehaviour, ICollectible
{
    [SerializeField] private float duration, radius;
    public bool Collect(Collector collector) {
        collector.GetComponent<Player>().ActivateMagnet(duration, radius);
        Destroy(gameObject);
        return true;
    }

    public void SetValues(float duration, float radius) {
        this.duration = duration;
        this.radius = radius;
    }
}

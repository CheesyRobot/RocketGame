using UnityEngine;

public class Forcefield : MonoBehaviour, ICollectible
{
    [SerializeField] private float duration;
    public bool Collect(Collector collector) {
        collector.GetComponent<Player>().ActivateForcefield(duration);
        Destroy(gameObject);
        return true;
    }

    public void SetValues(float duration) {
        this.duration = duration;
    }
}

using UnityEngine;

public class SpeedBoost : MonoBehaviour, ICollectible
{
    [SerializeField] private float duration, acceleration;
    public bool Collect(Collector collector) {
        // collector.GetComponent<Player>().ActivateSpeedBoost(duration, acceleration);
        collector.GetComponent<Player>().AddSpeedBoost();
        Destroy(gameObject);
        return true;
    }

    public void SetValues(float duration, float acceleration) {
        this.duration = duration;
        this.acceleration = acceleration;
    }
}

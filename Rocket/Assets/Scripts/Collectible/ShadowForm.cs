using UnityEngine;

public class ShadowForm : MonoBehaviour, ICollectible
{
    [SerializeField] private int duration;
    public bool Collect(Collector collector) {
        collector.GetComponent<Player>().ActivateShadowForm(duration);
        Destroy(gameObject);
        return true;
    }
    
    public void SetValues(int duration) {
        this.duration = duration;
    }
}

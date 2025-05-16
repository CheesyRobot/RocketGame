using UnityEngine;

public class DisplayBar : MonoBehaviour
{
    public float width, height;
    [SerializeField] RectTransform bar;

    public void SetValue(float value, float maxValue) {
        float newHeight = (value / maxValue) * height;
        bar.sizeDelta = new Vector2(width, newHeight);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
public class UpgradeDataObject : ScriptableObject
{
    public string Name;
    public string Description;
    public int cost;
    public int level;
    public bool isSoldOut;
    public float[] Values;
    public int[] Costs;
    public int maxLevel;
}

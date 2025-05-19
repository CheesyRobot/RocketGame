using UnityEngine;

public class SelectSpawnStrategy : MonoBehaviour
{
    [SerializeField] private ItemSpawning itemSpawner;
    [SerializeField] private HeightSpawner heightSpawner1;
    [SerializeField] private TimeSpawner timeSpawner2;
    [SerializeField] private ProbabilitySpawner probabilitySpawner3;
    public int strategyNumber;
    void Start()
    {
        switch (strategyNumber) {
            case 1:
                itemSpawner.SelectSpawnMethod(heightSpawner1);
                break;
            case 2:
                itemSpawner.SelectSpawnMethod(timeSpawner2);
                break;
            default:
                itemSpawner.SelectSpawnMethod(probabilitySpawner3);
                break;
        }
    }
}

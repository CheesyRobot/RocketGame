using UnityEngine;

public class ItemSpawning : MonoBehaviour
{
    [SerializeField] private Spawner strategy;

    // void Start()
    // {
    //     SelectSpawnMethod(strategy);
    // }
    void Update()
    {
        DoOperation();
    }

    public void SelectSpawnMethod(Spawner strategy)
    {
    this.strategy = strategy;
    }
    public void DoOperation()
    {
    strategy.SpawnItem();
    }


}

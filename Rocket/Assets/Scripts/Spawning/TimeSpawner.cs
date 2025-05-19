using System.Collections;
using UnityEngine;

public class TimeSpawner : MonoBehaviour, Spawner
{
    [SerializeField] private ResourceFactory resourceFactory;
    [SerializeField] private PowerUpFactory powerupFactory;
    public GameObject[] obstacles;
    public Player player;
    private float clock = 0;
    public float duration;

    public void SpawnItem() {
        if (clock <= duration)
        {
            clock += Time.deltaTime;
        }
        if (clock > duration) {
            clock = 0;
            int randomIndex = Random.Range(0, obstacles.Length);
            resourceFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 8, 10, player.transform));
            resourceFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 16, 18, player.transform));
            powerupFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 8, 18, player.transform));
            Instantiate(obstacles[randomIndex], MyFuncs.RandomPosition(10, 10, 8, 18, player.transform), Quaternion.identity);
        }
        
    }

    // void Update() {
    //     // if (Input.GetKeyDown(KeyCode.Space))
    //         // SpawnItem();
    //     if (clock <= duration)
    //     {
    //         clock += Time.deltaTime;
    //     }
    //     if (clock > duration) {
    //         clock = 0;
    //         this.SpawnItem();
    //     }
        
    // }
    // public void SpawnItem() {
    //     int randomIndex = Random.Range(0, obstacles.Length);
    //     resourceFactory.CreateProduct(RandomPosition(10, 10, 8, 10));
    //     resourceFactory.CreateProduct(RandomPosition(10, 10, 16, 18));
    //     powerupFactory.CreateProduct(RandomPosition(10, 10, 8, 18));
    //     Instantiate(obstacles[randomIndex], RandomPosition(10, 10, 8, 18), Quaternion.identity);
    // }
}

using System;
using UnityEngine;

public class HeightSpawner : MonoBehaviour, Spawner
{
    [SerializeField] private ResourceFactory resourceFactory;
    [SerializeField] private PowerUpFactory powerupFactory;
    public GameObject[] obstacles;
    public Player player;
    public int height;
    private int spawnedHeight = -1;

    void Update() {
        //&& Math.Abs(player.gameObject.GetComponent<Rigidbody2D>().position.y - player.heightScore) <= 0.01
        
        
    }
    public void SpawnItem() {
        int currentHeight = (int) player.gameObject.GetComponent<Rigidbody2D>().position.y;
        if (currentHeight % height == 0 && currentHeight != spawnedHeight) {
            spawnedHeight = currentHeight;
            int randomIndex = UnityEngine.Random.Range(0, obstacles.Length);
            resourceFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 8, 10, player.transform));
            resourceFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 16, 18, player.transform));
            powerupFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 8, 18, player.transform));
            Instantiate(obstacles[randomIndex], MyFuncs.RandomPosition(10, 10, 8, 18, player.transform), Quaternion.identity);
        }
    }

    // void Update() {
    //     //&& Math.Abs(player.gameObject.GetComponent<Rigidbody2D>().position.y - player.heightScore) <= 0.01
    //     int currentHeight = (int) player.gameObject.GetComponent<Rigidbody2D>().position.y;
    //     if (currentHeight % height == 0 && currentHeight != spawnedHeight) {
    //         spawnedHeight = currentHeight;
    //         this.SpawnItem();
    //     }
        
    // }
    // public void SpawnItem() {
    //     int randomIndex = UnityEngine.Random.Range(0, obstacles.Length);
    //     resourceFactory.CreateProduct(RandomPosition(10, 10, 8, 10));
    //     resourceFactory.CreateProduct(RandomPosition(10, 10, 16, 18));
    //     powerupFactory.CreateProduct(RandomPosition(10, 10, 8, 18));
    //     Instantiate(obstacles[randomIndex], RandomPosition(10, 10, 10, 25), Quaternion.identity);
    // }

    private Vector3 RandomPosition(int x1, int x2, int y1, int y2) {
        Vector3 pos = player.transform.position;
        return new Vector3(
            UnityEngine.Random.Range(pos.x - x1, pos.x + x2),
            UnityEngine.Random.Range(pos.y + y1, pos.y + y2),
            pos.z
        );
    }
}

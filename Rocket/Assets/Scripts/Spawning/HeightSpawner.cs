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

    public void SpawnItem() {
        int currentHeight = (int) player.gameObject.GetComponent<Rigidbody2D>().position.y;
        if (currentHeight % height == 0 && currentHeight != spawnedHeight) {
            spawnedHeight = currentHeight;
            resourceFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 8, 10, player.transform));
            resourceFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 16, 18, player.transform));
            powerupFactory.CreateProduct(MyFuncs.RandomPosition(10, 10, 8, 18, player.transform));
            bool success = false;
            int counter = 0;
            while (!success && counter < 5) {
                int randomIndex = UnityEngine.Random.Range(0, obstacles.Length);
                Obstacle ob = obstacles[randomIndex].GetComponent<Obstacle>();
                if (player.transform.position.y >= ob.minHeight && player.transform.position.y <= ob.maxHeight) {
                    Instantiate(obstacles[randomIndex], MyFuncs.RandomPosition(10, 10, 8, 18, player.transform), Quaternion.identity);
                    success = true;
                }
                counter++;
            }
        }
    }
}

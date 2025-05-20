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

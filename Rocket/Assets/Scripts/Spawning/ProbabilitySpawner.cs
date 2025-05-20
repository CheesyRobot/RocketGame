using UnityEngine;

public class ProbabilitySpawner : MonoBehaviour, Spawner
{
    [SerializeField] private ResourceFactory resourceFactory;
    [SerializeField] private PowerUpFactory powerupFactory;
    public GameObject[] obstacles;
    public Player player;
    public float probability;

    public void SpawnItem() {
        if (Random.Range(0f, 1f) <= probability) {
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

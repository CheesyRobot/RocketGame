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

    void Update() {
        // if (Input.GetKeyDown(KeyCode.Space))
            // SpawnItem();
        if (clock <= duration)
        {
            clock += Time.deltaTime;
        }
        if (clock > duration) {
            clock = 0;
            SpawnItem();
        }
        
    }
    public void SpawnItem() {
        int randomIndex = Random.Range(0, obstacles.Length);
        resourceFactory.CreateProduct(RandomPosition(10, 10, 8, 10));
        resourceFactory.CreateProduct(RandomPosition(10, 10, 16, 18));
        powerupFactory.CreateProduct(RandomPosition(10, 10, 8, 18));
        Instantiate(obstacles[randomIndex], RandomPosition(10, 10, 8, 18), Quaternion.identity);
    }

    private Vector3 RandomPosition(int x1, int x2, int y1, int y2) {
        Vector3 pos = player.transform.position;
        return new Vector3(
            Random.Range(pos.x - x1, pos.x + x2),
            Random.Range(pos.y + y1, pos.y + y2),
            pos.z
        );
    }
}

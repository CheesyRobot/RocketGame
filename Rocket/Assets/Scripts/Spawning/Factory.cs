using UnityEngine;

public class Factory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// public interface CollectibleFactory
// {
//     public abstract ICollectible CreateProduct(Vector3 location);
// }
// class ResourceFactory : MonoBehaviour, CollectibleFactory
// {
//     public GameObject[] resources;

//     public ICollectible CreateProduct(Vector3 location)
//     {
//         int randomIndex = Random.Range(0, resources.Length);
//         GameObject newObject = Instantiate(resources[randomIndex], location, Quaternion.identity);
//         ICollectible collectible = newObject.GetComponent<ICollectible>();
//         if (newObject.GetComponent<FuelPackage>() != null) {
//             newObject.GetComponent<FuelPackage>().SetValues(Random.Range(1, 4) * 10);
//         }
//         if (newObject.GetComponent<Coin>() != null) {
//             newObject.GetComponent<Coin>().SetValues(Random.Range(5, 11) * 10);
//         }
//         if (newObject.GetComponent<RepairKit>() != null) {
//             newObject.GetComponent<RepairKit>().SetValues(Random.Range(5, 11) * 10);
//         }
//         return collectible;
//     }
// }
// class PowerUpFactory : MonoBehaviour, CollectibleFactory
// {
//     public GameObject[] powerups;
//     public ICollectible CreateProduct(Vector3 location)
//     {
//         int randomIndex = Random.Range(0, powerups.Length);
//         GameObject newObject = Instantiate(powerups[randomIndex], location, Quaternion.identity);
//         ICollectible collectible = newObject.GetComponent<ICollectible>();
//         return collectible;
//     }
// }

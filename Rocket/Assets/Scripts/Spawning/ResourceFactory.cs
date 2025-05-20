using UnityEngine;

public class ResourceFactory : MonoBehaviour, ICollectibleFactory
{
    public GameObject[] resources;

    public ICollectible CreateProduct(Vector3 location)
    {
        int randomIndex = Random.Range(0, resources.Length);
        GameObject newObject = Instantiate(resources[randomIndex], location, Quaternion.identity);
        ICollectible collectible = newObject.GetComponent<ICollectible>();
        newObject.GetComponent<FuelPackage>()?.SetValues(Random.Range(1, 4) * 20);
        newObject.GetComponent<Coin>()?.SetValues(Random.Range(5, 11) * 10);
        newObject.GetComponent<RepairKit>()?.SetValues(Random.Range(5, 11) * 10);
        return collectible;
    }
}

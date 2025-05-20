using UnityEngine;

public class PowerUpFactory : MonoBehaviour, ICollectibleFactory
{
    public GameObject[] powerups;
    public ICollectible CreateProduct(Vector3 location)
    {
        int randomIndex = Random.Range(0, powerups.Length);
        GameObject newObject = Instantiate(powerups[randomIndex], location, Quaternion.identity);
        ICollectible collectible = newObject.GetComponent<ICollectible>();
        newObject.GetComponent<SpeedBoost>()?.SetValues(Random.Range(1, 4), 0.2f);
        newObject.GetComponent<Forcefield>()?.SetValues(Random.Range(3, 6) * 5);
        newObject.GetComponent<Magnet>()?.SetValues(Random.Range(2, 4) * 5, 4);
        newObject.GetComponent<ShadowForm>()?.SetValues(Random.Range(2, 4) * 5);
        return collectible;
    }
}

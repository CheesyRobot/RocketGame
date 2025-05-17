using UnityEngine;

public interface ICollectibleFactory
{
    public abstract ICollectible CreateProduct(Vector3 location);
}

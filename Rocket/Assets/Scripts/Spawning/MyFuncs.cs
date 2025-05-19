using UnityEngine;

public class MyFuncs
{
    public static Vector3 RandomPosition(int x1, int x2, int y1, int y2, Transform transform) {
        Vector3 pos = transform.position;
        return new Vector3(
            Random.Range(pos.x - x1, pos.x + x2),
            Random.Range(pos.y + y1, pos.y + y2),
            pos.z
        );
    }
}

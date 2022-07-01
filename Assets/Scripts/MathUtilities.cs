using UnityRandom = UnityEngine.Random;
using UnityEngine;

public static class MathUtilities
{
    public static Vector3 Random(Vector3 min, Vector3 max, bool round = false)
    {
        if (round) return new Vector3((int)UnityRandom.Range(min.x, max.x),
                                      (int)UnityRandom.Range(min.y, max.y),
                                      (int)UnityRandom.Range(min.z, max.z));

        return new Vector3(UnityRandom.Range(min.x, max.x),
                           UnityRandom.Range(min.y, max.y),
                           UnityRandom.Range(min.z, max.z));
    }
}
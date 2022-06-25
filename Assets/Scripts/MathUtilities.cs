using UnityRandom = UnityEngine.Random;
using UnityEngine;

public static class MathUtilities
{
    public static void Random(this ref Vector3 myVector, Vector3 min, Vector3 max)
    {
        myVector = new Vector3(UnityRandom.Range(min.x, max.x),
                               UnityRandom.Range(min.y, max.y),
                               UnityRandom.Range(min.z, max.z));
    }
}

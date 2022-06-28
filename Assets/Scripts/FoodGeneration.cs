using UnityEngine;
using UnityEngine.Events;

public class FoodGeneration : MonoBehaviour
{
    public static int Score;

    private Vector3 minRange = new Vector3(-16, 8, 0);
    private Vector3 maxRange = new Vector3(16, -8, 0);
    private Vector3 eatPosition;

    [SerializeField] private GameObject foodPrefab;

    public static UnityEvent Eating = new UnityEvent();


    private void Start()
    {
        MathUtilities.Random(ref eatPosition, minRange, maxRange);
        foodPrefab.transform.position = eatPosition;
        Score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MathUtilities.Random(ref eatPosition, minRange, maxRange);
        foodPrefab.transform.position = eatPosition;
        Score++;
        Debug.Log("Eating " + Score);
        Eating?.Invoke();
    }
}

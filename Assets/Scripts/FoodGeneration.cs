using UnityEngine;
using UnityEngine.Events;

public class FoodGeneration : MonoBehaviour
{
    public static int Score;

    private Vector3 minRange = new Vector3(-16, 8, 0);
    private Vector3 maxRange = new Vector3(16, -8, 0);

    [SerializeField] private GameObject foodPrefab;

    public static UnityEvent Eating = new UnityEvent();


    private void Start()
    {
        ChangeFoodPosition();
        Score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeFoodPosition();
        Score++;
        Debug.Log("Eating " + Score);
        Eating?.Invoke();
    }

    private void ChangeFoodPosition()
    {
        foodPrefab.transform.position = MathUtilities.Random(minRange, maxRange, true);
    }
}
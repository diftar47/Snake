using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject snakeHead;
    [SerializeField] private GameObject snakeTailPrefab;

    [SerializeField] private float speed = 0.4f;

    private List<GameObject> segments = new List<GameObject>();

    private void Start()
    {
        //FoodGeneration.Eating.AddListener(AddTail);
        segments.Add(snakeHead);
        StartCoroutine(Move());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            snakeHead.transform.Rotate(Vector3.forward, 90);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            snakeHead.transform.Rotate(-Vector3.forward, 90);
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].transform.position = segments[i -1].transform.position;
            }
            snakeHead.transform.Translate(Vector3.up * 1);
            yield return new WaitForSeconds(speed);
        }
    }

    IEnumerator AddTail()
    {
        GameObject lastSegment = Instantiate(snakeTailPrefab);
        lastSegment.transform.position = segments[segments.Count - 1].transform.position;
        yield return new WaitForSeconds(speed);
        segments.Add(lastSegment);
    }

    public void ResetState()
    {
        snakeHead.transform.position = Vector3.one;
        // Start at 1 to skip destroying the head
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i]);
        }
        // Clear the list but add back this as the head
        segments.Clear();
        segments.Add(snakeHead);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            StartCoroutine(AddTail());
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            ResetState();
        }
    }

}

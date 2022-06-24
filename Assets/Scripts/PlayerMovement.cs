using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private GameObject snakeHead;
    [SerializeField]private GameObject snakeTailPrefab;

    private void Start()
    {
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
        snakeHead.transform.Translate(Vector3.up * 1);
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(Move());
    }
}

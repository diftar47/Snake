using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallTriger : MonoBehaviour
{
    public static UnityEvent DeadEvent = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeadEvent?.Invoke();
        Time.timeScale = 0;
        Debug.Log("Dead");
    }
}

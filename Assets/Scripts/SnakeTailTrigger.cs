using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeTailTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colider)
    {
        WallTriger.DeadEvent?.Invoke();
        Time.timeScale = 0;
    }
}

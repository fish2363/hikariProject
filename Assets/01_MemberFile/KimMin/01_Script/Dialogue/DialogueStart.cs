using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueStart : MonoBehaviour
{
    public UnityEvent DialogueEvent;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.gameObject.SetActive(false);
            DialogueEvent?.Invoke();
        }
    }
}

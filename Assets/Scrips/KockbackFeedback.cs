using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KockbackFeedback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgbd;
    [SerializeField] private float strenght = 16, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position-sender.transform.position).normalized;
        rgbd.AddForce(direction * strenght, ForceMode2D.Impulse);
        StartCoroutine(Reset());

    }

    private IEnumerator Reset()
    { 
        yield return new WaitForSeconds(delay);
        rgbd.velocity = Vector3.zero;
        OnDone?.Invoke();
    }
}

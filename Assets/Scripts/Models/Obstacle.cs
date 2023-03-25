using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ApplyDamage))]
public class Obstacle : MonoBehaviour
{
    public UnityEvent events;
    public float force = 10f;

    [SerializeField]
    private ApplyDamage applyDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (events != null)
        {
            events?.Invoke();
        }
        if (applyDamage != null)
        {
            Character character = collision.gameObject.GetComponent<Character>();
            applyDamage.ApplyDamageToCharacter(character);
        }
    }
}

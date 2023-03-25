using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;

    public void ApplyDamageToObject(GameObject otherGameObject)
    {
        Character character = otherGameObject.GetComponent<Character>();

        if (character != null)
        {
            character.TakeDamage(_damage);
        }
    }

    public void ApplyDamageToCharacter(Character character)
    {
        if (character != null)
        {
            character.TakeDamage(_damage);
        }
    }
}

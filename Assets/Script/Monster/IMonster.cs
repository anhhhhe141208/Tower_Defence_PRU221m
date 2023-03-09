using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMonster : MonoBehaviour
{
    public interface IMonster
    {
        void Move();
        void SpecialAbility();
        void TakeDamage(int damage);
        void Die();
    }
}

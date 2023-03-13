using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster 
{
        void Move();
        void SpecialAbility();
        void TakeDamage(float damage);
        void Die();
}

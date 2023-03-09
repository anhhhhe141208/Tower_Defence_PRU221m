using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Factory c?a monster
    public GoblinMonsterFactory monsterFactory;

    // V? trí b?t ??u c?a monster
    public Vector3 startPosition;

    // ?i?m ?ích mà monster c?n ?i ??n
    public Transform target;
    void Start()
    {
        // T?o m?t ??i t??ng monster t? factory
        var monster = monsterFactory.CreateMonster(startPosition, target);

        // Di chuy?n monster ??n ?ích
        monster.Move();

        // G?i hành vi ??c bi?t c?a monster
        monster.SpecialAbility();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

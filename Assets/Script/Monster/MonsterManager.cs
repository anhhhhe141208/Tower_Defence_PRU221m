using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Factory c?a monster
    public GoblinMonsterFactory monsterFactory;

    // V? tr� b?t ??u c?a monster
    public Vector3 startPosition;

    // ?i?m ?�ch m� monster c?n ?i ??n
    public Transform target;
    void Start()
    {
        // T?o m?t ??i t??ng monster t? factory
        var monster = monsterFactory.CreateMonster(startPosition, target);

        // Di chuy?n monster ??n ?�ch
        monster.Move();

        // G?i h�nh vi ??c bi?t c?a monster
        monster.SpecialAbility();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

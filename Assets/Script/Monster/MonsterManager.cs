using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Factory cua monster goblin
    public MonsterFactory factory;

    // Vi tri bat dau cua monster
    public Vector3 startPosition;

    Monster monster;
    void Start()
    {
        Debug.Log(factory);
        // tao monster = monster factory
        monster = (Monster)factory.CreateMonster(startPosition);

        // di chuyen monster den dich
        monster.Move();

        // goi hanh vi dac biet cua monster
        monster.SpecialAbility();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            monster.TakeDamage(5f);
    }
}

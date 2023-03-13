using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Factory cua monster goblin
    public GoblinMonsterFactory goblinFactory;

    // Vi tri bat dau cua monster
    public Vector3 startPosition;

    // diem dich mà monster can den
    public Transform target;
    void Start()
    {
        // tao monster = monster factory
        var monster = goblinFactory.CreateMonster(startPosition, target);

        // di chuyen monster den dich
        monster.Move();

        // goi hanh vi dac biet cua monster
        monster.SpecialAbility();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

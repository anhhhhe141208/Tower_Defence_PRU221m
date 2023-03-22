using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterFactory : MonoBehaviour
{
    public abstract IMonster CreateMonster();
}

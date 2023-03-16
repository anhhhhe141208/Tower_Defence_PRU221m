using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class MonsterSubject
{
    private static MonsterSubject instance;
    public static MonsterSubject Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MonsterSubject();
            }
            return instance;
        }
    }
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyOnMonsterDamaged(Monster monster, int damage)
    {
        foreach (IObserver observer in _observers)
        {
            observer.OnMonsterDamaged(monster, damage);
        }
    }

    public void NotifyOnMonsterKilled(Monster monster)
    {
        foreach (IObserver observer in _observers)
        {
            observer.OnMonsterKilled(monster);
        }
    }

    public void NotifyOnMonsterReachedEnd(Monster monster)
    {
        foreach (IObserver observer in _observers)
        {
            observer.OnMonsterReachedEnd(monster);
        }
    }
}

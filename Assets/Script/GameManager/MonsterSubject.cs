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
    public List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Debug.Log("remove success");
    }

    public void NotifyOnMonsterDamaged(Monster monster, int damage)
    {
        try {
            foreach (IObserver observer in _observers)
            {
                if (observer != null)
                    observer.OnMonsterDamaged(monster, damage);
            }
        } catch (Exception e) {
            Debug.Log(e);
        }

    }

    public void NotifyOnMonsterKilled(Monster monster)
    {
        foreach (IObserver observer in _observers)
        {
            if(observer != null)
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

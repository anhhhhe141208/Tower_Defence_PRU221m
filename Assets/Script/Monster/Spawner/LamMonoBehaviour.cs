using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamMonoBehaviour : MonoBehaviour
{

    protected virtual void Start()
    {
        // for override
        // temp
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        // for override
    }

    protected virtual void ResetValue()
    {
        // for override
    }
}

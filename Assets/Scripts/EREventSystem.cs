using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EREventSystem : MonoBehaviour
{
    public static EREventSystem current;

    public List<Entity> entities;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public event Action OnEntityCountChange;
    public void EntityCountChange()
    {
        OnEntityCountChange?.Invoke();
    }
}

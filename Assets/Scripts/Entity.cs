using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Gravity
{
    // Start is called before the first frame update
    void Start()
    {
        EREventSystem.current.entities.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EREventSystem.current.entities.Remove(this);
    }

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    private void OnMouseExit()
    {
        transform.localScale = Vector3.one;
    }
}

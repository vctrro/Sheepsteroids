using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTrigger : MonoBehaviour
{
    public event Action<Collider2D> OnRayTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnRayTrigger?.Invoke(collision);
    }
}

using System;
using UnityEngine;
using Model;

public interface IObject2DView
{
    public void Init(Vector2 position, float rotation);
    public void Rotate(float rotation);
    public GameObject GetGameObject(); 
    public void Disable(); 
}


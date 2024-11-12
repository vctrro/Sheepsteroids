using System;
using System.Collections;
using UnityEngine;
using Model;

[RequireComponent(typeof(Collider2D))]
public class LaserView : Object2DView, ILaserView
{
    public Func<ICollidable> OnCollision { get; set; }

    [SerializeField] private RayTrigger _protonRay;
    private Collider2D _collider2D;

    private void OnEnable()
    {
        _collider2D = GetComponent<Collider2D>();
        _protonRay.OnRayTrigger += OnRayTrigger;
    }

    public void Shoot()
    {
        gameObject.SetActive(true);
        _protonRay.gameObject.transform.localScale = new Vector2(GetRayLength(), 1);
    }

    private float GetRayLength()
    {
        var hits = new RaycastHit2D[1];
        _collider2D.Raycast(_direction, hits, 20, LayerMask.GetMask("ScreenBorder"));

        return hits[0].distance;
    }

    private void OnRayTrigger(Collider2D collision)
    {
        collision.GetComponent<IEnemyView>().OnCollision(OnCollision?.Invoke());
    }

    private void OnDisable()
    {
        _protonRay.OnRayTrigger -= OnRayTrigger;
    }
}


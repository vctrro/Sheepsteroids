using System;
using System.Collections;
using UnityEngine;
using Model;

public class EnemyView : MovableView, IEnemyView
{
    [SerializeField] Transform _sprite;
    public Action<ICollidable> OnCollision { get; set; }

    protected override void OnEnable()
    {
        base.OnEnable();
        GetComponent<Collider2D>().enabled = true;
    }

    public override void Init(Vector2 position, float rotation)
    {
        base.Init(position, rotation);
    }

    public override void Rotate(float rotation)
    {
        _sprite.rotation = Quaternion.Euler(0, 0, rotation);
        _direction = _sprite.up;
    }

    public override void Disable()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(Fire());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<ICollidableView>(out ICollidableView collider))
        {
            OnCollision?.Invoke(collider.OnCollision?.Invoke());
        }
    }

    private IEnumerator Fire()
    {
        var fire = transform.Find("Fire").gameObject;
        fire.SetActive(true);
        yield return new WaitForSeconds(.5f);
        fire.SetActive(false);
        gameObject.SetActive(false);
    }
}


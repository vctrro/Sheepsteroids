using UnityEngine;
using System.Collections;
using TMPro;

public class Flipper : MonoBehaviour
{
    [Range(0.01f, 5.0f)]
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private SpriteRenderer _sprite;

	void Start()
	{
        StartCoroutine(Animator());
	}

    private IEnumerator Animator()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _speed);
            _sprite.flipX = !_sprite.flipX;
        }
    }
}


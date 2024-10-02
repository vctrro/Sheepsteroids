using UnityEngine;
using System.Collections;

public class ScreenBorder : MonoBehaviour
{
	[SerializeField] private GameSettings _gameSettings;

	private void Start()
	{
		transform.localScale = new Vector2(
			_gameSettings.BorderControl.Right - _gameSettings.BorderControl.Left,
			_gameSettings.BorderControl.Top - _gameSettings.BorderControl.Bottom);
	}
}


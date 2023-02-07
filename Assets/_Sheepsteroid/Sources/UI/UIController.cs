using System.Collections;
using UnityEngine;
using TMPro;
using Model;

public class UIController : MonoBehaviour
{
	[SerializeField] private TMP_Text _positonX;
	[SerializeField] private TMP_Text _positonY;
	[SerializeField] private TMP_Text _rotationText;
	[SerializeField] private TMP_Text _speedText;
	[SerializeField] private TMP_Text _laserCount;
	[SerializeField] private TMP_Text _laserRollbackTime;
	[SerializeField] private TMP_Text _activeEnemy;
	[SerializeField] private TMP_Text _splittableEnemy;
	[SerializeField] private TMP_Text _fragmentEnemy;

    public void SetPlayerStats(Vector2 position, float rotation, float speed)
    {
        _positonX.text = position.x.ToString("0.0");
		_positonY.text = position.y.ToString("0.0");
        _rotationText.text = rotation.ToString("0.0");
        _speedText.text = speed.ToString("0.0");
    }

    public void SetRollbackTime(float time)
    {
        _laserRollbackTime.text = time.ToString("0.0");
    }

    public void SetLaserCount(int value)
	{
		_laserCount.text = value.ToString();
    }

	public void SetActiveEnemy(int value)
	{
        _activeEnemy.text = value.ToString();
    }

	public void SetSplittableEnemy(int value)
	{
        _splittableEnemy.text = value.ToString();
    }

	public void SetFragmentEnemy(int value)
	{
        _fragmentEnemy.text = value.ToString();
    }
}


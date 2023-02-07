using UnityEngine;
using TMPro;
using Model;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameSettings _gameSettings;
	[SerializeField] private PlayerRecords _playerRecords;
	[SerializeField] private GameObject _gameOverPanel;
    [Space(5)]
    [SerializeField] private TMP_Text _activeEnemy;
    [SerializeField] private TMP_Text _splittableEnemy;
    [SerializeField] private TMP_Text _fragmentEnemy;
    [SerializeField] private TMP_Text _activeMulti;
    [SerializeField] private TMP_Text _splittableMulti;
    [SerializeField] private TMP_Text _fragmentMulti;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _gameManager.OnGameStop += GameOver;
    }

    public void GameOver()
    {
        _activeEnemy.text = _playerRecords.ActiveEnemyDestroyed.ToString();
        _splittableEnemy.text = _playerRecords.SplittableEnemyDestroyed.ToString();
        _fragmentEnemy.text = _playerRecords.FragmentEnemyDestroyed.ToString();
        _activeMulti.text = _gameSettings.ActiveEnemy.Points.ToString();
        _splittableMulti.text = _gameSettings.PassiveEnemy.Points.ToString();
        _fragmentMulti.text = _gameSettings.PassiveEnemy.FragmentPoints.ToString();
        _score.text = _playerRecords.Points.ToString();
        _gameOverPanel.SetActive(true);
    }

    private void OnDisable()
    {
        _gameManager.OnGameStop -= GameOver;
    }
}


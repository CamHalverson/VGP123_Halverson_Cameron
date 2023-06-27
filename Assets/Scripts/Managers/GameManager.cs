using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{

    static GameManager _instance = null;
    public static GameManager Instance
    {
        get => _instance;
        set
        {
            _instance = value;
        }
    }

    public int Lives
    {
        get => _lives;
        set
        {

            if (_lives > value) Respawn();

            _lives = value;
            if (_lives > maxLives) _lives = maxLives;

            Debug.Log("Lives value has changed to " + _lives.ToString());

            if (_lives <= 0) GameOver();

            if (OnLifeValueChanged != null)
                OnLifeValueChanged?.Invoke(_lives);

        }
    }
    private int _lives = 3;

    public int maxLives = 3;


    public PlayerController playerPrefab;
   
    [HideInInspector] public PlayerController playerInstance;
    [HideInInspector] public Transform spawnPoint;


    public UnityEvent<int> OnLifeValueChanged;





    void Start()
    {
        if (Instance)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }


    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
        UpdateSpawnPoint(spawnLocation);
    }

    public void UpdateSpawnPoint(Transform updatedPoint)
    {
        spawnPoint = updatedPoint;
    }


    void GameOver()
    {
        if (_lives == 0)
        {
            SceneManager.LoadScene("Gameover");
        }
    }

    void Respawn()
    {
        GameManager.Instance.transform.position = spawnPoint.position;
    }

}

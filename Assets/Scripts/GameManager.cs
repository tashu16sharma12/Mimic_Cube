using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
            }

            return instance;
        }
    }

    [SerializeField] CameraControls cameraControls;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameScreen;
    [SerializeField] GameObject gameOver;

    [SerializeField] PlayerCube player;
    [SerializeField] GhostCube ghost;

    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] OrbSpawner orbSpawner;
    [SerializeField] int score;
    [SerializeField] float distance;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text distanceText;

    private void Start()
    {
        Observer.Score += AddScore;
        Observer.Distance += AddDistance;
    }

    public void OnClickStart()
    {
        OnClickRestart();
    }

    private void Update()
    {
        distance += ObstacleSpawner.ObstacleSpeed * 0.1f * Time.deltaTime;
        Observer.Distance.Invoke(distance);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickMainMenu()
    {
        // Time.timeScale = 1f;
        mainMenu.SetActive(true);
        gameScreen.SetActive(false);
        gameOver.SetActive(false);
    }

    public void OnClickRestart()
    {
        Time.timeScale = 1f;

        score = 0;
        scoreText.text = "0";

        distance = 0;
        distanceText.text = "0";

        player.gameObject.SetActive(true);
        ghost.gameObject.SetActive(true);

        mainMenu.SetActive(false);
        gameScreen.SetActive(true);
        gameOver.SetActive(false);
        obstacleSpawner.Restart();
        orbSpawner.Restart();
    }

    public void GameOver()
    {
        StartCoroutine(SlowTime());
        cameraControls.Shake();
        mainMenu.SetActive(false);
        gameOver.SetActive(true);
        obstacleSpawner.GameStop();
        orbSpawner.GameStop();
    }

    IEnumerator SlowTime()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.05f;
    }

    void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString("0");
    }

    void AddDistance(float addDistance)
    {
        distanceText.text = distance.ToString("0");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    private int score = 0;  // điểm hiện tại


    void Awake()
    {
        // Singleton pattern (chỉ giữ 1 GameManager duy nhất)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại khi load scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    // ---- Quản lý điểm ----
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void RemoveScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0;
        Debug.Log("Score: " + score);
    }

    public int GetScore()
    {
        return score;
    }

    public int SetScore(int amount)
    {
        score = amount;
        return score;
    }

    // ---- Restart Game ----
    public void RestartGame(float delay)
    {
        StartCoroutine(RestartAfterDelay(delay));
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Load lại scene hiện tại
        //Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Home");

        // Reset score (nếu muốn giữ score thì bỏ dòng này)
        score = 0;
    }
}

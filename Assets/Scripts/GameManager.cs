using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
      {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        }
        else 
        { 
            Instance = this;
        }
 }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
        
    }

    public void GameOver()
{  
    UIController.Instance.gameOverPanel.SetActive(true);
}

    public void Restart()
{
    SceneManager.LoadScene("Game");
}

    public void Pause()
{
    if (UIController.Instance.pausePanel.activeSelf == false&& UIController.Instance.gameOverPanel.activeSelf == false)  
    {
        UIController.Instance.pausePanel.SetActive(true);
        Time.timeScale = 0f;

    } else
    {
        UIController.Instance.pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}

    public void GoToMainMenu()
{
    
}

    public void QuitGame()
{
    
}

}

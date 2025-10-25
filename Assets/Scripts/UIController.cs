using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    public static UIController Instance;
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private TMP_Text healthText;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    [SerializeField] private Slider playerExperienceSlider;
    [SerializeField] private TMP_Text ExperienceText;

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
        
    }

     public void UpdateHealthSlider()
    {
        playerHealthSlider.maxValue = PlayerController.Instance.playerMaxHealth;
        playerHealthSlider.value = PlayerController.Instance.playerHealth;
        healthText.text = playerHealthSlider.value + "/" + playerHealthSlider.maxValue;

    }

    public void UpdateExperienceSlider()
    {
        playerExperienceSlider.maxValue = PlayerController.Instance.playerLevels[PlayerController.Instance.currentLevel];
        playerExperienceSlider.value = PlayerController.Instance.experience;
        ExperienceText.text = playerExperienceSlider.value + "/" + playerExperienceSlider.maxValue;

    }

}

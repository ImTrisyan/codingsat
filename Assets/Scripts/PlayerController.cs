using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    public Vector3 playerMoveDirection;
    [SerializeField] private Animator animator;

    public float playerMaxHealth;
    public float playerHealth;
    public int experience;
    public int currentLevel;
    public int maxLevel;
    public List<int> playerLevels;

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
     
        for (int i = playerLevels.Count ; i < maxLevel; i++)
        {
            playerLevels.Add(Mathf.CeilToInt(playerLevels[playerLevels.Count - 1] * 1.1f));
        }

        playerHealth = playerMaxHealth;
        UIController.Instance.UpdateHealthSlider();
        UIController.Instance.UpdateExperienceSlider();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector2(inputX, inputY);


        rb.linearVelocity = new Vector2 (playerMoveDirection.x * moveSpeed, playerMoveDirection.y * moveSpeed);


        animator.SetFloat("MoveX", inputX);
        animator.SetFloat("MoveY", inputY);

        if(playerMoveDirection == Vector3.zero)
        {
            animator.SetBool("Moving",false);
        }
        else
        {
            animator.SetBool("Moving",true);
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        UIController.Instance.UpdateHealthSlider();

        if (playerHealth <= 0) {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }
    }

    public void GetExperience(int experienceToGet) 
    {
        experience += experienceToGet;
        UIController.Instance.UpdateExperienceSlider();
    }   


}

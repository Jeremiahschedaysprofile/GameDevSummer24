using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Create a aingleton for this script 

   public static GameManager Instance {get; private set;}

   public int score = 0;

   public TextMeshProUGUI scoreText; 
   
   public GameObject winText;

   public GameObject PickupParent;

   public int totalPickups = 0; 

   private PlayerController player;

   private void Awake() // Awake() is called once when this scripts enters the scene 
   {
        if (Instance == null) // if there is no other copy of this script in the scene 
        {
            Instance = this; // "this" refers to itself
        } else // "this is NOT the only coppy of the script in the scene 
        {
            //Delete this extra copy of this script 
            Debug.LogWarning("Cannot have more than one instance of [GameManager in this scene!] Deleting extra copy");
            Destroy(this.gameObject);
        }
   }

   private void Start()
   {
        score = 0; // reset the score when game start
        UpdateScoreText();

        winText.SetActive(false);

        // count how many pickups are in the level
        totalPickups = PickupParent.transform.childCount;


   }
   
    public void UpdateScore(int amount)
    {
        // increase the score var by amount given
        score = score + amount;
        UpdateScoreText();
        if (totalPickups <= 0)
        {
            WinGame();
        }
    }

    public void UpdateScoreText()
    {   
        scoreText.text = "Score: " + score.ToString(); // update the score text
    }

    public void WinGame()
    {
        winText.SetActive(true); // Enable our victory text
        AudioManager.Instance.PlaySound("Win");
        // stop the game 
        GameOver();
    }

    public void GameOver()
    {
        Invoke("LoadCurrentLevel", 2f);
    }

    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseGame()
    {
        if(player.health <= 0)
        {
            GameOver();
        }
    }
}

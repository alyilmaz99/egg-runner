using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen,finishScreen,egg;

    [SerializeField] private TextMeshProUGUI Coin;


    void Start()
    {
        Time.timeScale = 1;
        egg = GameObject.FindGameObjectWithTag("Egg");
    }

    
    void Update()
    {
        if (!egg.GetComponent<EggMovement>().canMove)
        {
            Invoke("EndGame", 2f);
        }



        Coin.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void EndGame()
    {
        endScreen.gameObject.SetActive(true);
    }
   public void FinishGame()
    {
        Time.timeScale = 0;
        finishScreen.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("LevelIndex")<=SceneManager.GetActiveScene().buildIndex)
        {
            LevelManager.Instance.SaveActiveLevelIndex();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       // Application.LoadLevel(Application.loadedLevel + 1);
    }
        
}

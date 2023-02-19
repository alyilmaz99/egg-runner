using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen,egg;



    void Start()
    {
        egg = GameObject.FindGameObjectWithTag("Egg");
    }

    
    void Update()
    {
        if (!egg.GetComponent<EggMovement>().canMove)
        {
            Invoke("EndGame", 2f);
        }
    }

    private void EndGame()
    {
        endScreen.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        
}

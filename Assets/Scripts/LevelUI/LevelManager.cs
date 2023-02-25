using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private List<Button> buttonList = new List<Button>();

    private int activeLevelIndex = 1;
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadCompleteLevels();
        CheckAllButtons();
    }

    private void CheckAllButtons()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (activeLevelIndex>=buttonList[i].GetComponent<ButtonController>().buttonValue)
            {
                buttonList[i].GetComponent<ButtonController>().SettLockState();
            }
        }
    }



    private void LoadCompleteLevels()
    {
        if (PlayerPrefs.GetInt("LevelIndex")==0)
        {
            activeLevelIndex = 1;
        }
        else
        {
            activeLevelIndex = PlayerPrefs.GetInt("LevelIndex");
        }
    }

    public void SaveActiveLevelIndex()
    {
        activeLevelIndex++;
        PlayerPrefs.SetInt("LevelIndex", activeLevelIndex);
    }

}

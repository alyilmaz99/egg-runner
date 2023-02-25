using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("sound/Vib Settings")]
    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject vibButton;
    [SerializeField] private List<Sprite> soundSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> vibSpriteList = new List<Sprite>();

    [SerializeField] private bool soundFixer;
    [SerializeField] private bool vibFixer;



    private void Start()
    {
        StartSoundVibCheck();
    }

    private void Update()
    {
        SoundVibUpdate();
    }


    #region Sound-Vib Controller

    public void SoundButton()
    {
        soundFixer = !soundFixer;
    }
    public void VibButton()
    {
        vibFixer = !vibFixer;
    }


    void SoundVibUpdate()
    {
        if (soundFixer)
        {
            PlayerPrefs.SetInt("sound", 1);
            soundButton.GetComponent<Image>().sprite = soundSpriteList[1];
        }
        else if (!soundFixer)
        {
            PlayerPrefs.SetInt("sound", 0);
            soundButton.GetComponent<Image>().sprite = soundSpriteList[0];
        }

        if (vibFixer)
        {
            PlayerPrefs.SetInt("vib", 1);
            vibButton.GetComponent<Image>().sprite = vibSpriteList[1];
        }
        else if (!vibFixer)
        {
            PlayerPrefs.SetInt("vib", 0);
            vibButton.GetComponent<Image>().sprite = vibSpriteList[0];
        }

    }


    void StartSoundVibCheck()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundFixer = true;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundFixer = false;
        }

        if (PlayerPrefs.GetInt("vib") == 1)
        {
            vibFixer = true;
        }
        else if (PlayerPrefs.GetInt("vib") == 0)
        {
            vibFixer = false;
        }
    }

    #endregion
}

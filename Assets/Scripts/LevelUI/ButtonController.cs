using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button levelButton;

    [SerializeField] private TMP_Text buttonText;

    [SerializeField] private GameObject lockIcon;

    public int buttonValue;

    private bool isComplete;

    private void Start()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(LoadSelectedScene);
    }



    public void SettLockState()
    {
        isComplete = true;

        if (isComplete)
        {
            buttonText.text = buttonValue.ToString();
            lockIcon.SetActive(false);
        }
     }

    public void LoadSelectedScene()
    {
        if (isComplete)
        {
            SceneManager.LoadScene(buttonValue-1);
        }
    }
}

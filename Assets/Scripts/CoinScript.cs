using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    private int coin;
    [SerializeField] private TextMeshProUGUI Coin;

     void Start()
     {
        coin = PlayerPrefs.GetInt("Coin");
     }

    private void Update()
    {
        Coin.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Coin")
        {
            coin++;
            PlayerPrefs.SetInt("Coin", coin);
            Destroy(collision.gameObject);
        }
    }
}

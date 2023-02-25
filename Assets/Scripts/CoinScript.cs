using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    private int coin;

    [SerializeField] GameObject coinPrefab;



     void Start()
     {
        coin = PlayerPrefs.GetInt("Coin");
        
     }

    private void Update()
    {
       // Coin.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Coin")
        {

            Debug.Log("aaaaaaaaaaaaaa");
            coin++;
            PlayerPrefs.SetInt("Coin", coin);

            GameObject newObject= Instantiate(coinPrefab,other.transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(newObject, 0.25f);
        }
    }

    

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeOfCoin : MonoBehaviour
{
    public string bonusName;
    public Text coinCount;
    private static int coins = 0;
    private static bool isFirstStart = true;

    public static int Coins 
    {
        get { return coins; }
    }

    void Start()
    {
        if (isFirstStart)
        {
            coins = 0;
            isFirstStart = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            switch (bonusName)
            {
                case "coin":
                coins++;
                coinCount.text = coins.ToString();
                Destroy(gameObject);
                break;
            }
        }
    } 
}
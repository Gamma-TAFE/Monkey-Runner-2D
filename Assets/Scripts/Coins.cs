using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{

    public int coinCounter = 0;
    public Text coinText;

    private void Start()
    {
        coinText.text = "Coins: " + coinCounter;
    }

    public void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCounter;
    }
    
}

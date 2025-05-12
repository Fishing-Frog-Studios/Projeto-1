using TMPro;
using Unity.Mathematics;
using UnityEngine;


public class CoinsTowers : MonoBehaviour
{
    public static CoinsTowers main;

    public int preco = 1;
    public int coins = 0; //quantia de moedas
    public TextMeshProUGUI nunberCoins;
    public string nunberCoinsText;

    private void Awake()
    {
        main = this;
    }

    private void FixedUpdate()
    {
        nunberCoins.text = nunberCoinsText;

        nunberCoinsText = "000" + coins;

        if (coins < preco)
        {
            nunberCoins.color = Color.red;
        }
        else 
        {
            nunberCoins.color = Color.white; 
        }
    }

}

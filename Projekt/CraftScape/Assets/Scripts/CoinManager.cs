using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int coinAmount;

    void Start()
    {
        coinAmount = 0;
    }

    void Update()
    {
        coinText.text = coinAmount.ToString();
    }
}

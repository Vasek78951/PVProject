using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    public int coins;
    public float coinBuff;
    public int xp;
    public float xpBuff;

    GameObject coinManager; 
    GameObject XPManager;
    // Start is called before the first frame update
    void Start()
    {
        coinManager = GameObject.FindGameObjectWithTag("CoinManager");
        XPManager = GameObject.FindGameObjectWithTag("XPManager");
    }

    // Update is called once per frame
    void Update()
    {
        
     
    }
    public void AddCoinBuff(float buff)
    {
        coinBuff += buff;
    }
    public void AddXPBuff(float buff)
    {
        xpBuff += buff;
    }
    public void GetCoins()
    {
        coinManager.GetComponent<CoinManager>().coinAmount += Mathf.RoundToInt(coins * coinBuff);
    }
    public void GetXP()
    {
        XPManager.GetComponent<XPManager>().XPAmount += Mathf.RoundToInt(xp * xpBuff);
    }
}

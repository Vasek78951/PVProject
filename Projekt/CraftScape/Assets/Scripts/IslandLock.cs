using System.Collections;
using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

public class IslandLock : MonoBehaviour
{
    public bool locked = true;
    public SpriteRenderer spriteRenderer;
    public int price;
    public TextMeshProUGUI textPrice;
    public IslandManager islandManager;
    public CoinManager coinManager;
    public ResourceCounter rc;
    public ObjectSpawning os;
    private void Start()
    {
        
        textPrice.text = price.ToString();
    }

    public void UnlockIsland(int id)
    {
        if (coinManager.coinAmount >= price)
        {
            islandManager.UnlockIsland(id);
            coinManager.coinAmount -= price;
            locked = false;
            Show(false);
            rc.maxCount += 12;
            os.InstaSpawn();
            Debug.Log("island unlocked");
        }
        else
        {
            Debug.Log("not enough coins");
        }
    }

    public void Show(bool visible)
    {
        if (visible)
        {
            if (locked)
            {
                Debug.Log("1");
                gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("2");
                gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("3");
            gameObject.SetActive(false);
        }
    }
}

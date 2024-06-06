using UnityEngine;
using UnityEngine.UI;

public class ObjectHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public Slider slider;
    public int itemId = -1;
    GameObject objectSpawning;
    GameObject addingItems;
    [SerializeField] public Canvas objectCanvas;
    bool damaged = false;
    GameObject rewards;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.gameObject.SetActive(false);
        objectSpawning = GameObject.FindGameObjectWithTag("Spawn");
        addingItems = GameObject.FindGameObjectWithTag("AddingItems");
        rewards = GameObject.FindGameObjectWithTag("Rewards");
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {    
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                if (gameObject.tag != "Structure")
                {
                    objectSpawning.GetComponent<ObjectSpawning>().MinusCurrent();
                    addingItems.gameObject.GetComponent<AddingItems>().PickUpItem(itemId);
                    rewards.gameObject.GetComponent<Rewards>().GetCoins();
                    rewards.gameObject.GetComponent<Rewards>().GetXP();
                }
            }

            if (!damaged)
            {
                slider.gameObject.SetActive(true);
            }
            slider.value = currentHealth;
            damaged = true;
        }
    }
}

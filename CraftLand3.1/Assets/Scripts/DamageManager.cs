using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public float baseDamage = 10f;

    public void DoDamage(InventoryItem item, GameObject hitedObject)
    {
        if (hitedObject != null && item != null && item.itemRule != null)
        {
            ItemRule rule = item.itemRule;
            if (hitedObject.CompareTag(rule.targetTag) && item.actionType == rule.actionType && item.type == rule.itemType)
            {
                float damage = item.damage * rule.damageMultiplier;
                Debug.Log(damage);  
                hitedObject.GetComponent<ObjectHealth>().TakeDamage(damage);
                return;
            }
        }
        
        // Default damage if no rule matches
        hitedObject.GetComponent<ObjectHealth>().TakeDamage(baseDamage);
    }
}

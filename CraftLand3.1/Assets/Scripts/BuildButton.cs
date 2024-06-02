using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    public TextMeshProUGUI requiredResourcesText;

    public void ShowRequiredResources(List<RecipeItem> requiredItems)
    {
        requiredResourcesText.text = "Required Resources:\n";
        foreach (RecipeItem recipeItem in requiredItems)
        {
            requiredResourcesText.text += $"{recipeItem.item.name}: {recipeItem.quantity}\n";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{
    public Slider slider;
    public float XPAmount;
    public int level;
    public TextMeshProUGUI levelText;
    public float maxXPValue;
    public SkillTree skillTree;
    void Start()
    {
        maxXPValue = 100;
        slider.maxValue = maxXPValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (XPAmount > maxXPValue)
        {
            level++;
            skillTree.skillPoints = skillTree.skillPoints += 1;
            levelText.text = level.ToString();
            XPAmount -= maxXPValue;
            maxXPValue *= 1.5f;
            slider.maxValue = maxXPValue;
            
        }
        slider.value = XPAmount;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public Skill[] skills;
    public int size;
    public int skillPoints;
    public TextMeshProUGUI skillPintText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skillPintText.text = skillPoints.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }

        for (int i = 0; i < skills.Length; i++)
        {
            // Check if the current index is within the valid range
            if (i + size < skills.Length && skills[i + size].unlocked)
            {
                skills[i].setVisible();
            }
            if (i - size >= 0 && skills[i - size].unlocked)
            {
                skills[i].setVisible();
            }
            if (i + 1 < skills.Length && skills[i + 1].unlocked)
            {
                skills[i].setVisible();
            }
            if (i - 1 >= 0 && skills[i - 1].unlocked)
            {
                skills[i].setVisible();
            }
        }
    }
}

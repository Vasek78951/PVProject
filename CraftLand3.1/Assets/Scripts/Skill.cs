using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image image;
    public Image lockImage;
    public bool visible;
    public bool unlocked;
    public SkillTree skillTree;

    // Start is called before the first frame update
    void Start()
    {
        image.gameObject.SetActive(false);
        lockImage.gameObject.SetActive(visible);
        unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVisible()
    {
        if(!unlocked)
        {
            visible = true;
            lockImage.gameObject.SetActive(true);
        }
    }   
    public void unlockSkill()
    {
        if(skillTree.skillPoints > 0)
        {
            image.gameObject.SetActive(true);
            lockImage.gameObject.SetActive(false);
            unlocked = true;
            skillTree.skillPoints--;
        }
        

    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GuyGenerator : MonoBehaviour
{
    public GameObject guyPrefab;

    public SkinColor prohibitedSkin { get; set; }
    public DressColor prohibitedDress { get; set; }

    void Start()
    {
        RandomizeProhibited();
    }

    void RandomizeProhibited()
    {
        prohibitedSkin = (SkinColor)Random.Range(1.0f, 4.0f);
        prohibitedDress = (DressColor)Random.Range(1.0f, 7.0f);
        Debug.Log("Incorrect skin: " + prohibitedSkin);
        Debug.Log("Incorrect dress: " + prohibitedDress);
    }

    public GameObject Generate()
    {

        Appearance appearance = new Appearance();

        var guyObj = Instantiate(guyPrefab);
        var spritesList = guyObj.GetComponentsInChildren<SpriteRenderer>();
        foreach (var spriteComp in spritesList)
        {
            if (spriteComp.gameObject.name == "Body")
            {
                switch (appearance.Skin)
                {
                    case SkinColor.red:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/male_1");
                        break;
                    case SkinColor.yellow:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/male_2");
                        break;
                    case SkinColor.purple:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/male_3");
                        break;
                }
            }
            else if (spriteComp.gameObject.name == "Cloth")
            {
                switch (appearance.Dress)
                {
                    case DressColor.blue:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_blue");
                        break;
                    case DressColor.green:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_green");
                        break;
                    case DressColor.red:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_red");
                        break;
                    case DressColor.yellow:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_yellow");
                        break;
                    case DressColor.white:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_white");
                        break;
                    case DressColor.black:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_black");
                        break;
                }
            }
            else if (spriteComp.gameObject.name == "Trinket")
            {
                switch (appearance.Brooch)
                {
                case BroochType.red:
                    spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/trinkets/trinket1_red_right");
                    break;
                case BroochType.yellow:
                    spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/trinkets/trinket2_yellow_right");
                    break;
                }
            }
        }
        var guy = guyObj.GetComponent<Guy>();
        guy.isGuilty = (appearance.Skin == prohibitedSkin) || (appearance.Dress == prohibitedDress);
        Debug.Log("Generated a guilty guy:" + guy.isGuilty);

        return guyObj;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GuyGenerator : MonoBehaviour
{
    public GameObject guyPrefab;

    Guy Generate(RoundState state)
    {
        Appearance appearance = new Appearance();
        Sprite[] sprites = Resources.LoadAll<Sprite>("spriteNames");
        // TODO Generate Appearance
        var guyGameobject = Instantiate(guyPrefab);
        var spritesList = guyGameobject.GetComponentsInChildren<SpriteRenderer>();
        foreach (var spriteComp in spritesList)
        {
            if (spriteComp.gameObject.name == "Body")
            {
                spriteComp.sprite = sprites[0];
                // TODO Set sprite
            }
            else if (spriteComp.gameObject.name == "Cloth")
            {
                // TODO Set sprite
            }
            else if (spriteComp.gameObject.name == "Trinket")
            {
                // TODO Set sprite
            }
        }

        return new Guy();
    }
}

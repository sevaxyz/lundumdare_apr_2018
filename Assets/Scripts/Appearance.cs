using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkinColor
{
    red = 1,
    yellow,
    purple
}

public enum DressColor
{
    blue = 1,
    green,
    red,
    yellow,
    white,
    black
}

public enum BroochType
{
    none = 0,
    red,
    yellow
}

public enum BroochPlacement
{
    up = 1,
    down
}

public class Appearance
{
    Dictionary<SkinColor, string> spriteFilenames;

    public SkinColor Skin { get; set; }
    public DressColor Dress { get; set; }
    public BroochType Brooch { get; set; }
    public BroochPlacement Placement { get; set; }

    public Appearance()
    {
        Randomize();
    }

    public void Randomize()
    {
        Skin = (SkinColor)Random.Range(1.0f, 4.0f);
        Dress = (DressColor)Random.Range(1.0f, 7.0f);
        Brooch = (BroochType)Random.Range(1.0f, 3.0f);
        Placement = (BroochPlacement)Random.Range(1.0f, 3.0f);
    }
}

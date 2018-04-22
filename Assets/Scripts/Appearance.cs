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
    shield,
    sun,
    moon
}

public enum BroochPlacement
{
    up = 1,
    down
}

public struct Appearance
{
    public SkinColor SkinColor { get; set; }
    public DressColor DressColor { get; set; }
    public BroochType BroochType { get; set; }
    public BroochPlacement BroochPlacement { get; set; }
}

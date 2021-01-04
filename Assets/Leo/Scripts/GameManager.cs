using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int levelDestination;
    private int levelOrigin;

    public int LevelOrigin
    {
        get => levelOrigin;
        set => levelOrigin = value;
    }
    
    public int LevelDestination
    {
        get => levelDestination;
        set => levelDestination = value;
    }
    
    private void Start()
    {
        LevelOrigin = 2;
        LevelDestination = 3;
    }
}

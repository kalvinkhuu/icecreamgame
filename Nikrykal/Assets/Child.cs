﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    private int Multiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMultiplier()
    {
        return Multiplier;

    }

    public void SetMultiplier(int NewMultiplier)
    {
        Multiplier = NewMultiplier;

    }
}

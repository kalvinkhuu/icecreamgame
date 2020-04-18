using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        Debug.Log("Multiplier = " + NewMultiplier);
        GetComponentInChildren<TextMeshPro>().text = "X" + Multiplier;
        float NewScale = 0.8f + 0.1f * Multiplier;
        transform.localScale = new Vector3(NewScale, NewScale, NewScale);
    }
}
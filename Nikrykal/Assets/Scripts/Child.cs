using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Child : MonoBehaviour
{
    private int Multiplier = 2;

    public Material X2Material;
    public Material X3Material;
    public Material X5Material;
    public Material X10Material;
    private ChildRenderer childRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        childRenderer = GetComponentInChildren<ChildRenderer>();
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
        if (Multiplier == 2)
        {
            childRenderer.SetMaterial(ref X2Material);
        }
        else if (Multiplier == 3)
        {
            childRenderer.SetMaterial(ref X3Material);
        }
        else if (Multiplier == 5)
        {
            childRenderer.SetMaterial(ref X5Material);
        }
        else if (Multiplier == 10)
        {
            childRenderer.SetMaterial(ref X10Material);
        }
        GetComponentInChildren<TextMeshPro>().text = "X" + Multiplier;
        float NewScale = 0.8f + 0.1f * Multiplier;
        transform.localScale = new Vector3(NewScale, NewScale, NewScale);
    }
}

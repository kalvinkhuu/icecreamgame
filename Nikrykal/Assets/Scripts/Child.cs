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
    public AudioSource X10Sound;
    private ChildRenderer childRenderer;

    private float TimeAlive = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        childRenderer = GetComponentInChildren<ChildRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Multiplier == 10)
            {
                TimeAlive += Time.deltaTime;
            }
            if (TimeAlive > 5.0f)
            {
                TimeAlive = 0.0f;
                gameObject.SetActive(false);
                X10Sound.Stop();
            }
        }
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
            X10Sound.Play();
        }
        GetComponentInChildren<TextMeshPro>().text = "X" + Multiplier;
        float NewScale = 0.8f + 0.1f * Multiplier;
        transform.localScale = new Vector3(NewScale, NewScale, NewScale);
    }
}

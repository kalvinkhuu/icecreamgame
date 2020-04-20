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
    public AudioSource SadSound;
    private ChildRenderer childRenderer;
    private TextMeshPro Text;

    private float currentRotationX = 0;
    private float TimeAlive = 0.0f;
    public float SpinSpeed = 5.0f;
    private bool SadSoundPlayed = false;

    // Start is called before the first frame update
    void Awake()
    {
        childRenderer = GetComponentInChildren<ChildRenderer>();
        Text = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            TimeAlive += Time.deltaTime;
            if (Multiplier == 10)
            {
                if (TimeAlive > 7.0f)
                {
                    gameObject.SetActive(false);
                    X10Sound.Stop();
                }
            }
            else if (TimeAlive > 20.0f)
            {
                gameObject.SetActive(false);
            }
            else if (TimeAlive > 15.0f)
            {
                if (!SadSoundPlayed)
                {
                    SadSound.Play();
                    SadSoundPlayed = true;
                }
                childRenderer.SetVisibility(!childRenderer.GetVisibility());
            }
        }
        currentRotationX += Time.deltaTime * SpinSpeed;
        transform.localRotation = Quaternion.AngleAxis(currentRotationX, new Vector3(0.0f, 1.0f, 0.0f));
        Text.transform.localRotation = Quaternion.AngleAxis(-currentRotationX, new Vector3(0.0f, 1.0f, 0.0f)) * Quaternion.AngleAxis(20.0f, new Vector3(1.0f, 0.0f, 0.0f));
    }

    public int GetMultiplier()
    {
        return Multiplier;
    }

    public void SetMultiplier(int NewMultiplier)
    {
        childRenderer.SetVisibility(true);
        SadSoundPlayed = false;
        TimeAlive = 0.0f;
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

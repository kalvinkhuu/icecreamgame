using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRenderer : MonoBehaviour
{
    Renderer myrenderer;
    // Start is called before the first frame update
    void Awake()
    {
        myrenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetVisibility()
    {
        return myrenderer.enabled;
    }

    public void SetVisibility(bool visible)
    {
        myrenderer.enabled = visible;
    }

    public void SetMaterial(ref Material mat)
    {
        myrenderer.material = mat;
    }
}

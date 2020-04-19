using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaterial(ref Material mat)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = mat;
    }
}

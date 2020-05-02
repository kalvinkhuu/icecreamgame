using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamSplat : MonoBehaviour
{
    public AudioSource SplatSound;
    public Material ChocolateMaterial;
    public Material StrawberryMaterial;
    public Material VanillaMaterial;
    private Renderer splatrenderer;
    private ParticleSystem particlesystem;
    // Start is called before the first frame update
    void Start()
    {
        splatrenderer = GetComponent<Renderer>();
        particlesystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SplatVanilla()
    {
        transform.localPosition = new Vector3(0, 4.5f, 0);
        SplatSound.Play();
        particlesystem.Play();
        splatrenderer.material = VanillaMaterial;

    }

    public void SplatChocolate()
    {
        transform.localPosition = new Vector3(0, 2.5f, 0);
        SplatSound.Play();
        particlesystem.Play();
        splatrenderer.material = ChocolateMaterial;
    }

    public void SplatStrawberry()
    {
        transform.localPosition = new Vector3(0, 3.5f, 0);
        SplatSound.Play();
        particlesystem.Play();
        splatrenderer.material = StrawberryMaterial;
    }
}

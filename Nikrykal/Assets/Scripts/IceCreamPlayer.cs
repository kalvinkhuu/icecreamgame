using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonUserControl))]
public class IceCreamPlayer : MonoBehaviour
{
    private bool IsSunLeader;
    private IceCreamCone m_IceCreamCone;
    private ThirdPersonUserControl m_ThirdPersonUserControl;
    private IceCreamInteraction m_IceCreamInteraction;
    bool bCanPickupNewIceCream = false;
    private int Score = 0;
    public AudioSource PickupSound;
    public int PlayerNumber = 0;
    public GameObject Sun;
    public GameObject InteractButton;

    public int GetScore()
    {
        return Score;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_IceCreamCone = GetComponentInChildren<IceCreamCone>();
        m_ThirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
        m_IceCreamInteraction = GameObject.Find("IceCreamTruck").GetComponentInChildren<IceCreamInteraction>();
        Debug.Log("IceCreamInteraction: " + m_IceCreamInteraction.name);
        InteractButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanPickupNewIceCream && hinput.gamepad[m_ThirdPersonUserControl.GamepadIndex].A.justPressed)
        {
            m_IceCreamCone.PickupNewIceCream();
        }
    }

    public void SetIsSunLeader(bool isSunLeader)
    {
        IsSunLeader = isSunLeader;
        m_IceCreamCone.IsSunLeader = IsSunLeader;
        Sun.SetActive(IsSunLeader);
    }

    void OnTriggerEnter(Collider col)
    {
        Child child = col.GetComponent<Child>();
        if (col.name == m_IceCreamInteraction.name)
        {
            bCanPickupNewIceCream = true;
            InteractButton.SetActive(bCanPickupNewIceCream);
        }
        else if (child != null)
        {
            if (m_IceCreamCone.GetNumBalls() > 0)
            {
                int ScoreToAdd = m_IceCreamCone.GetNumBalls() * child.GetMultiplier();
                Debug.Log("Score To Add: " + ScoreToAdd);
                Score += ScoreToAdd;
                Debug.Log("Current Score " + Score);
                child.gameObject.SetActive(false);
                m_IceCreamCone.GiveIceCreamToChild();
                PickupSound.Play();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == m_IceCreamInteraction.name)
        {
            bCanPickupNewIceCream = false;
            InteractButton.SetActive(bCanPickupNewIceCream);
        }
    }
}

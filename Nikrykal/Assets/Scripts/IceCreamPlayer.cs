using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonUserControl))]
public class IceCreamPlayer : MonoBehaviour
{
    private IceCreamCone m_IceCreamCone;
    private ThirdPersonUserControl m_ThirdPersonUserControl;
    private IceCreamInteraction m_IceCreamInteraction;
    bool bCanPickupNewIceCream = false;
    private int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_IceCreamCone = GetComponentInChildren<IceCreamCone>();
        m_ThirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
        m_IceCreamInteraction = GameObject.Find("IceCreamTruck").GetComponentInChildren<IceCreamInteraction>();
        Debug.Log("IceCreamInteraction: " + m_IceCreamInteraction.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanPickupNewIceCream && hinput.gamepad[m_ThirdPersonUserControl.GamepadIndex].A.justPressed)
        {
            m_IceCreamCone.PickupNewIceCream();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Child child = col.GetComponent<Child>();
        Debug.Log("collided with :" + col.name.ToString());
        if (col.name == m_IceCreamInteraction.name)
        {
            bCanPickupNewIceCream = true;
        }
        else if (child != null)
        {
            if (m_IceCreamCone.GetNumBalls() > 0)
            {
                m_IceCreamCone.GiveIceCreamToChild();
                Score += m_IceCreamCone.GetNumBalls() * child.GetMultiplier();
                Debug.Log("Current Score" + Score);
                child.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("collided with :" + col.name.ToString());
        if (col.name == m_IceCreamInteraction.name)
        {
            bCanPickupNewIceCream = false;
        }
    }
}

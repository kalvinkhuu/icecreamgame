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
        Debug.Log("collided with :" + col.name.ToString());
        if (col.name == m_IceCreamInteraction.name)
        {
            bCanPickupNewIceCream = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonUserControl))]
public class IceCreamPlayer : MonoBehaviour
{
    private IceCreamCone m_IceCreamCone;
    private ThirdPersonUserControl m_ThirdPersonUserControl;
    // Start is called before the first frame update
    void Start()
    {
        m_IceCreamCone = GetComponentInChildren<IceCreamCone>();
        m_ThirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hinput.gamepad[m_ThirdPersonUserControl.GamepadIndex].A.justPressed)
        {
            m_IceCreamCone.PickupNewIceCream();
        }
    }
}

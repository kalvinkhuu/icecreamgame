using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class ThirdPersonUserControl : MonoBehaviour
{
    private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;

    public int GamepadIndex = -1;

    private void Start()
    {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<ThirdPersonCharacter>();
    }


    private void Update()
    {
    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        bool UseKeyboardAlso = GamepadIndex == 0;

        var gamepads = Gamepad.all;
        Gamepad currentGamepad = null;
        if (GamepadIndex < gamepads.Count)
        {
            currentGamepad = gamepads[GamepadIndex];
        }

        Vector2 KeyboardAxis = Vector2.zero;
        if (UseKeyboardAlso)
        {
            if (Keyboard.current != null)
            {
                bool leftPressed = Keyboard.current[Key.A].isPressed || Keyboard.current[Key.LeftArrow].isPressed;
                bool rightPressed = Keyboard.current[Key.D].isPressed || Keyboard.current[Key.RightArrow].isPressed;

                float xLeft = leftPressed ? -1.0f : 0.0f;
                float xRight = rightPressed ? 1.0f : 0.0f;
                float x = xLeft + xRight;

                bool upPressed = Keyboard.current[Key.W].isPressed || Keyboard.current[Key.UpArrow].isPressed;
                bool downPressed = Keyboard.current[Key.S].isPressed || Keyboard.current[Key.DownArrow].isPressed;

                float yUp = upPressed ? 1.0f : 0.0f;
                float yDown = downPressed ? -1.0f : 0.0f;
                float y = yUp + yDown;

                KeyboardAxis = new Vector2(x, y);
            }
        }

        Vector2 GamepadAxis = Vector2.zero;
        if (currentGamepad != null)
        {
            GamepadAxis = currentGamepad.leftStick.ReadValue();
        }

        Vector2 Axis = GamepadAxis.magnitude > KeyboardAxis.magnitude ? GamepadAxis : KeyboardAxis;

        float h = Axis.x;
        float v = Axis.y;

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v * Vector3.forward + h * Vector3.right;
        }

        // pass all parameters to the character control script
        m_Character.Move(m_Move, false, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ThirdPersonUserControl))]
public class IceCreamPlayer : MonoBehaviour
{
    private bool IsSunLeader;
    private IceCreamCone m_IceCreamCone;
    private TextMeshPro PlusScore;
    private ThirdPersonUserControl m_ThirdPersonUserControl;
    private ThirdPersonCharacter m_ThirdPersonCharacter;
    private IceCreamInteraction m_IceCreamInteraction;
    private bool bShowPlusScore = false;
    private float PlusScoreTimer = 0.0f;
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
    void Awake()
    {
        m_IceCreamCone = GetComponentInChildren<IceCreamCone>();
        PlusScore = GetComponentInChildren<TextMeshPro>();
    }

    void Start()
    {
        m_ThirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        m_ThirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
        GameObject IceCreamTruck = GameObject.Find("IceCreamTruck");
        if (IceCreamTruck != null)
        {
            m_IceCreamInteraction = IceCreamTruck.GetComponentInChildren<IceCreamInteraction>();
        }
        InteractButton.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bShowPlusScore)
        {
            PlusScoreTimer += Time.deltaTime;
            PlusScore.transform.localPosition = new Vector3(0, 0, 4.0f + (-PlusScoreTimer * 20.0f));
            PlusScore.alpha = 1.0f - (PlusScoreTimer / 1.0f);
            if (PlusScoreTimer > 2.0f)
            {
                bShowPlusScore = false;
                PlusScore.enabled = false;
            }
        }

        bool UseKeyboardAlso = m_ThirdPersonUserControl.GamepadIndex == 0;

        var gamepads = Gamepad.all;
        Gamepad currentGamepad = null;
        if (m_ThirdPersonUserControl.GamepadIndex < gamepads.Count)
        {
            currentGamepad = gamepads[m_ThirdPersonUserControl.GamepadIndex];
        }

        if (!UseKeyboardAlso && currentGamepad == null)
            return; // No gamepad connected.

        if (bCanPickupNewIceCream && ((UseKeyboardAlso && (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)) 
        || (currentGamepad != null && (currentGamepad.aButton.wasPressedThisFrame || currentGamepad.bButton.wasPressedThisFrame 
        || currentGamepad.xButton.wasPressedThisFrame || currentGamepad.yButton.wasPressedThisFrame))))
        {
            m_IceCreamCone.PickupNewIceCream();
        }
    }

    public void SetIsSunLeader(bool isSunLeader)
    {
        IsSunLeader = isSunLeader;
        m_IceCreamCone.IsSunLeader = IsSunLeader;
        Sun.SetActive(IsSunLeader);

        if (IsSunLeader && MainMenu.ChosenNumPlayers != 1)
        {
            m_ThirdPersonCharacter.m_MoveSpeedMultiplier = 0.7f;
        }
        else
        {
            m_ThirdPersonCharacter.m_MoveSpeedMultiplier = 1.0f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Child child = col.GetComponent<Child>();
        if (m_IceCreamInteraction != null && col.name == m_IceCreamInteraction.name)
        {
            bCanPickupNewIceCream = true;
            InteractButton.GetComponent<Renderer>().enabled = bCanPickupNewIceCream;
        }
        else if (child != null)
        {
            if (m_IceCreamCone.GetNumBalls() >= 0 && m_IceCreamCone.gameObject.activeSelf)
            {
                int ScoreToAdd = (int)((float)m_IceCreamCone.GetNumBalls() * (float)child.GetMultiplier() * (IsSunLeader ? 0.75f : 1.0f));
                Score += ScoreToAdd;
                child.gameObject.SetActive(false);
                m_IceCreamCone.GiveIceCreamToChild();
                PickupSound.Play();
                bShowPlusScore = true;
                PlusScore.enabled = true;
                PlusScore.text = "+" + ScoreToAdd;
                PlusScore.transform.localPosition = new Vector3(0, 0, 0);
                PlusScoreTimer = 0.0f;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (m_IceCreamInteraction != null && col.name == m_IceCreamInteraction.name)
        {
            bCanPickupNewIceCream = false;
            InteractButton.GetComponent<Renderer>().enabled = bCanPickupNewIceCream;
        }
    }
}

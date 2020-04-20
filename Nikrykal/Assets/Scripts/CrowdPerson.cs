using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdPerson : MonoBehaviour
{
    private Vector3 PlaceToGoTo;
    public float MovementSpeed = 0.3f;
    private bool GoToAlternatePosition = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void ChangeToAlternatePosition(Vector3 NewPlaceToGo)
    {
        GoToAlternatePosition = true;
        PlaceToGoTo = NewPlaceToGo;
    }

    // Update is called once per frame
    void Update()
    {
        if (GoToAlternatePosition)
        {
            Vector3 CurrentPosition = transform.localPosition;
            Vector3 DesiredPosition = Vector3.Lerp(CurrentPosition, PlaceToGoTo, Time.deltaTime * MovementSpeed);
            transform.localPosition = DesiredPosition;
        }
    }
}

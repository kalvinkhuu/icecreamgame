using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera GameCamera;
    // Start is called before the first frame update
    void Start()
    {
        GameCamera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = GameCamera.transform.rotation * Quaternion.AngleAxis(90, new Vector3(1.0f, 0.0f, 0.0f));
    }
}

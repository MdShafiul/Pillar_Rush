using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePillars : MonoBehaviour
{

    float rotateSpeed = 0.2f;
    private Vector3 prePos;

    // Start is called before the first frame update
    void Start()
    {
        prePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = prePos;
        OnMouseDrag();
    }

    private void OnMouseDrag()
    {
        
            if (Input.touchCount == 1)
            {

                if (PlayerPrefs.GetInt("Check_Death") == 0)
                {
                    float rotateSpeed = 0.75f;
                    Touch touchZero = Input.GetTouch(0);

                    //Rotate the model based on offset
                    Vector3 localAngle = transform.localEulerAngles;
                    localAngle.y -= rotateSpeed * touchZero.deltaPosition.x;
                    transform.localEulerAngles = localAngle;
                }
                
            }

    }


}

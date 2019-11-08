using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Score>().check)
            return;

        moveVector = Vector3.zero;

        moveVector.y = speed;

        controller.Move( (moveVector * speed ) * Time.deltaTime );

        
    }

    public void SetSpeed( int modifier )
    {
        speed = 2.0f + modifier / 10.0f;
    }

}

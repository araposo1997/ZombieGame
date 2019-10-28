using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform trans;


    private float moveSpeed;
    private float turnSpeed;

    private void Start()
    {
        moveSpeed = .1f;
        turnSpeed = .1f;
    }

    private void Update()
    {

        Vector3 inputVector = Vector3.zero;

        // Check for movement input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputVector += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            inputVector += Vector3.back;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            inputVector += Vector3.right;
        }

        if (inputVector != trans.position)
        {

            // Normalize input vector to standardize movement speed
            inputVector.Normalize();
            inputVector *= moveSpeed;
            

            // Face player along movement vector
            Quaternion targetRotation = Quaternion.LookRotation(inputVector);
            trans.rotation = Quaternion.Lerp(trans.rotation, targetRotation, turnSpeed * Time.deltaTime);
            trans.position += inputVector;
        }
    
        

    }
}

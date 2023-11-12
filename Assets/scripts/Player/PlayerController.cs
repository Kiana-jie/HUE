using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Playerinputcontrol inputControl;
    public Rigidbody2D rb;
    public Vector2 inputDirection;
    [Header("��������")]
    public float Speed;
    public float jumpForce;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputControl =new Playerinputcontrol();

        inputControl.Gameplay.Jump.started += Jump;
    }

    

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();   
    }



    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {
        //�����ƶ�

        rb.velocity = new Vector2(inputDirection.x * Speed * Time.deltaTime,rb.velocity.y);

        //���ﷴת
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        if (inputDirection.x < 0)
            faceDir = -1;

        transform.localScale = new Vector3(faceDir, 1, 1);

    }
        //������Ծ
    private void Jump(InputAction.CallbackContext context)
    {
        // Debug.Log("JUMP");
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);    
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);    
    }
}

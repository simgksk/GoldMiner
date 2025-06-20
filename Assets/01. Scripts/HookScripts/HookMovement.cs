using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [Header("Setting")]
    public float min_z = -55f;
    public float max_z = 55f;
    public float rotate_Speed = 50f;
    private float rotate_Angle;
    private bool rotate_Right;
    private bool canRotate;
    public float move_Speed = 3f;
    private float initial_Move_Speed;
    public float min_Y = -5f;
    private float initial_Y;
    private bool moveDown;
    private RopeRenderer ropeRenderer;

    private void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }
    void Start()
    {
        initial_Y = transform.position.y;
        initial_Move_Speed = move_Speed;
        canRotate = true;
    }

    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    private void Rotate()
    {
        if (!canRotate)
        {
            return;
        }

        if(rotate_Right)
        {
            rotate_Angle += rotate_Speed * Time.deltaTime;
        }
        else
        {
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);

        if(rotate_Angle >= max_z)
        {
            rotate_Right = false;
        }
        else if(rotate_Angle < min_z)
        {
            rotate_Right = true;
        }
    }
    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canRotate)
            {
                canRotate = false;
                moveDown = true;
            }
        }
    }
    void MoveRope()
    {
        if (canRotate)
        {
            return;
        }

        if(!canRotate)
        {
            Vector3 temp = transform.position;
            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime * move_Speed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * move_Speed;
            }

            transform.position = temp;

            if(temp.y <= min_Y)
            {
                moveDown = false;
            }
            if(temp.y >= initial_Y)
            {
                canRotate = true;
                ropeRenderer.RenderLine(temp, false);
                move_Speed = initial_Move_Speed;
                //moveDown = true;
            }
        }
        ropeRenderer.RenderLine(transform.position, true);
    }

    internal void HookAttachedItem()
    {
        moveDown = false;
    }
}

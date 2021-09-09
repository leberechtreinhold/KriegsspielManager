using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public const float SPEED = 100;
    public const float ACCELERATION = 1.05f;
    public float MAX_SPEED { get; set; } = SPEED * 10;

    float CurrentSpeed = SPEED;

    void Update()
    {
        bool movement_pressed = false;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement_pressed = true;
            MoveCamera(DIRECTION.UP);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement_pressed = true;
            MoveCamera(DIRECTION.RIGHT);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement_pressed = true;
            MoveCamera(DIRECTION.BOTTOM);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement_pressed = true;
            MoveCamera(DIRECTION.LEFT);
        }
        if (!movement_pressed)
        {
            CurrentSpeed = SPEED;
        }
        else
        {
            CurrentSpeed = CurrentSpeed * ACCELERATION;
            if (CurrentSpeed > MAX_SPEED)
            {
                CurrentSpeed = MAX_SPEED;
            }
        }
    }

    void MoveCamera(DIRECTION dir)
    {
        if (dir == DIRECTION.UP)
        {
            transform.Translate(transform.up * Time.deltaTime * CurrentSpeed);
        }
        else if (dir == DIRECTION.RIGHT)
        {
            transform.Translate(transform.right * Time.deltaTime * CurrentSpeed);
        }
        else if (dir == DIRECTION.BOTTOM)
        {
            transform.Translate(-transform.up * Time.deltaTime * CurrentSpeed);
        }
        else if (dir == DIRECTION.LEFT)
        {
            transform.Translate(-transform.right * Time.deltaTime * CurrentSpeed);
        }
    }
}

public enum DIRECTION
{
    UP = 0,
    RIGHT = 1,
    BOTTOM = 2,
    LEFT = 3
}

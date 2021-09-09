using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float MoveSpeed { get; private set; }
    public float MoveAcceleration { get; private set; }
    public float MoveMaxSpeed { get; private set; }

    public float ZoomSpeed { get; set; }
    public float RotationSpeed { get; set; }

    float MoveCurrentSpeed;
    ScenarioSetup Scenario;
    new Camera camera;
    
    public void OnLoadScenario(ScenarioSetup loaded_scenario)
    {
        Scenario = loaded_scenario;
        camera = Camera.main;
        float half_width = (float)Scenario.WidthMapMeters / 2;
        camera.orthographicSize = half_width;
        camera.transform.SetPositionAndRotation(new Vector3(half_width, half_width, -10), Quaternion.identity);

        MoveSpeed = (float)Scenario.WidthMapMeters / 100;
        MoveAcceleration = MoveSpeed / 30;
        MoveMaxSpeed = (float)Scenario.WidthMapMeters / 5;
        MoveCurrentSpeed = MoveSpeed;
        
        ZoomSpeed = (float)Scenario.WidthMapMeters * 3;
        RotationSpeed = 30;
    }

    void Update()
    {
        bool movement_pressed = false;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movement_pressed = true;
            MoveCamera(DIRECTION.UP);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movement_pressed = true;
            MoveCamera(DIRECTION.RIGHT);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            movement_pressed = true;
            MoveCamera(DIRECTION.BOTTOM);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movement_pressed = true;
            MoveCamera(DIRECTION.LEFT);
        }

        if (!movement_pressed)
        {
            MoveCurrentSpeed = MoveSpeed;
        }
        else
        {
            MoveCurrentSpeed = MoveCurrentSpeed * (1 + Time.deltaTime * MoveAcceleration);
            if (MoveCurrentSpeed > MoveMaxSpeed)
            {
                MoveCurrentSpeed = MoveMaxSpeed;
            }
        }

        if (Math.Abs(Input.mouseScrollDelta.y) > 0f)
        {
            ZoomCamera(Input.mouseScrollDelta.y > 0f ? ZOOM.IN : ZOOM.OUT);
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            RotateCamera(ROTATION.CLOCKWISE);
        }
        if (Input.GetKey(KeyCode.E))
        {
            RotateCamera(ROTATION.COUNTERCLOCKWISE);
        }

    }

    void MoveCamera(DIRECTION dir)
    {
        if (dir == DIRECTION.UP)
        {
            transform.Translate(transform.up * Time.deltaTime * MoveCurrentSpeed, Space.World);
        }
        else if (dir == DIRECTION.RIGHT)
        {
            transform.Translate(transform.right * Time.deltaTime * MoveCurrentSpeed, Space.World);
        }
        else if (dir == DIRECTION.BOTTOM)
        {
            transform.Translate(-transform.up * Time.deltaTime * MoveCurrentSpeed, Space.World);
        }
        else if (dir == DIRECTION.LEFT)
        {
            transform.Translate(-transform.right * Time.deltaTime * MoveCurrentSpeed, Space.World);
        }
    }

    void ZoomCamera(ZOOM dir)
    {
        camera.orthographicSize += (int)dir * Time.deltaTime * ZoomSpeed;
    }

    void RotateCamera(ROTATION dir)
    {
        var angle = camera.transform.rotation.eulerAngles;
        camera.transform.rotation = Quaternion.Euler(0, 0, angle.z + (int)dir * Time.deltaTime * RotationSpeed);
    }
}

public enum DIRECTION
{
    UP = 0,
    RIGHT = 1,
    BOTTOM = 2,
    LEFT = 3
}

public enum ZOOM
{
    IN = -1,
    OUT = 1
}

public enum ROTATION
{
    CLOCKWISE = -1,
    COUNTERCLOCKWISE = 1
}

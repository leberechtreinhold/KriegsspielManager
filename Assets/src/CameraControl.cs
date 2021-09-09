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
        MoveAcceleration = MoveSpeed / 50;
        MoveMaxSpeed = (float)Scenario.WidthMapMeters / 5;
        MoveCurrentSpeed = MoveSpeed;
        
        ZoomSpeed = (float)Scenario.WidthMapMeters * 2;
    }

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
        if (Math.Abs(Input.mouseScrollDelta.y) > 0f)
        {
            ZoomCamera(Input.mouseScrollDelta.y > 0f ? ZOOM.IN : ZOOM.OUT);
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
            Debug.Log(MoveCurrentSpeed);
        }
    }

    void MoveCamera(DIRECTION dir)
    {
        if (dir == DIRECTION.UP)
        {
            transform.Translate(transform.up * Time.deltaTime * MoveCurrentSpeed);
        }
        else if (dir == DIRECTION.RIGHT)
        {
            transform.Translate(transform.right * Time.deltaTime * MoveCurrentSpeed);
        }
        else if (dir == DIRECTION.BOTTOM)
        {
            transform.Translate(-transform.up * Time.deltaTime * MoveCurrentSpeed);
        }
        else if (dir == DIRECTION.LEFT)
        {
            transform.Translate(-transform.right * Time.deltaTime * MoveCurrentSpeed);
        }
    }

    void ZoomCamera(ZOOM dir)
    {
        camera.orthographicSize += (int)dir * Time.deltaTime * ZoomSpeed;
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

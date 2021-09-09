using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScenarioLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var scenario = ScenarioSetup.GetTestScenario();
        LoadSprite("Map", scenario.MapImagePath, scenario.WidthMapMeters);
        var camera = Camera.main;
        float half_width = (float)scenario.WidthMapMeters / 2;
        camera.orthographicSize = half_width;
        camera.transform.SetPositionAndRotation(new Vector3(half_width, half_width, -10), Quaternion.identity);

        camera.GetComponent<CameraControl>().MAX_SPEED = (float)scenario.WidthMapMeters / 10;
    }

    public void LoadSprite(string name, string file_path, double width_meters)
    {
        Texture2D texture;
        byte[] file_data;

        if (File.Exists(file_path))
        {
            file_data = File.ReadAllBytes(file_path);
            texture = new Texture2D(1, 1);
            if (texture.LoadImage(file_data))
            {
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), (float)(texture.width/width_meters));
                GameObject game_obj = new GameObject();
                game_obj.name = name;
                var sprite_renderer = game_obj.AddComponent<SpriteRenderer>();
                sprite_renderer.sprite = sprite;

            }
        }
    }

}

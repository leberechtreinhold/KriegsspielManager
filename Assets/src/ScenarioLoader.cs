using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScenarioLoader : MonoBehaviour
{
    ScenarioSetup Current = null;

    void Start()
    {
        Current = ScenarioSetup.GetTestScenario();
        LoadSprite("Map", Current.MapImagePath, Current.WidthMapMeters);

        Camera.main.gameObject.GetComponent<CameraControl>().OnLoadScenario(Current);
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

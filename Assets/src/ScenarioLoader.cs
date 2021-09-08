using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScenarioLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Current dir is {Directory.GetCurrentDirectory()}");
        LoadSprite("Map", "Assets/ScenarioExamples/suomussalmi.png");
    }

    public void LoadSprite(string name, string file_path)
    {
        Texture2D texture;
        byte[] file_data;

        if (File.Exists(file_path))
        {
            file_data = File.ReadAllBytes(file_path);
            texture = new Texture2D(1, 1);
            if (texture.LoadImage(file_data))
            {
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
                GameObject game_obj = new GameObject();
                game_obj.name = name;
                var sprite_renderer = game_obj.AddComponent<SpriteRenderer>();
                sprite_renderer.sprite = sprite;

            }
        }
    }

}

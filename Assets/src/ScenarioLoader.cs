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
        LoadTroop(new Troop
        {
            FullName = "Full name bla",
            ShortName = "1ujsfdf",
            Pos = new Vector2(10000, 10000)
        }, (float)Current.Settings.FrontageMeters, (float)Current.Settings.FrontageMeters / 2);

        Camera.main.gameObject.GetComponent<CameraControl>().OnLoadScenario(Current);
    }

    public void LoadTroop(Troop troop, float width, float depth)
    {
        Texture2D texture = Texture2D.blackTexture;
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 1);
        GameObject game_obj = new GameObject();
        game_obj.name = troop.FullName;
        var sprite_renderer = game_obj.AddComponent<SpriteRenderer>();
        sprite_renderer.sprite = sprite;
        sprite_renderer.material = Resources.Load<Material>("TroopMaterial");
        game_obj.transform.position = new Vector3(troop.Pos.x, troop.Pos.y, -1);
        game_obj.transform.localScale = new Vector3(width, depth, 1);
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
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), (float)(texture.width / width_meters));
                GameObject game_obj = new GameObject();
                game_obj.name = name;
                var sprite_renderer = game_obj.AddComponent<SpriteRenderer>();
                sprite_renderer.sprite = sprite;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSetup
{
    public string MapImagePath { get; set; }
    public double WidthMapMeters { get; set; }
    public List<Officer> Officers { get; set; }
    public ScenarioSettings Settings { get; set; }
    public ScenarioSetup() { }

    public static ScenarioSetup GetTestScenario()
    {
        var scenario = new ScenarioSetup();
        scenario.MapImagePath = "Assets/ScenarioExamples/suomussalmi.png";
        scenario.WidthMapMeters = 20000;
        scenario.Officers = new List<Officer>
        {
            new Officer
            {
                Side = "Finland",
                Name = "Siilasvuo",
                Superior = null,
                Subordinates = null,
                Tint = Color.blue,
                Troops = new List<Troop>
                {
                    new Troop
                    {
                        ShortName = "27RR/I",
                        FullName = "9 Division, 27 RR, I Battalion",
                        Pos = new Vector2(1000, 1000)
                    },
                    new Troop
                    {
                        ShortName = "27RR/II",
                        FullName = "9 Division, 27 RR, II Battalion",
                        Pos = new Vector2(2000, 1000)
                    },
                    new Troop
                    {
                        ShortName = "27RR/III",
                        FullName = "9 Division, 27 RR, III Battalion",
                        Pos = new Vector2(3000, 1000)
                    },
                }
            },
            new Officer
            {
                Side = "URSS",
                Name = "Ivan Dashichev",
                Superior = null,
                Subordinates = null,
                Tint = Color.red,
                Troops = new List<Troop>
                {
                    new Troop
                    {
                        ShortName = "662RR/I",
                        FullName = "163rd Div, 662 RR, I Battalion",
                        Pos = new Vector2(1000, 10000)
                    },
                    new Troop
                    {
                        ShortName = "662RR/II",
                        FullName = "163rd Div, 662 RR, II Battalion",
                        Pos = new Vector2(2000, 10000)
                    },
                    new Troop
                    {
                        ShortName = "662RR/III",
                        FullName = "163rd Div, 662 RR, III Battalion",
                        Pos = new Vector2(3000, 10000)
                    },
                }
            },
        };

        scenario.Settings = new ScenarioSettings
        {
            FrontageMeters = 200
        };
        return scenario;
    }
}

public class Officer
{
    public Officer Superior { get; set; }
    public List<Officer> Subordinates { get; set; }
    public string Name { get; set; }
    public string Side { get; set; }
    public List<Troop> Troops { get; set; }
    public UnityEngine.Color Tint { get; set; }
    public Officer() { }
}

public class Troop
{
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public Vector2 Pos { get; set; }
    public Troop() { }
}

public class ScenarioSettings
{
    public double FrontageMeters { get; set; }

}
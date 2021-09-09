using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSetup
{
    public ScenarioSetup() { }

    public string MapImagePath { get; set; }

    public double WidthMapMeters { get; set; }

    public static ScenarioSetup GetTestScenario()
    {
        var scenario = new ScenarioSetup();
        scenario.MapImagePath = "Assets/ScenarioExamples/suomussalmi.png";
        scenario.WidthMapMeters = 20000;

        return scenario;
    }
}

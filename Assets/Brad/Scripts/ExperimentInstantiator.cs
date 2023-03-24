using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExperimentInstantiator : MonoBehaviour
{

    public string csvFileName;
    public string variableFileName;



    void Awake()
    {
        csvFileName = "ExperimentBuilder.csv";
        // Get the path to the CSV file using Application.dataPath, "Brad" folder, and "csvFiles" subfolder
        string csvFilePath = Path.Combine(Application.persistentDataPath, csvFileName);

        // Read the CSV file into a string array
        string[] lines = File.ReadAllLines(csvFilePath);

        // Parse the CSV data and store it in a 2D array
        GlobalVars.setupData = new string[lines.Length, 3];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');
            GlobalVars.setupData[i, 0] = fields[0]; // LevelName
            GlobalVars.setupData[i, 1] = fields[1]; // Block
            GlobalVars.setupData[i, 2] = fields[2]; // Version

        }

        variableFileName = "VariableSetup.csv";

        string variableFilePath = Path.Combine(Application.persistentDataPath, variableFileName);

        // Read the CSV file into a string array
        string[] variableLines = File.ReadAllLines(variableFilePath);

        // Parse the CSV data and store it in a 2D array
        GlobalVars.variableData = new string[variableLines.Length, 2];
        for (int i = 0; i < variableLines.Length; i++)
        {
            string[] vFields = variableLines[i].Split(',');
            GlobalVars.variableData[i, 0] = vFields[0]; // variable
            GlobalVars.variableData[i, 1] = vFields[1]; // value

        }

        GlobalVars.baselineDuration = float.Parse(GlobalVars.variableData[1, 1]);

        GlobalVars.conditionList = new List<string> { "Neutral1", "Neutral2", "Negative1", "Negative2", "Positive1", "Positive2" };

    }


    void Update()
    {
        
    }
}

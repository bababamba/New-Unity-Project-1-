using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private List<List<int>> ReadCSV(TextAsset file)
    {
        List<List<int>> data = new List<List<int>>();

        string[] lines = file.text.Split('\n');
        foreach (string line in lines)
        {

            string[] values = line.Split(',');

            List<int> row = new List<int>();

            foreach (string value in values)
            {
                int intValue;
                if (int.TryParse(value, out intValue))
                {
                    row.Add(intValue);
                }
                else
                {
                    Debug.LogError("Failed to parse int value: " + value);
                }
            }

            data.Add(row);
        }

        return data;
    }
}

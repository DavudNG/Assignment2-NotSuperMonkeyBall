using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ReadWrite : MonoBehaviour
{
    public static string filePath = "MyPath.txt";
    public static bool CheckAttribute(String attribute)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            string[] storeLine;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(attribute))
                {
                    storeLine = line.Split('=');
                    if (storeLine[1] == "1")
                    {
                        return true;
                    }
                }
            }

            //string lineB = reader.ReadLine();
            //Debug.Log("line b: " + lineB);
            //string[] splitB = lineB.Split('=');
            //scoreB = int.Parse(splitB[1]);
            //Debug.Log("scoreB: " + scoreB);
        }
        return false;
    }

    public static void WriteAttribute(String attribute, String value)
    {
        string[] lines = File.ReadAllLines(filePath);
        string[] storeSplit;

        for (int i = 0; i < lines.Length; i++)
        {
            if (i <= lines.Length)
            {
                if (lines[i].Contains(attribute))
                {
                    storeSplit = lines[i].Split('=');
                    lines[i] = storeSplit[0] + "=" + value;
                    //Debug.Log("this the updated line: " + lines[i].ToString());
                }
            }
        }
        File.WriteAllLines(filePath, lines);
    }
}

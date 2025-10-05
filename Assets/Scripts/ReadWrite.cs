using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/*
    ReadWrite.cs
    Author: James
    Desc: This script can read and write key/value pairs in a textfile
*/

public class ReadWrite : MonoBehaviour
{
    public static string filePath = "MyPath.txt"; // Get the file path to the text file
    public static bool CheckAttribute(String attribute) // Function to return true or false according to the value of a key in the text file
    {
        using (StreamReader reader = new StreamReader(filePath)) // Open a StreamReader to get the text file data
        {
            string line; // Variable to store the line being currently read
            string[] storeLine; // Array to store the key and value in a line in the text file
            while ((line = reader.ReadLine()) != null) // While not at the end of the text file
            {
                if (line.Contains(attribute)) // If the line contains the attribute in the parameter
                {
                    storeLine = line.Split('='); // Split the line into its key and value and store it into the storeLine variable
                    if (storeLine[1] == "true") // If the attribute is "true" return true
                    {
                        return true; // If the attribute is "true" return true
                    }
                }
            }
        }
        return false; // Return false if all else failed
    }
    public static string ReturnAttribute(String attribute) // Function to return the string value of a key in the text file
    {
        using (StreamReader reader = new StreamReader(filePath)) // Open a StreamReader to get the text file data
        {
            string line; // Variable to store the line being currently read
            string[] storeLine; // Array to store the key and value in a line in the text file
            while ((line = reader.ReadLine()) != null) // While not at the end of the text file
            {
                if (line.Contains(attribute)) // If the line contains the attribute in the parameter
                {
                    storeLine = line.Split('='); // Split the line into its key and value and store it into the storeLine variable
                    return storeLine[1]; // Return the value of the key
                }
            }
        }
        return null; // Return false if all else failed
    }

    public static void WriteAttribute(String attribute, String value) // Function to write a value to a key in the text file
    {
        string[] lines = File.ReadAllLines(filePath); // Store all the lines of the text file
        string[] storeSplit; // Empty array to store the updated line in the text file

        for (int i = 0; i < lines.Length; i++) // For the amount of entries in the text file
        {
            if (i <= lines.Length) // If i is less than or equal to the amount of entries in the text file
            {
                if (lines[i].Contains(attribute)) // If a line in the text file contains the attribute specified in the parameter
                {
                    storeSplit = lines[i].Split('='); // Store the key and value of the line
                    lines[i] = storeSplit[0] + "=" + value; // Update the value according to the value in the parameter
                }
            }
        }
        File.WriteAllLines(filePath, lines); // Write the lines back to the text file, which may contain the updated line should the function have worked
    }
}

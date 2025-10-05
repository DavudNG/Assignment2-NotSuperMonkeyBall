using UnityEngine;
using System.IO;

public static class Paths
{
    public static readonly string SaveFilePath = Path.Combine(
        Application.persistentDataPath, "scores.txt"
    );
}

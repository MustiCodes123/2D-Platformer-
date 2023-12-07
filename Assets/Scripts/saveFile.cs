using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.VisualScripting;
public interface savePersistence
{
    void Save(int playerNum);
}
public class saveFile : MonoBehaviour, savePersistence
{
    public Text scoreText;
    public Transform lastCoords;

    void Start()
    {

    }
    void Update()
    {

    }

    public void Save(int playerNum)
    {

        string fileName = "File" + playerNum + ".txt";
        string folderPath = Directory.GetCurrentDirectory() + "/Assets/SaveFiles";
        string filePath = Path.Combine(folderPath, fileName);

        string[] tokens = scoreText.text.Split(' ');

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // If the file exists, update the values
            string[] lines = File.ReadAllLines(filePath);

            // Update the values
            lines[0] = tokens[1];
            lines[1] = lastCoords.position.y.ToString();
            lines[2] = lastCoords.position.x.ToString();

            // Write the updated values back to the file
            File.WriteAllLines(filePath, lines);
        }
        else
        {
            // If the file doesn't exist, create a new one
            string[] lines = {
                    tokens[1],
                    lastCoords.position.y.ToString(),
                    lastCoords.position.x.ToString()
                };

            // Write the lines to the file
            File.WriteAllLines(filePath, lines);
        }

        Debug.Log("Player data saved to: " + filePath);

    }


}

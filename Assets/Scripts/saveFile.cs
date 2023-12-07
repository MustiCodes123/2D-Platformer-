using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.VisualScripting;
public interface savePersistence
{
    void Save();
}
public class saveFile : MonoBehaviour, savePersistence
{
    public Text scoreText;
    public Text tTime;
    public Transform lastCoords;

    void Start()
    {
        Save();
    }
    void Update()
    {

    }

    public void Save()
    {
        int playerNum = PersistentParams.fileParameter;
        string fileName = "File" + playerNum + ".txt";
        string folderPath = Directory.GetCurrentDirectory() + "/Assets/SaveFiles";
        string filePath = Path.Combine(folderPath, fileName);

        string[] tokens = scoreText.text.Split(' ');
        string[] tokens2 = tTime.text.Split(' ');

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // If the file exists, update the values
            string[] lines = File.ReadAllLines(filePath);

            // Update the values
            lines[0] = "Player" + playerNum;
            lines[1] = tokens[1];
            lines[2] = tokens2[1];
            lines[3] = lastCoords.position.y.ToString();
            lines[4] = lastCoords.position.x.ToString();

            // Write the updated values back to the file
            File.WriteAllLines(filePath, lines);
        }
        else
        {
            // If the file doesn't exist, create a new one
            string[] lines = {
                    "Player" + playerNum,
                    tokens[1],
                    tokens2[1],
                    lastCoords.position.y.ToString(),
                    lastCoords.position.x.ToString()
                };

            // Write the lines to the file
            File.WriteAllLines(filePath, lines);
        }

        Debug.Log("Player data saved to: " + filePath);

    }


}

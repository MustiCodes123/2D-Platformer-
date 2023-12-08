using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.VisualScripting;
using System.IO.Enumeration;
// public interface savePersistence
// {
//     void Save();
//     void load();
// }

public class saveFile : MonoBehaviour //, savePersistence
{
    public Text scoreText;
    public Text tTime;
    public Transform lastCoords;
    public Transform player;
    int playerNum = PersistentParams.fileParameter;
    string fileName;
    string folderPath = Directory.GetCurrentDirectory() + "/Assets/SaveFiles";
    string filePath;

    void Start()
    {
        if (playerNum < 10)
        {
            Save();
        }
        else
        {
            playerNum -= 10;
            load();
        }
    }
    void Update()
    {

    }

    public void Save()
    {

        fileName = "File" + playerNum + ".txt";
        filePath = Path.Combine(folderPath, fileName);


        // Check if the file exists
        if (File.Exists(filePath))
        {
            // If the file exists, update the values
            string[] lines = File.ReadAllLines(filePath);

            // Update the values
            lines[0] = "Player" + playerNum;
            lines[1] = scoreText.text;
            lines[2] = tTime.text;
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
                    scoreText.text,
                    tTime.text,
                    lastCoords.position.y.ToString(),
                    lastCoords.position.x.ToString()
                };

            // Write the lines to the file
            File.WriteAllLines(filePath, lines);
        }

        Debug.Log("Player data saved to: " + filePath);

    }

    public void load()
    {

        fileName = "File" + playerNum + ".txt";
        filePath = Path.Combine(folderPath, fileName);
        string[] lines = File.ReadAllLines(filePath);

        scoreText.text = lines[1];
        //Debug.Log(scoreText.text);
        tTime.text = lines[2];
        string[] tokens = tTime.text.Split(" ");
        string time = tokens[1];
        PersistentParams.mins = time.Split(":")[0];
        PersistentParams.secs = time.Split(":")[1];

        player.transform.position = new Vector3(float.Parse(lines[4]), float.Parse(lines[3]), 0);

    }


}

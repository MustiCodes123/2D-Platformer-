using UnityEngine;
using UnityEngine.UI;
using System.IO;
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
         //   load();
        }
    }
    void Update()
    {

    }

    public void Save()
    {
        Debug.Log("SAVE FUNCTION CALLEDDDDDD");
        fileName = "File" + playerNum + ".txt";
        filePath = Path.Combine(folderPath, fileName);

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
            lines[3] = lastCoords.position.x.ToString();
            lines[4] = lastCoords.position.y.ToString();

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
                    lastCoords.position.x.ToString(),
                    lastCoords.position.y.ToString()
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

        scoreText.text = "Score: " + lines[1];
        Debug.Log(scoreText.text);
        tTime.text = "Time: " + lines[2];
        player.transform.position.Set(float.Parse(lines[4]), float.Parse(lines[3]), 0);

    }


}

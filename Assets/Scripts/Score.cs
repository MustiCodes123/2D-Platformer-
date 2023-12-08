using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Score : MonoBehaviour
{
    public Transform player; // Reference to your player GameObject
    public Text scoreText; // Reference to the UI Text element for displaying the score

    public float highestHeight; // Keeps track of the highest height reached by the player
    private float score; // Current score based on vertical height
    string folderPath = Directory.GetCurrentDirectory() + "/Assets/SaveFiles";

    void Start()
    {
        highestHeight = player.position.y; // Initialize the highest height as the initial player position
        int fileNum = PersistentParams.fileParameter;
        if (fileNum > 10)
            fileNum -= 10;
        string fileName = "File" + fileNum + ".txt";
        string filePath = Path.Combine(folderPath, fileName);
        string[] lines = File.ReadAllLines(filePath);

        score = float.Parse(lines[1]); // Initialize the score
    }

    void Update()
    {
        if (player != null)
        {
            // Update the highestHeight if the player's current y position is higher
            if (player.position.y > highestHeight)
            {
                highestHeight = player.position.y;
                score = highestHeight; // Use the highestHeight as the score
            }

            // Update the UI text element to display the score
            if (scoreText != null)
            {
                scoreText.text = "Score: " + Mathf.Round(score).ToString();
            }
        }
    }

    public float ReturnScore()
    {

        return highestHeight;
    }
}

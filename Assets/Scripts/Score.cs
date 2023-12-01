using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player; // Reference to your player GameObject
    public Text scoreText; // Reference to the UI Text element for displaying the score

    private float highestHeight; // Keeps track of the highest height reached by the player
    private float score; // Current score based on vertical height

    void Start()
    {
        highestHeight = player.position.y; // Initialize the highest height as the initial player position
        score = 0f; // Initialize the score
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
}

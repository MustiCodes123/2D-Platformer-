using UnityEngine;
using UnityEngine.UI;


public class TimeCalculator : MonoBehaviour
{
    public Text timeText; // Reference to the UI Text element for displaying the time

    private float currentTime; // Current time in seconds

    void Start()
    {


        // UnityEngine.Debug.Log(PersistentParams.mins);
        // UnityEngine.Debug.Log(PersistentParams.secs);

        if (!PersistentParams.isLoading)
        {
            currentTime = 1f;
        }
        else
        {
            currentTime = float.Parse(PersistentParams.mins) * 60 + float.Parse(PersistentParams.secs);
        }

        UpdateTimeDisplay();
        InvokeRepeating(nameof(UpdateTime), 1f, 1f); // Invoke UpdateTime every 1 second
    }

    void UpdateTime()
    {
        currentTime += 1f; // Increment time by 1 second
        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        // Update the UI text element to display the time
        if (timeText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            timeText.text = "Time: " + timeString;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class loadFile : MonoBehaviour
{
    //public GameObject button;

    public Text[] buttonsText;
    public Text scoreText;
    public Transform monkey;

    public int fileCount;

    public string[] fileIndexes;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void displayLoadButtons()
    {

        string folderPath = Directory.GetCurrentDirectory() + "/Assets/SaveFiles";
        string fileName;
        string filePath;

        fileName = "File2" + ".txt";
        filePath = Path.Combine(folderPath, fileName);

        for (int i = 0; i < fileCount; i++)
        {

            fileName = "File" + fileIndexes[i];
            filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                buttonsText[i].text = fileName;
            }
            else
                buttonsText[i].text = "No File Available";


        }



    }

    public void load(int num)
    {
        string folderPath = Directory.GetCurrentDirectory() + "/Assets/SaveFiles";
        string fileName = "File" + num + ".txt";
        string filePath = Path.Combine(folderPath, fileName);

        if (File.Exists(filePath))
        {

            string[] lines = File.ReadAllLines(filePath);

            scoreText.text = lines[0];
            monkey.transform.position.Set(float.Parse(lines[1]), float.Parse(lines[2]), 0);

            Debug.Log("Player data loaded");
        }
        else
            Debug.Log("File not found");


    }
}

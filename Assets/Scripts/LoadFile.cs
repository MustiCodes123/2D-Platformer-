using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class loadFile : MonoBehaviour
{
    //public GameObject button;

    public Text[] buttonsText;

    public int fileCount;

    public string[] fileIndexes;
    // Start is called before the first frame update
    void Start()
    {
        string folderPath = Directory.GetCurrentDirectory() + "/Assets/SaveFiles";
        string fileName;
        string filePath;

        for (int i = 0; i < fileCount; i++)
        {

            fileName = "File" + fileIndexes[i] + ".txt";
            filePath = Path.Combine(folderPath, fileName);
            //Debug.Log(fileName);
            if (File.Exists(filePath))
            {
                Debug.Log("File Found");
                string[] lines = File.ReadAllLines(filePath);
                buttonsText[i * 3].text = lines[0];
                buttonsText[i * 3 + 1].text = "Score: " + lines[1];
                buttonsText[i * 3 + 2].text = "Time: " + lines[2];

            }
            else
            {
                //Debug.Log("No file available");
                buttonsText[i * 3].text = "No File Available";
                buttonsText[i * 3 + 1].text = "Score: <>";
                buttonsText[i * 3 + 2].text = "Time: <>";
            }


        }
    }

    public void setFileNum(int fileNum)
    {
        string folderPath = Directory.GetCurrentDirectory() + "/Assets/SaveFiles";
        string fileName;

        if (fileNum > 10)
        {
            fileName = "File" + (fileNum - 10) + ".txt";
        }
        else
            fileName = "File" + fileNum + ".txt";

        string filePath = Path.Combine(folderPath, fileName);



        PersistentParams.fileParameter = fileNum;

        if (File.Exists(filePath) && fileNum > 10)
        {

            SceneManager.LoadScene("Game");
        }
        else if (fileNum < 10)
        {

            SceneManager.LoadScene("Game");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }


}

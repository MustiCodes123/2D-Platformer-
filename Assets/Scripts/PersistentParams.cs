using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentParams : MonoBehaviour
{
    // Start is called before the first frame update

    public static int fileParameter;
    public static bool isLoading = false;

    public static string mins;
    public static string secs;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

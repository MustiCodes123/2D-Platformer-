using UnityEngine;

public class PersistentParams : MonoBehaviour
{
    // Start is called before the first frame update

    public static int fileParameter;
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

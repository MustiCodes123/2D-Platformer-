using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public Transform audSettings;
    public Transform vidSettings;
    public Transform mainSettings;
    bool isAud = false;
    bool isVid = false;

    // Start is called before the first frame update
    void Start()
    {
        isAud = false;
        isVid = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAud)
            audSettings.gameObject.SetActive(false);
        if (!isVid)
            vidSettings.gameObject.SetActive(false);
    }
    public void OnAudioButton()
    {
        isAud = true;
        audSettings.gameObject.SetActive(true);
        mainSettings.gameObject.SetActive(false);
    }
    public void OnVideoButton()
    {
        isVid = true;
        vidSettings.gameObject.SetActive(true);
        mainSettings.gameObject.SetActive(false);
    }
    public void OnAudBackButton()
    {
        isAud = false;
        audSettings.gameObject.SetActive(false);
        mainSettings.gameObject.SetActive(true);
    }
    public void OnVidBackButton()
    {
        isVid = false;
        vidSettings.gameObject.SetActive(false);
        mainSettings.gameObject.SetActive(true);
    }
}

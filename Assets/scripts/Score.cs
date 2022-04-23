using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    void Update()
    {
        text.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }
}

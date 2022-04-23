using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("prototype");
    }

    public void Quite()
    {
        Application.Quit();
    }
}

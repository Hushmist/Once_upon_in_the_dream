using UnityEngine;
using UnityEngine.SceneManagement;


public class restart : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("prototype");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.UI;

public class setRosolution : MonoBehaviour
{
    public Dropdown dropdown;

    public void Change()
    {
        if(dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, true);

        }
        else if(dropdown.value == 1)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else if(dropdown.value == 2)
        {
            Screen.SetResolution(1366, 768, true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

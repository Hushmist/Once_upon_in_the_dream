using UnityEngine;
using UnityEngine.UI;


public class healthBarBadBoy : MonoBehaviour
{
    public Image healthBar;
    public badboy enemy;
    void Start()
    {
    }

    void Update()
    {
        healthBar.fillAmount = (float)enemy.health / enemy.getMaxHealth();
    }
}

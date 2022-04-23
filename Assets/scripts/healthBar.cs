using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image HealthBar;
    public playerControl player;
    private float HP;
    private float maxHP;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HP = player.health;
        maxHP = player.getMaxHealth();
        HealthBar.fillAmount = (float)HP / maxHP;
    }
}

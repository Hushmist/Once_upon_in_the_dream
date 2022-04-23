using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{
    private float tempSpeed;
    private bool isPlayer = false;
    private bool isOpen = false;
    public playerControl player;
    public GameObject button;

    public GameObject collision;
    // Update is called once per frame
    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            tempSpeed = player.GetComponent<playerControl>().speed;
            player.GetComponent<playerControl>().speed = 0;
            isOpen = true;
        } 
        else if(isPlayer && Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            //button.gameObject.SetActive(false);
            player.GetComponent<playerControl>().speed = tempSpeed;
            isOpen = false;
        }
        if(isOpen)
        {
            collision.gameObject.SetActive(true);
        }
        else if(!isOpen)
        {
            collision.gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        isPlayer = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    private float startTimeBtmWork = 1f;
    private float timeBtmWor;
    private bool isPlayer = false; 
    public GameObject pointWhereTeleport;
    private Collider2D collision;

    void Update()
    {
        if(isPlayer && collision && Input.GetKeyDown(KeyCode.E) && timeBtmWor <= 0)
        {
            collision.gameObject.SetActive(false);
            collision.transform.position = new Vector3(pointWhereTeleport.transform.position.x, pointWhereTeleport.transform.position.y, pointWhereTeleport.transform.position.z);
            collision.gameObject.SetActive(true);
            timeBtmWor = startTimeBtmWork;
            isPlayer = false;
        }
        else
        {
            timeBtmWor -= Time.deltaTime;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
            collision = other;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        isPlayer = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    public float multi = 2f;
    public GameObject player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        offset.x = player.GetComponent<playerControl>().moveX * multi;
        transform.position = new Vector3(player.transform.position.x + offset.x , player.transform.position.y + offset.y, -10);
    }
}
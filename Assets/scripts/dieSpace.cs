using UnityEngine;

public class dieSpace : MonoBehaviour
{
    public GameObject respawn;
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.transform.position = respawn.transform.position;
        }
    }
}

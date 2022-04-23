using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    public float speed = 20f;
    public int health = 10;
    private int maxHealth;
    public float moveX;
    private Rigidbody2D rb;
    private bool FaceRight = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            animator.Play("death");
        }
        moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
       

        if(moveX > 0 && !FaceRight)
        {
            flip();
        }
        else if(moveX < 0 && FaceRight)
        {
            flip();
        }
        if(animator)
        {
            animator.SetBool("Run", Mathf.Abs(moveX) >= 0.1f);
        }

    }
    void flip()
    {
        FaceRight = !FaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("hurt");
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int faceRight()
    {
        if(FaceRight)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
    public void Dead()
    {
        animator.Play("dead");
    }
    public void Restart()
    {
        SceneManager.LoadScene("prototype");
    }
}

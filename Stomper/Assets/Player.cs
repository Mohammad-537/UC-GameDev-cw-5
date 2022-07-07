using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Player : MonoBehaviour
{
    [Range(0,100)]public float speed = 100;
    public int Jump = 10;
    Rigidbody2D rb;
    public bool isGrounded;
    [Tooltip("THis is the jumb force")]public Transform jumbPoint;
    [Header("Radius")]public float radius;
    public LayerMask whatIsGround;
    public Animator anim;
    int health = 3;
    [SerializeField] private TextMeshProUGUI healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            SceneManager.LoadScene("level-1");
        }
        else if(health == 3)
        {
            healthBar.text = "<3<3<3";
        }
        else if (health == 2)
        {
            healthBar.text = "<3<3";
        }
        else if (health == 1)
        {
            healthBar.text = "<3";
        }

        //Vector2 temp = rb.velocity;

        if (Input.GetKey(KeyCode.D))
        {
            walk();
            anim.SetBool("Speed", true);

            rb.velocity = Vector2.right * speed;
            //rb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            walk();
            //transform.Rotate(new Vector3(0, 180, 0));
            //anim.SetBool("Speed", true);
            rb.velocity = Vector2.left * speed;
            //rb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
        }

        
        isGrounded = Physics2D.OverlapCircle(jumbPoint.position, radius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumb();

            if (isGrounded == true)
            {
                rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                
            }
            

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Ideal();
            //anim.SetBool("Speed", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //anim.SetBool("Speed", false);
            Ideal();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //anim.SetBool("Speed", false);
            Ideal();
        }
        //anim.SetBool("jump Animation", true);
        //anim.SetBool("Player Animation", true);
        //anim.SetBool("Walk Animation", Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.A)));

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(jumbPoint.position,radius);


    }
    void Ideal()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Speed", false);
    }
    void walk()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Speed", true);
    }
    void Jumb()
    {
        anim.SetBool("Jump", true);
        anim.SetBool("Speed", false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("enemy"))
        {
            if (isGrounded == false)
            {
                Destroy(other.gameObject);
            }
            else
            {
                health -= 1;
            }
            
            
        }
    }
    
}

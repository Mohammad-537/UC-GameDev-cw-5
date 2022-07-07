using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(bot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator bot()
    {
        while (true)
        {
            rb.velocity = Vector2.right * speed;
        
        yield return new WaitForSeconds(2);

        rb.velocity = Vector2.left * speed;
        yield return new WaitForSeconds(2);
            
        }
    }

   
}

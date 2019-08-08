using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.07f;
    bool blockKeyLeft = false;                  // block keys when pressing both keys to disable speeding it up with moving it only 1 direction
    bool blockKeyRight = false;
    private int limitMovement;                          // the max value player can move to(limited map)
    private Rigidbody2D rb;
    private Vector2 change;
    // Start is called before the first frame update
    void Start()
    {
        change = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        blockKeyLeft = false;
        blockKeyRight = false;
        if (change != Vector2.zero)
        {
            if (change.x != 0 && change.y != 0)
            {
                MakeMovementCrosswise();
            }
            else MakeMovement();


        }
    }
    void MakeMovement() {
        rb.MovePosition((Vector2)transform.position + change * speed);
    }
    void MakeMovementCrosswise()
    {
        rb.MovePosition((Vector2)transform.position + change * (speed)/1.25f);
    }

}

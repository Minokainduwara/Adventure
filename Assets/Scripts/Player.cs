using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;
    private RaycastHit2D hit;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset Move Delta
        moveDelta = new Vector3(x,y,0);

        //Swap the sprite direction
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Make sure we can move in this direction, by casting a box there first, if the box returns null, we are free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Human", "Blocking"));
        if (hit.collider == null)
        {
            //Make the character move y
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x , 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Human", "Blocking"));
        if (hit.collider == null)
        {
            //Make the character move x
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Movement : MonoBehaviour {

    public float speed = 10;
    public float jumpForce = 10;

    private Vector2 movement;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private RaycastHit2D[] raycastHits = new RaycastHit2D[5];
    private Collider2D ownCollider;
    private float halfSize = 0.5f;
    private readonly float collisionEps = 0.1f;
    private bool jumpRequest;

    public void MoveWithHorizontal(float direction)
    {
        if (!isJumping)
        {
            rb.AddForce(new Vector2(direction * speed, 0));
        }
    }

    public void Jump()
    {
        if (!jumpRequest)
        {
            jumpRequest = true;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ownCollider = GetComponent<Collider2D>();
        halfSize = GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2;
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            int results = Physics2D.RaycastNonAlloc(transform.position, new Vector2(0, -1), raycastHits, halfSize + collisionEps);
            for(int i = 0; i < results; i++)
            {
                if(raycastHits[i].collider != null && raycastHits[i].collider != ownCollider)
                {
                    Debug.Log("Collider " + raycastHits[i].collider.name);
                    isJumping = false;
                }
            }
        }

        if (jumpRequest && !isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            jumpRequest = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -halfSize - collisionEps, 0));
    }


}

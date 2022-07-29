using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public bool Player1Start = true;
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraspeed;
    private int hitCounter = 0;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }

    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(2);
        if(Player1Start == true)
            MoveBall(new Vector2(-1 , 0));
        else
            MoveBall(new Vector2(1 , 0));
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if (hitCounter <= maxExtraspeed)
        {
            hitCounter++;
        }
    }
 
}

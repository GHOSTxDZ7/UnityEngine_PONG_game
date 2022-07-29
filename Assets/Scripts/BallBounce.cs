using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
   public GameObject hitSFX;
   public GameObject Celebration_Player1;
   public GameObject Celebration_Player2;
   public BallMovement ballMovement;
   public Score score;

   private void Bounce(Collision2D collision)
   {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;
        
        float positionX;
        if(collision.gameObject.name == "Player1")
            positionX = 1;
        else 
            positionX = -1;
            
        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
   }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
                Bounce(collision);
            else if(collision.gameObject.name == "Right Boder")
            {
                score.Player1Goal();
                Instantiate(Celebration_Player1);
                ballMovement.Player1Start = false;
                StartCoroutine(ballMovement.Launch());
            }
            else if(collision.gameObject.name == "Left Boder")
            {
                score.Player2Goal();
                Instantiate(Celebration_Player2);
                ballMovement.Player1Start = true;
                StartCoroutine(ballMovement.Launch());
            }

            Instantiate(hitSFX, transform.position, transform.rotation);
        }
}

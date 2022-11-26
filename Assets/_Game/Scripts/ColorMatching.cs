using UnityEngine;

public class ColorMatching : MonoBehaviour
{    
    public BallController ballController;
    [SerializeField] private CirclesData circlesData = null;
    private Vector3 _contactPoint;
   
    private void OnCollisionEnter(Collision collision)
    {
        _contactPoint = collision.contacts[0].point;
        
        if(collision.gameObject.CompareTag(ballController.ballColor.name))
        {
            Destroy(collision.collider.transform.parent.gameObject); 
        }
        else if(!(collision.gameObject.CompareTag("Death") || collision.gameObject.CompareTag("Finish")))
        {
            ballController.BallJump();
            ballController.PaintInkCreateAndDestroy(_contactPoint,collision.transform);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWinnEffect : MonoBehaviour
{
    [SerializeField] private CirclesData circlesData;
    public GameObject winnEffect;
    public GameObject winnEffectObj;
    public GameObject ball;
    private void OnCollisionEnter(Collision collision)
    {            
        if (collision.gameObject.CompareTag("Ball"))
        {
            circlesData.circleMoveAct = false;
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.GetComponent<SphereCollider>().enabled = false;
            winnEffectObj = winnEffect;
            GameObject effect = Instantiate(winnEffectObj, ball.transform.position, Quaternion.identity);
            Destroy(effect, 3);
        }
    }

}

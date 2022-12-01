using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWinnEffect : MonoBehaviour
{
    [SerializeField] private CirclesData circlesData;
    public GameObject winnEffect;
    private GameObject _winnEffectObj;
    public GameObject ball;
    public AudioClip winnSound;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {            
        if (collision.gameObject.CompareTag("Ball"))
        {
            circlesData.circleMoveAct = false;
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.GetComponent<SphereCollider>().enabled = false;
            _audioSource.PlayOneShot(winnSound);
            _winnEffectObj = winnEffect;
            GameObject effect = Instantiate(_winnEffectObj, ball.transform.position, Quaternion.identity);
            Destroy(effect, 3);
        }
    }

}

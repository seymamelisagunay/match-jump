using System;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class ColorMatching : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip breakGlassSound;
    private AudioSource _audioSource;
    public BallController ballController;
    private Vector3 _contactPoint;
    private Queue<Sequence> animationQueue = new Queue<Sequence>();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _contactPoint = collision.contacts[0].point;
       
        if(collision.gameObject.CompareTag(ballController.ballColor.name))
        {
            _audioSource.PlayOneShot(breakGlassSound);
            Destroy(collision.collider.transform.parent.gameObject);
        }
        else if(!collision.gameObject.CompareTag("Death"))
        {
           JumpEffect();
           _audioSource.PlayOneShot(jumpSound);
           ballController.BallJump();
           ballController.PaintInkCreateAndDestroy(_contactPoint + new Vector3(0f,0.1f,0f),collision.transform);
        }
    }

    public void JumpEffect()
    {
        var seq = DOTween.Sequence();
        seq.Pause();

        seq.Append(transform.DOScaleX(1f, 0.1f));
        seq.Append(transform.DOScaleX(0.8f, 0.1f));
        seq.Append(transform.DOScaleY(1f, 0.1f));
        seq.Append(transform.DOScaleY(0.8f, 0.1f));

        animationQueue.Enqueue(seq);

        animationQueue.Peek().Play();

        animationQueue.Dequeue();
    }
}

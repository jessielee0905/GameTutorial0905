using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float memSpeed = 2.0f;
    [SerializeField] private Vector2 mDirection = Vector2.right;


    private SpriteRenderer mSR = null;
    private Rigidbody2D mRB = null;
    public AudioSource sec1;

    

    protected void Start()
    {
        mSR = GetComponent<SpriteRenderer>();
        mRB = GetComponent<Rigidbody2D>();

        mRB.velocity = memSpeed * mDirection;
    }
    
    void Update()
    {
        
       if(mRB.velocity == Vector2.zero)
       {
           mDirection = -mDirection;
           mRB.velocity = memSpeed * mDirection;
    
           if(mDirection.x < 0.0f)
           {
               mSR.flipX = false;
           }
           else
           if(mDirection.x > 0.0f)
           {
               mSR.flipX = true;
           }
        }

    }




    protected void OnTriggerEnter2D(Collider2D localCollider)
    {
        GameObject localOtherObject;
        localOtherObject = localCollider.gameObject;

        if(localOtherObject.name.StartsWith("Bumper"))
        {
            mRB.velocity = Vector2.zero;
        }
    }
}
        

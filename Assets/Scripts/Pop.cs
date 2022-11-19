using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    private Rigidbody rb;
    private float randomDirX,randomDirY,randomDirZ;
    float CurrentPos;

    private void Start ( )
    {
       rb=gameObject.GetComponent<Rigidbody> ( );

       StartCoroutine ( spawn ( ) );

       CurrentPos=this.transform. position. y;
    }

    IEnumerator spawn ( )
    {
        yield return new WaitForSeconds ( 0 );

            randomDirX=Random. Range ( -100f, 100f );
            randomDirY=Random. Range ( 0f, 300f );
            randomDirZ=Random. Range ( -100f, 100f );
            rb. AddForce ( randomDirX, randomDirY, randomDirZ );

            StartCoroutine ( Fall ( ) );
    }

    IEnumerator Fall ( )
    {
        yield return new WaitForSeconds ( 0.3f );

        rb. useGravity=true;
    }

    private void Update ( )
    {
        if ( this. transform. position.y<=CurrentPos )
        {
            rb. useGravity=false;
        }



        Destroy ( this. gameObject, 15f );

    }

}


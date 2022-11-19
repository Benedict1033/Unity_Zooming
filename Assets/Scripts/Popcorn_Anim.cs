using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn_Anim : MonoBehaviour
{
    public static  Animator Anim;
    public GameObject popcorn;
    public GameObject popcorn2;

    void Start()
    {
        Anim=gameObject.GetComponent<Animator> ( );
        Anim. speed=0;
 
    }

    void Update()
    {
        if ( Anim. GetCurrentAnimatorStateInfo ( 0 ). IsName ( "popcorn 2" ) )
        {
            StartCoroutine ( one ( ) );
        }
    }

    IEnumerator one ( )
    {
        yield return new WaitForSeconds ( 0 );

        Instantiate ( popcorn, transform. position, Quaternion. identity );
      
        popcorn2. SetActive ( false );

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ps : MonoBehaviour
{
    ParticleSystem Ps;

    void Start()
    {
        Ps=GetComponent<ParticleSystem> ( );
    }

    void Update()
    {
        StartCoroutine ( waiting ( ) ); 
    }

    IEnumerator waiting ( )
    {
        if ( ContentController. Leave_Count>=1 )
        {
            yield return new WaitForSeconds ( 2f );

            var main = Ps.main;
            main. startColor=new Color ( 0f, 0f, 0f, 1 );
        }
    }
}

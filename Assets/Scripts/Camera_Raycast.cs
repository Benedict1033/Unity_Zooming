using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine. UI;

public class Camera_Raycast : MonoBehaviour
{
    public LayerMask layerMask;

    void Update ( )
    {
        if ( ContentController. Burn )
        {

            if ( ContentController. Distace>=0.3f&&ContentController. Distace<=5 )
            {

                RaycastHit hit;

                if ( Physics. Raycast ( transform. position, transform. TransformDirection ( Vector3. forward ), out hit, Mathf. Infinity, layerMask ) )
                {
                    Debug. DrawRay ( transform. position, transform. TransformDirection ( Vector3. forward )*hit. distance, Color. yellow );

                    Popcorn_Anim. Anim. speed=1;
                }
                else
                {
                    Debug. DrawRay ( transform. position, transform. TransformDirection ( Vector3. forward )*1000, Color. white );

                    Popcorn_Anim. Anim. speed=0;
                }
            }
        }
    }
}
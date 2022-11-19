using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controller : MonoBehaviour
{
    public GameObject panel_1;
    public GameObject panel_2;
    public GameObject Controller;

    public void Close ( )
    {
        panel_1. SetActive ( false );
        Controller. SetActive ( true );
    }

    public void Close2 ( )
    {
        panel_2. SetActive ( false );
    }

    public void Quit ( )
    {
        Application. Quit ( );
    }

    private void Update ( )
    {
        if ( ContentController. Plane_Detech_Count==1 )
        {
            panel_2. SetActive ( true );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;
using UnityEngine. UI;

public class Fade_Out : MonoBehaviour
{
    public Image fade_img;

    private void Start ( )
    {
        fade_img. canvasRenderer. SetAlpha ( 1 );
        fade_out ( );
    }

    public void fade_out ( )
    {
        fade_img. CrossFadeAlpha ( 0, 0.5f, false );
    }

    public void Quit ( )
    {
        Application. Quit ( );
    }

    public void Previous ( )
    {
        SceneManager. LoadScene ( "Start" );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine. SceneManagement;
using UnityEngine. UI;

public class Fade_In : MonoBehaviour
{
    public Image fade_img;

    private void Start ( )
    {
        fade_img. canvasRenderer. SetAlpha ( 0 );  
    }

    public void start_btn ( )
    {   
        Invoke ( "fadeIn", 2 );
        fade_img. CrossFadeAlpha ( 1, 0.5f, false );
    }

    void fadeIn ( )
    {
        SceneManager. LoadScene ( "AR" );
    }
}

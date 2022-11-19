using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ContentController : MonoBehaviour
{
    public GameObject indicatotHolder;
    public static Pose detectedPlanePose;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hitsResults = new List<ARRaycastHit>();
    public static List<Vector3> positionList;
    private  bool isPlaneDetected = false;

    public static int Plane_Detech_Count;
    public static int Leave_Count;
    public static float Distace;
    private int Popcorn_Delay;
    private int Count;

    public GameObject Indicator;
    public Material Material_White;
    public Material Material_Red;

    public Camera Main_Camera;
    public GameObject Popcorn;
    public GameObject [] dustdust;

    public Text Current_Mode_Text;

    private bool Zoom=false;
    public static bool Burn=true;

    public GameObject len;

    void Start ( )
    {
        arRaycastManager=FindObjectOfType<ARRaycastManager> ( );
    }

    void Update()
    {
        UpdateRaycastResult();
        UpdateIndicator();
        Zooming ( );
    }

    private void UpdateRaycastResult()
    {
        Vector2 screenPoint = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        hitsResults = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenPoint, hitsResults, TrackableType.Planes);
        isPlaneDetected = hitsResults.Count > 0;
    }

    private void UpdateIndicator()
    {
        if ( isPlaneDetected )
        {
            StartCoroutine ( spawn ( ) );

            detectedPlanePose=hitsResults [ 0 ]. pose;
            indicatotHolder. SetActive ( true );

            Vector3 cameraForwardVector = Camera.main.transform.forward;
            Vector3 cameraBearing = new Vector3(cameraForwardVector.x, 0, cameraForwardVector.z).normalized;
            detectedPlanePose. rotation=Quaternion. LookRotation ( cameraBearing );
            indicatotHolder. transform. SetPositionAndRotation ( detectedPlanePose. position, detectedPlanePose. rotation );

            Distace=detectedPlanePose. position. z;

            if ( Burn )
            {
                if ( Distace>0&&Distace<=1f )
                {
                    Plane_Detech_Count++;
                    indicatotHolder. SetActive ( true );

                    if ( Distace>=0.1f )
                    {
                        indicatotHolder. transform. localScale=new Vector3 ( 0.1f, 0.1f, 0.1f );
                        Indicator. GetComponent<MeshRenderer> ( ). material=Material_White;
                    }
                    if ( Distace>=0.2f )
                    {
                        indicatotHolder. transform. localScale=new Vector3 ( 0.09f, 0.09f, 0.09f );
                        Indicator. GetComponent<MeshRenderer> ( ). material=Material_White;
                    }
                    if ( Distace>=0.2f&&Distace<=0.3f )
                    {
                        indicatotHolder. transform. localScale=new Vector3 ( 0.08f, 0.08f, 0.08f );
                        Indicator. GetComponent<MeshRenderer> ( ). material=Material_White;
                    }
                    if ( Distace>=0.3f&&Distace<=5 )
                    {
                        indicatotHolder. transform. localScale=new Vector3 ( 0.05f, 0.05f, 0.05f );
                        Indicator. GetComponent<MeshRenderer> ( ). material=Material_Red;
                        Current_Mode_Text. text="Burn";
                    }
                }
                else
                {
                    if ( Distace>=-0f&&Distace<=-0.1f )
                    {
                        indicatotHolder. transform. localScale=new Vector3 ( 0.1f, 0.1f, 0.1f );
                        Indicator. GetComponent<MeshRenderer> ( ). material=Material_White;
                    }
                    if ( Distace<=-0.2f )
                    {
                        indicatotHolder. transform. localScale=new Vector3 ( 0.09f, 0.09f, 0.09f );
                        Indicator. GetComponent<MeshRenderer> ( ). material=Material_White;
                    }
                    if ( Distace<=-0.2f&&Distace>=-0.3f )
                    {
                        indicatotHolder. transform. localScale=new Vector3 ( 0.08f, 0.08f, 0.08f );
                        Indicator. GetComponent<MeshRenderer> ( ). material=Material_White;
                    }
                    if ( Distace<=-0.3f&&Distace>=-5 )
                    {
                        indicatotHolder. transform. localScale=new Vector3 ( 0.05f, 0.05f, 0.05f );
                        Indicator. GetComponent<MeshRenderer> ( ). material=Material_Red;
                    }
                }
            }
        }
    }

    IEnumerator spawn ( )
    {
        yield return new WaitForSeconds ( 6 );

        Popcorn_Delay++;

        if ( Popcorn_Delay==1 )
        {
            Instantiate (Popcorn,detectedPlanePose. position, detectedPlanePose. rotation );

            yield return new WaitForSeconds (10);
            Popcorn_Delay=0;
        }
    }

    public void Zoom_Burn ( )
    {
        Count++;

        if ( Count==1 )
        {
            Zoom=true;
            Current_Mode_Text.text="Zoom";
            Burn=false;

            //len. SetActive ( true );
        }
        else if ( Count==2 )
        {
            Zoom=false;
            Burn=true;
            Current_Mode_Text. text="Diffract";
            Main_Camera. fieldOfView=60f;
            Count=0;


           // len. SetActive ( false );
        }
    }

    void Zooming ( )
    {
        if ( Zoom )
        {
            if ( isPlaneDetected )
            {
                detectedPlanePose=hitsResults [ 0 ]. pose;
                indicatotHolder. SetActive ( false );

                Vector3 cameraForwardVector = Camera.main.transform.forward;
                Vector3 cameraBearing = new Vector3(cameraForwardVector.x, 0, cameraForwardVector.z).normalized;
                detectedPlanePose. rotation=Quaternion. LookRotation ( cameraBearing );
                indicatotHolder. transform. SetPositionAndRotation ( detectedPlanePose. position, detectedPlanePose. rotation );

                Distace=detectedPlanePose. position. z;

                if ( Distace>0.05f&&Distace<=1f )
                {
                    Main_Camera. fieldOfView=Distace*300;


                    if ( Main_Camera. fieldOfView>=60 )
                    {
                        Main_Camera. fieldOfView=60;
                    }
                }

              
            }
        }
    }



}

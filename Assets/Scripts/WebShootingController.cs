using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebShootingController : MonoBehaviour
{
    public GameObject Burn_Holder;
    public GameObject Burn;
    public GameObject Burn_Spawner;
    public GameObject targetLocation;
    private float delaySecond = 0.3f;

    public static int Burn_Count=-1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&ContentController. Distace>=0.3f&&ContentController. Distace<=5f )
        {
            ShootWebBurn ( );
            Burn_Count+=1;

            ContentController. Leave_Count=0;
        }
    }

    private void ShootWebBurn()
    {
        GameObject go = Instantiate(Burn_Holder, Burn_Spawner.transform.position, Quaternion.identity);  
        go.GetComponent<WebBurnController>().targetLocation = targetLocation.transform.position;
        go.GetComponent<WebBurnController>().isSetup = true;

        StartCoroutine ( SpawnWeb ( ) );
    }

    private IEnumerator SpawnWeb()
    {
        GameObject go = Instantiate(Burn, targetLocation.transform.position, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));

        go.SetActive(false);
        yield return new WaitForSeconds(delaySecond);
        go.SetActive(true);

        yield return null;
    }
}

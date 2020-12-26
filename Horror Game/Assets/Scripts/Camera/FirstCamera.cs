using System.Collections;
using UnityEngine;

public class FirstCamera : MonoBehaviour
{

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public bool cameraIsOn = false;
    public int cameraNumber;

    void Start()
    {
        cameraNumber = 1;
        StartCoroutine(SwitchCamera());
    }

    IEnumerator SwitchCamera ()
    {
        yield return new WaitForSeconds(5);
        cameraTwo.SetActive(true);
        cameraOne.SetActive(false);
        cameraIsOn = true;
        cameraNumber = 2;
    }
}

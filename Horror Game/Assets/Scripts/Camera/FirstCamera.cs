using UnityEngine;

public class FirstCamera : MonoBehaviour
{

    public GameObject cameraForward;
    public GameObject cameraBack;
    public bool cameraIsOn = false;
    public int cameraNumber;

    void Start()
    {
        cameraNumber = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            cameraForward.SetActive(true);
            cameraBack.SetActive(false);
        }
    }
}

using UnityEngine;

public class TankControls : MonoBehaviour
{

    public GameObject player;
    public bool isMoving;

    public float horizontalMovement;
    public float verticalMovement;

    public float rotationSpeed = 150f;
    public float movementSpeed = 4f;
        
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;
            if (Input.GetButton("SKey"))
            {
                player.GetComponent<Animator>().Play("WalkBackwards");
            }
            else
            {
            player.GetComponent<Animator>().Play("Walk");
            }
            horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
            verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
            player.transform.Rotate(0f, horizontalMovement, 0f);
            player.transform.Translate(0, 0, verticalMovement);
        }
        else
        {
            isMoving = false;
            player.GetComponent<Animator>().Play("Idle");
        }
    }
}

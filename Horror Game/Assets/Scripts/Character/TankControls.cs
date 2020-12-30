using UnityEngine;

public class TankControls : MonoBehaviour
{

    public GameObject player;
    public bool isMoving;
    public bool isRunning;
    public bool backwardsMovementCheck = false;

    public float horizontalMovement;
    public float verticalMovement;

    public float rotationSpeed = 150f;
    public float walkingSpeed = 4f;
    public float runningSpeed = 15.1f;
        
    void Update()
    {
        CheckIfRunning();
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;
            if (Input.GetButton("SKey"))
            {
                backwardsMovementCheck = true;
                player.GetComponent<Animator>().Play("WalkBackwards");
            }
            else
            {
                backwardsMovementCheck = false;
                if (isRunning == false)
                {
                    player.GetComponent<Animator>().Play("Walk");
                }
                else
                {
                    player.GetComponent<Animator>().Play("Run");
                }
            }
            if (isRunning == false || backwardsMovementCheck == true)
            {
                verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * walkingSpeed;
            }
            if (isRunning == true && backwardsMovementCheck == false)
            {
                verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * runningSpeed;
            }
            horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
            player.transform.Rotate(0f, horizontalMovement, 0f);
            player.transform.Translate(0, 0, verticalMovement);
        }
        else
        {
            isMoving = false;
            player.GetComponent<Animator>().Play("Idle");
        }
    }
    void CheckIfRunning ()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }
}


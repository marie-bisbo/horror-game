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
                WalkBackwards();
            }
            else
            {
                backwardsMovementCheck = false;
                if (isRunning == false)
                {
                    Walk();
                }
                else
                {
                    Run();
                }
            }
            MovePlayer();
        }
        else
        {
            StandStill();
        }
    }
    void CheckIfRunning ()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }
    void Walk()
    {
        player.GetComponent<Animator>().Play("Walk");
        verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * walkingSpeed;
    }
    void Run()
    {
        player.GetComponent<Animator>().Play("Run");
        verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * runningSpeed;
    }
    void WalkBackwards()
    {
        isRunning = false;
        backwardsMovementCheck = true;
        player.GetComponent<Animator>().Play("WalkBackwards");
        verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * walkingSpeed;
    }
    void MovePlayer()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        player.transform.Rotate(0f, horizontalMovement, 0f);
        player.transform.Translate(0, 0, verticalMovement);
    }
    void StandStill()
    {
        isMoving = false;
        player.GetComponent<Animator>().Play("Idle");
    }
}


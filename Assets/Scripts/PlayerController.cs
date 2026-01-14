using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject berm;
    public GameObject centreDivider;

    public float speed = 20f;
    public float speedInit = 20f;
    public float speedMax = 100f;
    public float speedMin = 0f;
    public float acceleration = 10f;

    public float speedDrag = 2f;
    public float brakingForce = 5f;

    private float speedActual = 0f;

    public float turnSpeed = 45f;
    private float horizontalInput;
    private float verticalInput;
    private float initialThrottlePosition = 0.5f;

    private bool inputReceived = false;
    private bool accelerating = false;
    private bool coasting = false;
    private bool braking = false;

    // Start is called before the first frame update
    void Start()
    {
        speedActual = speedInit;

        InvokeRepeating(nameof(HandleMomentum), 0f, 1);
    }

    private void HandleMomentum()
    {
        if (!inputReceived)
        {
            Debug.Log($"Initialised ${speedActual}");
        }
        else if (coasting)
        {
            Debug.Log($"Coasting ${speedActual}");
            if ((speedActual - speedDrag) > speedInit)
            {
                speedActual -= speedDrag;
            }
        }
        else if (accelerating)
        {
            Debug.Log($"Accelerating ${speedActual}");
            if ((speedActual + acceleration) < speedMax)
            {
                speedActual += acceleration;
            }
        }
        else if (braking)
        {
            Debug.Log($"Braking ${speedActual}");
            if ((speedActual - brakingForce) > speedMin)
            {
                speedActual -= brakingForce;
            }
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Approximately(0, verticalInput))
        {
            if (inputReceived)
            {
                coasting = true;
                braking = false;
                accelerating = false;
            }
        }
        else
        {
            inputReceived = true;
            coasting = false;

            if (verticalInput <= 0)
            {
                accelerating = false;
                braking = true;
            }
            else
            {
                braking = false;
                accelerating = true;
            }
        }

        // transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.forward);
        if (!inputReceived)
        {
            transform.Translate(speedInit * Time.deltaTime * initialThrottlePosition * Vector3.forward);
        }
        else
        {
            transform.Translate(speedActual * Time.deltaTime * Vector3.forward);
        }

        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(transform.position.x, 360f, transform.position.z);
        }
    }
}

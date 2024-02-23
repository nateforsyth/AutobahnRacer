using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject berm;
    public GameObject centreDivider;

    public float speed = 20f;
    public float turnSpeed = 45f;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.forward);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(transform.position.x, 360f, transform.position.z);
        }
    }
}

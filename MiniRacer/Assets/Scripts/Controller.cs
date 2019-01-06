using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float hoverForce;
    public float hoverHeight;
    float powerInput;
    float turnInput;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, hoverHeight)){
            var propotionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            var appliedHoverForce = Vector3.up * propotionalHeight * hoverForce;
            rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }
        rb.AddRelativeForce(0, 0, powerInput * speed);
        rb.AddRelativeTorque(0, turnInput * turnSpeed, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdIA : MonoBehaviour
{
    public float sensorLength = 1.20f;
    private float ratioScale = .001f;

    public float speed = 1f;
    private float directionValue = 1.0f;

    private float turnValue = 0.0f;
    public float turnSpeed = 1.0f;

    private float heightValue = 0.0f;
    public float heightSpeed = 1.0f;

    private Collider myCollider;

    private Rigidbody rb;

    public float angularSpeed;
    private float floatDirection;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = transform.GetComponent<BoxCollider>();
        rb = transform.GetComponent<Rigidbody>();
        floatDirection = Mathf.Pow(-1, Random.Range(1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        FloatingSim();
        CrowdSim();
        //transform.position += (transform.forward * speed * directionValue + transform.up * heightSpeed * heightValue + transform.right * turnSpeed * turnValue) * Time.deltaTime;
        
    }

    private void FloatingSim()
    {
        angularSpeed = rb.angularVelocity.magnitude;
        rb.maxAngularVelocity = 1;
        rb.AddTorque(Vector3.forward * floatDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * (sensorLength + transform.localScale.z * ratioScale));
        Gizmos.DrawRay(transform.position, -transform.forward * (sensorLength + transform.localScale.z * ratioScale));

        Gizmos.DrawRay(transform.position, transform.right * (sensorLength + transform.localScale.x * ratioScale));
        Gizmos.DrawRay(transform.position, -transform.right * (sensorLength + transform.localScale.x * ratioScale));

        Gizmos.DrawRay(transform.position, transform.up * (sensorLength + transform.localScale.y * ratioScale));
        Gizmos.DrawRay(transform.position, -transform.up * (sensorLength + transform.localScale.y * ratioScale));

    }

    private void CrowdSim()
    {
        RaycastHit hit;
        int flag = 0;

        //Front sensor
        if (Physics.Raycast(transform.position, transform.forward, out hit, sensorLength + transform.localScale.z * ratioScale))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }

            if (directionValue == 1)
                directionValue = -1;
            flag++;
        }
        //Back sensor
        if (Physics.Raycast(transform.position, -transform.forward, out hit, sensorLength + transform.localScale.z * ratioScale))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            if (directionValue == -1)
                directionValue = 1;
            flag++;
        }
        //Right sensor
        if (Physics.Raycast(transform.position, transform.right, out hit, sensorLength + transform.localScale.x * ratioScale))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            turnValue += 1;
            flag++;
        }
        //Left sensor
        if (Physics.Raycast(transform.position, -transform.right, out hit, sensorLength + transform.localScale.x * ratioScale))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            turnValue -= 1;
            flag++;
        }
        //Top sensor
        if (Physics.Raycast(transform.position, transform.up, out hit, sensorLength + transform.localScale.y * ratioScale))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            heightValue += 1;
            flag++;
        }
        //Bottom sensor
        if (Physics.Raycast(transform.position, -transform.up, out hit, sensorLength + transform.localScale.y * ratioScale))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            heightValue -= 1;
            flag++;
        }

        if (flag == 0)
        {
            turnValue = 0;
            heightValue = 0;
        }

        transform.Rotate(((Vector3.up * turnSpeed * turnValue) + (Vector3.right * heightSpeed * heightValue)) * Time.deltaTime);

        transform.position += transform.forward * Time.deltaTime * speed * directionValue;
    }
}

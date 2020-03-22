using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static Color oneColor = Color.green;
    public GameObject ball;

    private float speed = 100;
    public static float rotationSpeed = 75f;

    void Start()
    {
        MakeNewCircle();
    }


    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {
            HitBall();
        }
    }

    public void HitBall()
    {
        GameObject gameObject = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity);
        gameObject.GetComponent<MeshRenderer>().material.color = oneColor;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void MakeNewCircle()
    {
        GameObject gameObject = Instantiate(Resources.Load("round" + Random.Range(1, 4))) as GameObject;
        gameObject.transform.position = new Vector3(0, 20, 23);
        gameObject.name = "Circle";
    }
}

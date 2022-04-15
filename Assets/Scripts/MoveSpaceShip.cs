using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveSpaceShip : MonoBehaviour
{
    public float maxSpeed = 2f;
    public float maxRotation = .5f;
    public float speedForce = .01f;
    public float rotationForce = .01f;
    public float speed = 0f;
    public float rotation = 0f;

    public TextMeshProUGUI speedTextUI;
    public TextMeshProUGUI rotationTextUI;
    public TextMeshProUGUI xTextUI;
    public TextMeshProUGUI yTextUI;

    Vector3 screenDimensions;

    void Start()
    {
        screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            speed += speedForce;
            if (speed >= maxSpeed) { speed = maxSpeed; }
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            speed -= speedForce;
            if (speed < 0f) { speed = 0.01f; }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rotation += rotationForce;
            if (rotation >= maxRotation) { rotation = maxRotation; }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rotation += rotationForce * -1;
            if (rotation < (maxRotation * -1)) { rotation = maxRotation * -1; }
        }

        transform.position += speed * Time.deltaTime * transform.up;
        transform.eulerAngles += new Vector3(0, 0, rotation);

        speedTextUI.text = "S: " + speed.ToString("##0.0");
        rotationTextUI.text = "RS: " + rotation.ToString("##0.0");
        xTextUI.text = "X: " + transform.position.x.ToString("##0.000");
        yTextUI.text = "Y: " + transform.position.y.ToString("##0.000");

    }
}

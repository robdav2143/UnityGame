using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class EasyMove : MonoBehaviour {

    public float gravity = 20;
    public float Speed = 8;
    public float acceleration = 12;

    public float currentSpeed;
    public float targetSpeed;
    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;

    // Use this for initialization
    void Start () {
        playerPhysics = GetComponent<PlayerPhysics>();
    }
	
	// Update is called once per frame
	void Update () {

        targetSpeed = Input.GetAxisRaw("Horizontal") * Speed;
        currentSpeed = incrementTowards(currentSpeed, targetSpeed, acceleration);

        amountToMove.x = currentSpeed;
        amountToMove.y -= gravity * Time.deltaTime;
        playerPhysics.Move(amountToMove * Time.deltaTime);
    }

    private float incrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }

        else {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }
}

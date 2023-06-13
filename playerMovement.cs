using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public int walkingSpeed = 5;
    int runningSpeed, counter = 9999;
    bool moving = false, action = false;
    public Animator animator;
    public Text stepCounter;

    void Update()
    {
        // भागने के लिए
        if (Input.GetAxis("Jump") != 0)
            runningSpeed = walkingSpeed * 2;
        else
            runningSpeed = walkingSpeed;

        // चलने के लिए है
        float leftRight = Input.GetAxis("Horizontal"),
            upDown = Input.GetAxis("Vertical");
        Vector2 movePlayer = new Vector2(leftRight, upDown);
        GetComponent<Rigidbody2D>().velocity = movePlayer * runningSpeed;

        // मुड़ने के लिए
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            Vector3 ltemp = transform.localScale;
            ltemp.x = 0.1f;
            transform.localScale = ltemp;
        }
        else if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            Vector3 ltemp = transform.localScale;
            ltemp.x = -0.1f;
            transform.localScale = ltemp;
        }

        // चलने वाला एनिमेशन
        if (Input.GetAxis ("Horizontal") == 0
            && Input.GetAxis ("Vertical") == 0)
            moving = false;
        else
        {
            moving = true;
            counter--;                  // कितने कदम चल चुका है
            if (Input.GetAxis ("Jump") != 0)
                counter -= 2;
        }
        animator.SetBool("moving", moving);
        stepCounter.text = counter.ToString();

        // गला खींचना
        if (Input.GetButtonDown ("Jump"))
            action = true;
        else if (!Input.GetButtonDown ("Jump"))
            action = false;
        animator.SetBool("action", action);
    }
}
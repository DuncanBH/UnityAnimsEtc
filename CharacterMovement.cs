using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private float speedModif;

    private float input_x;
    private float input_y;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");

        bool walking = Mathf.Abs(input_x) + Mathf.Abs(input_y) > 0;
        animator.SetBool("Moving", walking);

        if (walking)
        {
            animator.SetFloat("Input_Horizontal", input_x);
            animator.SetFloat("Input_Vertical", input_y);

            transform.Translate(new Vector2(input_x, input_y) * speedModif * Time.deltaTime);
        }

        print("x: " + input_x + " y: " + input_y);
    }
}

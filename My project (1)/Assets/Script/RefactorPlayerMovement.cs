using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefactorPlayerMovement : MonoBehaviour
{
    //no anim walk, run, jump, combo, yet
    public float moveSpeed = 5f;
    public Animator anim;
    public CharacterController playerCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerCollider.height = 1f;
        playerCollider.center = new Vector3(0f, 0.5f, 0f);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.Translate(movement * Time.deltaTime * moveSpeed);
    }
}

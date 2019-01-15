using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int moveSpeed = 5;
    private Animator anim;
    private bool isjumping;
    private bool isCrouching;
    private float rotspeed = 5.0f;
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        isjumping = false;
        isCrouching = false;
    }
	
	// Update is called once per frame
	void Update () {
        float MouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotspeed * MouseX);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isRun", true);
            MovePlayer();

            if (Input.GetKeyDown(KeyCode.Space) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                MovePlayer();
                Jump();
            }
        }
        
        else if(Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching == false)
            {
                anim.SetBool("isCrouching", true);
                isCrouching = true;
            }

            else if(isCrouching == true)
            {
                anim.SetBool("isCrouching", false);
                isCrouching = false;
            }
        }

        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }        

        else
        {
            anim.SetBool("isRun", false);
        }
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            Debug.Log("A");
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(-Vector3.left * moveSpeed * Time.deltaTime);
            Debug.Log("D");
        }

        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            Debug.Log("W");
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            Debug.Log("S");
        }
    }
    
    private void Jump()
    {
        if (isjumping == false)
        {
            anim.SetBool("isJump", true);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            isjumping = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isjumping = false;
            Debug.Log("트리거");
        }
    }

    
}

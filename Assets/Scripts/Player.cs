using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody rigid;
    AudioSource audio;

    public float jumpPower;
    public float moveSpeed;
    public int itemCount;

    public GameManager Manager;

    bool isJump;
    private void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        isJump = false;

    }

    private void Update()
    {
        
        if(Input.GetButtonDown("Jump") && !isJump)
        {

            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);

        }

    }

    void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (!isJump) { 

            rigid.AddForce(new Vector3(h, 0, v) * moveSpeed, ForceMode.Impulse); 

        } else
        {

            rigid.AddForce(new Vector3(h, 0, v) * 0.25f * moveSpeed, ForceMode.Impulse);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor") 
        {

            isJump = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Item")
        {

            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            Manager.GetItem(itemCount);

        } else if (other.tag == "Goal")
        {

            if (itemCount == Manager.TotalItemCount)
            {

                if (Manager.Stage == 2)
                {

                    SceneManager.LoadScene(0);

                } else {

                    SceneManager.LoadScene(Manager.Stage + 1);

                }
                   

            } else
            {

                SceneManager.LoadScene(Manager.Stage);

            }

        } else if (other.tag == "Fall")
        {

            SceneManager.LoadScene(Manager.Stage);

        }
    }
}

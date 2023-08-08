using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowController : MonoBehaviour
{
    public Animator Window;
    public Animator Window2;
    public GameObject InstructionWindow1;
    public GameObject InstructionWindow2;

    public bool openAction = false;
    public bool closeAction = false;
    public bool windowStatus = false;

    void Start()
    {
        InstructionWindow1.SetActive(false);
        InstructionWindow2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!closeAction && !windowStatus)
            {
                InstructionWindow1.SetActive(true);
                openAction = true;
            }

            else if (!openAction && windowStatus)
            {
                InstructionWindow2.SetActive(true);
                closeAction = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InstructionWindow1.SetActive(false);
            openAction = false;

            InstructionWindow2.SetActive(false);
            closeAction = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (openAction)
            {
                InstructionWindow1.SetActive(false);
                Window.Play("windowOpen");
                Window2.Play("window2Open");
                openAction = false;
                windowStatus = true;
                closeAction = true;
                InstructionWindow2.SetActive(true);
            }

            else if (closeAction)
            {
                InstructionWindow2.SetActive(false);
                Window.Play("windowClose");
                Window2.Play("window2Close");
                closeAction = false;
                windowStatus = false;
                openAction = true;
                InstructionWindow1.SetActive(true);
            }
        }
    }
}
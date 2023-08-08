using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public Animator Door;
    public GameObject Instruction01;
    public GameObject Instruction02;

    public bool openAction = false;
    public bool closeAction = false;
    public bool doorStatus = false;

    void Start()
    {
        Instruction01.SetActive(false);
        Instruction02.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!closeAction && !doorStatus)
            {
                Instruction01.SetActive(true);
                openAction = true;
            }

            else if (!openAction && doorStatus)
            {
                Instruction02.SetActive(true);
                closeAction = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instruction01.SetActive(false);
            openAction = false;

            Instruction02.SetActive(false);
            closeAction=false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (openAction)
            {
                Instruction01.SetActive(false);
                Door.Play("doorOpen");
                openAction = false;
                doorStatus = true;
                closeAction = true;
                Instruction02.SetActive(true);
            }

            else if (closeAction)
            {
                Instruction02.SetActive(false);
                Door.Play("doorClose");
                closeAction = false;
                doorStatus = false;
                openAction = true;
                Instruction01.SetActive(true);
            }
        }
    }
}

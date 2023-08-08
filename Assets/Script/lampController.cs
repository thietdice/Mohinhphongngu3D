using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampController : MonoBehaviour
{
    public GameObject Lamp;
    public GameObject lamp2;
    public Animator Switch;
    public GameObject InstructionLamp1;
    public GameObject InstructionLamp2;

    public bool switchOn = false;
    public bool switchOff = false;
    public bool lampStatus = false;

    void Start()
    {
        InstructionLamp1.SetActive(false);
        InstructionLamp2.SetActive(false);
        if (Lamp.activeSelf)
        {
            lampStatus = true;
            Switch.Play("lampOn");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!switchOff && !lampStatus)
            {
                InstructionLamp1.SetActive(true);
                switchOn = true;
            }

            else if (!switchOn && lampStatus)
            {
                InstructionLamp2.SetActive(true);
                switchOff = true;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InstructionLamp1.SetActive(false);
            switchOn = false;

            InstructionLamp2.SetActive(false);
            switchOff = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (switchOn)
            {
                InstructionLamp1.SetActive(false);
                Switch.Play("lampOn");
                Lamp.SetActive(true);
                lamp2.SetActive(false);
                switchOn = false;
                lampStatus = true;
                switchOff = true;
                InstructionLamp2.SetActive(true);
            }

            else if (switchOff == true)
            {
                InstructionLamp2.SetActive(false);
                Switch.Play("lampOff");
                Lamp.SetActive(false);
                lamp2.SetActive(true);
                switchOff = false;
                lampStatus = false;
                switchOn = true;
                InstructionLamp1.SetActive(true);
            }
        }
    }
}
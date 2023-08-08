using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    public GameObject mainLight;
    public GameObject Light2;
    public Animator Switch1;
    public Animator Switch2;
    public GameObject InstructionLight1;
    public GameObject InstructionLight2;

    public bool lightStatus = false;
    public bool switchOn = false;
    public bool switchOff = false;

    void Start()
    {
        InstructionLight1.SetActive(false);
        InstructionLight2.SetActive(false);

        if (mainLight.activeSelf)
        {
            lightStatus = true;
            Switch1.Play("switchOn");
            Switch2.Play("switchOn2");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (mainLight.activeSelf)
            {
                lightStatus = true;
            }
            
            else
            {
                lightStatus = false;
            }

            if (!switchOff && !lightStatus)
            {
                InstructionLight1.SetActive(true);
                switchOn = true;
            }
            else if (!switchOn && lightStatus)
            {
                InstructionLight2.SetActive(true);
                switchOff = true;
            }

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InstructionLight1.SetActive(false);
            switchOn = false;

            InstructionLight2.SetActive(false);
            switchOff = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (switchOn)
            {
                InstructionLight1.SetActive(false);
                Switch1.Play("switchOn");
                Switch2.Play("switchOn2");
                mainLight.SetActive(true);
                Light2.SetActive(false);
                switchOn = false;
                lightStatus = true;
                switchOff = true;
                InstructionLight2.SetActive(true);
            }


            else if (switchOff)
            {
                InstructionLight2.SetActive(false);
                Switch1.Play("switchOff");
                Switch2.Play("switchOff2");
                mainLight.SetActive(false);
                Light2.SetActive(true);
                switchOff = false;
                lightStatus = false;
                switchOn = true;
                InstructionLight1.SetActive(true);
            }
        }
    }
}

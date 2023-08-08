using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acController : MonoBehaviour
{
    public Animator Switch;
    public Animator Ac;
    public GameObject InstructionAC1;
    public GameObject InstructionAC2;

    public bool turnOn = false;
    public bool turnOff = false;
    public bool acStatus = false;

    void Start()
    {
        InstructionAC1.SetActive(false);
        InstructionAC2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!turnOff && !acStatus)
            {
                InstructionAC1.SetActive(true);
                turnOn = true;
            }

            else if (!turnOn && acStatus)
            {
                InstructionAC2.SetActive(true);
                turnOff = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InstructionAC1.SetActive(false);
            turnOn = false;

            InstructionAC2.SetActive(false);
            turnOff = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (turnOn == true)
            {
                InstructionAC1.SetActive(false);
                Switch.Play("aptomatOn");
                Ac.Play("acOn");
                turnOn = false;
                acStatus = true;
                turnOff = true;
                InstructionAC2.SetActive(true);
            }

            else
            {
                InstructionAC2.SetActive(false);
                Switch.Play("aptomatOff");
                Ac.Play("acOff");
                turnOff = false;
                acStatus = false;
                turnOn = true;
                InstructionAC1.SetActive(true);
            }
        }
    }
}
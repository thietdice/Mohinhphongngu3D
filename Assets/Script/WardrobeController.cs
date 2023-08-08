using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeController : MonoBehaviour
{
    public Animator Wardrobe1;
    public Animator Wardrobe2;
    public Animator Wardrobe3;

    public GameObject InstructionWardrobe1;
    public GameObject InstructionWardrobe2;

    public bool openAction = false;
    public bool closeAction = false;

    public bool wardrobeStatus = false;

    void Start()
    {
        InstructionWardrobe1.SetActive(false);
        InstructionWardrobe2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!closeAction && !wardrobeStatus)
            {
                InstructionWardrobe1.SetActive(true);
                openAction = true;
            }

            else if (!openAction && wardrobeStatus)
            {
                InstructionWardrobe2.SetActive(true);
                closeAction = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InstructionWardrobe1.SetActive(false);
            openAction = false;

            InstructionWardrobe2.SetActive(false);
            closeAction = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (openAction)
            {
                InstructionWardrobe1.SetActive(false);
                Wardrobe1.Play("tu1Open");
                Wardrobe2.Play("tu2Open");
                Wardrobe3.Play("tu3Open");

                openAction = false;
                wardrobeStatus = true;
                closeAction = true;
                InstructionWardrobe2.SetActive(true);
            }

            else if (closeAction)
            {
                InstructionWardrobe2.SetActive(false);
                Wardrobe1.Play("tu1Close");
                Wardrobe2.Play("tu2Close");
                Wardrobe3.Play("tu3Close");

                closeAction = false;
                wardrobeStatus = false;
                openAction = true;
                InstructionWardrobe1.SetActive(true);
            }
        }
    }
}

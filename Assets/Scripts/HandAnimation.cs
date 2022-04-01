using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimation : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public InputDevice targetDevice;
    public bool deviceFound = false;
    Animator handAnimator;


    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponent< Animator >();
    }

    // Update is called once per frame
    void Update()
    {
        if (!deviceFound)
        {
            FindDevice();
        }
        else
        {
            return;
        }
        //Controle l'animation en fonction de k'etat du bouton
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripvalue))
        {
            handAnimator.SetFloat("Grip", gripvalue);
        }

    }
    void FindDevice()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            deviceFound = true;
        }
    }
}


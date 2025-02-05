using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LauncherTest : MonoBehaviour
{
    public Transform trigger;
    private Transform startTriggerPos;
    public float triggerRange = 15f;
    private ActionBasedController ABC;
    public GameObject bulletPrefab;
    public Transform shotPos;

    private void Awake()
    {
        ABC = GetComponentInParent<ActionBasedController>();
        startTriggerPos = trigger;
    }

    private void OnEnable()
    {
        ABC.activateAction.reference.action.performed += TriggerAction;
        ABC.activateAction.reference.action.canceled += TriggerAction;
    }

    private void OnDisable()
    {
        ABC.activateAction.reference.action.performed -= TriggerAction;
        ABC.activateAction.reference.action.canceled -= TriggerAction;
    }

    private void TriggerAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 euler = trigger.localEulerAngles;
            euler.z = triggerRange;
            trigger.localEulerAngles = euler;
            Fire();
        }
        else
        {
            trigger.localEulerAngles = startTriggerPos.localEulerAngles;
        }

    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = shotPos.transform.position;
        bullet.transform.forward = this.transform.parent.forward;
    }

}

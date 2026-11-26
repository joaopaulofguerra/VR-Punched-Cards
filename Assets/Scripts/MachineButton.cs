using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MachineButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] XRSimpleInteractable interactable;
    [SerializeField] Machine machine;

    [Header("Mode")]
    [SerializeField] MachineMode mode;

    [Header("Rotation du levier")]
    [SerializeField] float angleOff = 0f;
    [SerializeField] float angleOn = 30f;

    void Start()
    {
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    void Update()
    {
        if (machine.currentMode == mode)
        {
            transform.localEulerAngles = new Vector3(angleOn, 0, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(angleOff, 0, 0);
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        machine.SetMode(mode);
    }
}
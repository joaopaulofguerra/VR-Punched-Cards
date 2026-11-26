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

    void Start()
    {
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        machine.SetMode(mode);
    }
}
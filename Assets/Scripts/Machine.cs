using UnityEngine;

public class Machine : MonoBehaviour
{
    [Header("LEDs")]
    [SerializeField] Renderer ledRunRenderer;
    [SerializeField] Renderer ledPauseRenderer;
    [SerializeField] Renderer ledTurboRenderer;

    [Header("Materiaux")]
    [SerializeField] Material ledOffMaterial;
    [SerializeField] Material ledRunOnMaterial;
    [SerializeField] Material ledPauseOnMaterial;
    [SerializeField] Material ledTurboOnMaterial;

    public MachineMode currentMode { get; private set; } = MachineMode.Pause;

    void Start()
    {
        UpdateLeds();
    }

    public void SetMode(MachineMode mode)
    {
        currentMode = mode;
        UpdateLeds();
    }

    void UpdateLeds()
    {
        if (currentMode == MachineMode.Run)
        {
            SetLed(ledRunRenderer, ledRunOnMaterial);
        }
        else
        {
            SetLed(ledRunRenderer, ledOffMaterial);
        }

        if (currentMode == MachineMode.Pause)
        {
            SetLed(ledPauseRenderer, ledPauseOnMaterial);
        }
        else
        {
            SetLed(ledPauseRenderer, ledOffMaterial);
        }

        if (currentMode == MachineMode.Turbo)
        {
            SetLed(ledTurboRenderer, ledTurboOnMaterial);
        }
        else
        {
            SetLed(ledTurboRenderer, ledOffMaterial);
        }
    }

    void SetLed(Renderer renderer, Material material)
    {
        Material[] materials = renderer.materials;
        materials[1] = material;
        renderer.materials = materials;
    }
}
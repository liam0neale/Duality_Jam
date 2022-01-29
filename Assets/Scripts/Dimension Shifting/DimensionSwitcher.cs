using System;
using UnityEngine;

public class DimensionSwitcher : MonoBehaviour
{
    public static event Action<bool> OnDimensionSwitched;
    public static bool InCreepyDimension { get; private set; } = false;

    [SerializeField] private Shader m_shader;

    private Material m_material;

    private void Start()
    {
        m_material = new Material(m_shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (InCreepyDimension)
        {
            Graphics.Blit(source, destination, m_material);    
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public static void SwitchDimension(bool inCreepyDimension)
    {
        InCreepyDimension = inCreepyDimension;
        Manager.self.SwitchDimension(inCreepyDimension);
        OnDimensionSwitched?.Invoke(InCreepyDimension);
    }

    [ContextMenu("Switch Dimension")]
    private void SwitchDimensionContextMenu()
    {
        SwitchDimension(!InCreepyDimension);
    }
}
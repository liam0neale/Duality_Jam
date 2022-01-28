using System;
using UnityEngine;

public class DimensionSwitcher : MonoBehaviour
{
    public static event Action<bool> OnDimensionSwitched;

    [SerializeField] private Shader m_shader;

    private Material m_material;

    private static bool m_inCreepyDimension = false;

    private void Start()
    {
        m_material = new Material(m_shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (m_inCreepyDimension)
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
        m_inCreepyDimension = inCreepyDimension;
        OnDimensionSwitched?.Invoke(m_inCreepyDimension);
    }

    [ContextMenu("Switch Dimension")]
    private void SwitchDimensionContextMenu()
    {
        SwitchDimension(!m_inCreepyDimension);
    }
}
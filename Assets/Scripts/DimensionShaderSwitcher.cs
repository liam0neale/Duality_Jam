using UnityEngine;

public class DimensionShaderSwitcher : MonoBehaviour
{
    [SerializeField] private Shader m_shader;

    private Material m_material;

    private void Start()
    {
        m_material = new Material(m_shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_material);
    }
}

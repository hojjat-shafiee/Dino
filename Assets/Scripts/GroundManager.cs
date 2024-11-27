using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GroundManager : MonoBehaviour
{
    private MeshRenderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        float speed = GameManager.Instance.GameSpeed / transform.localScale.x;
        m_Renderer.material.mainTextureOffset += speed * Time.deltaTime * Vector2.right;


    }
}

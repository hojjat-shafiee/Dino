using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] Sprites;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private GameManager gameManager;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }
    void Animate()
    {
        frame++;
        if (frame >= Sprites.Length)
        {
            frame = 0;
        }
        if (frame >= 0 && frame < Sprites.Length)
            spriteRenderer.sprite = Sprites[frame];

        Invoke(nameof(Animate), 1f / GameManager.Instance.GameSpeed);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Animate));
    }
}

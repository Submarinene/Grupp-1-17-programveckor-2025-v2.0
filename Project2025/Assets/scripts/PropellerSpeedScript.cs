using UnityEngine;

public class PropellerSpeedScript : MonoBehaviour
{
    public Sprite[] frames; // Drag and drop frames here.
    [Range(0f, 1f)]
    public float animationSpeed; // Scale from 0 (0 FPS) to 1 (10 FPS).

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;
    private float frameRate; // The calculated time between frames based on animationSpeed.

    public GameObject mainBody;
    MainBodyMovement mainBodyMovement;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateFrameRate();

        mainBodyMovement = mainBody.GetComponent<MainBodyMovement>();
    }

    private void Update()
    {
        animationSpeed = mainBodyMovement.gravityScale;

        // Update frameRate dynamically if animationSpeed changes.
        UpdateFrameRate();

        // Stop animation if frameRate is too high (i.e., animationSpeed = 0).
        if (frameRate <= 0) return;

        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
            spriteRenderer.sprite = frames[currentFrame];
        }
    }

    // Dynamically calculate frameRate based on animationSpeed
    private void UpdateFrameRate()
    {
        // Map animationSpeed (0 to 1) to frameRate (in seconds between frames)
        frameRate = animationSpeed > 0 ? 1f / (animationSpeed * 20f) : 0f;
    }

    // Public method to update animationSpeed from other scripts
    public void SetAnimationSpeed(float speed)
    {
        animationSpeed = Mathf.Clamp01(speed); // Clamp speed between 0 and 1.
    }
}

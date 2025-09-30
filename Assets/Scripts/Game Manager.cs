using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    [SerializeField]
    private MeshRenderer groundRenderer;

    public float speed = 0.2f;
    public float upSpeed = 0.1f;
    private float currSpeed;
    public bool gameStarted = false;
    

    private void Awake()
    {
        Instance= this;
        currSpeed = speed;
    }

    private void Update()
    {
        if(gameStarted)
        {
            currSpeed += upSpeed * Time.deltaTime; // increase speed over time
            groundRenderer.material.mainTextureOffset += new Vector2(currSpeed * Time.deltaTime, 0);  // d = s * t
        }
    }
}

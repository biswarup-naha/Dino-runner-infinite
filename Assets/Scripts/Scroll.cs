using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float xVel = 0.2f;
    public Material mat;
    private Vector2 offset;

    void Start()
    {
        
        mat = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = new Vector2(xVel, 0);
        mat.mainTextureOffset += offset * Time.deltaTime;
    }
}

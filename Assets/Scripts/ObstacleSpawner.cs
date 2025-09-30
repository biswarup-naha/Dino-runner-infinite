using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform parent;

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private float spawnInterval = 2f;

    [SerializeField]
    private float timer= 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameManager.Instance.gameStarted)
            Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnInterval)
        {
            timer+= Time.deltaTime;
        }
        else
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        Instantiate(obstacle, transform.position ,Quaternion.identity , parent);
    }
}

using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int points = 0;
    public TextMeshProUGUI pointsText;

    public GameObject winPanel;

    public GameObject Map;
    public float tiltAmount = 10f;
    public float tiltInterval = 5f;
    private float timer = 0f;

    public GameObject ball;
    public GameObject spawnPoint;

    private Vector3 mapStartPosition;
    private Quaternion mapStartRotation;

    private Rigidbody[] mapRigidbodies;
    private Vector3[] rigidbodyStartPositions;
    private Quaternion[] rigidbodyStartRotations;

    private Transform[] pointObjects;


    void Start()
    {
        mapStartPosition = Map.transform.position;
        mapStartRotation = Map.transform.rotation;

        mapRigidbodies = Map.GetComponentsInChildren<Rigidbody>();

        rigidbodyStartPositions = new Vector3[mapRigidbodies.Length];
        rigidbodyStartRotations = new Quaternion[mapRigidbodies.Length];

        for (int i = 0; i < mapRigidbodies.Length; i++)
        {
            rigidbodyStartPositions[i] = mapRigidbodies[i].transform.position;
            rigidbodyStartRotations[i] = mapRigidbodies[i].transform.rotation;
        }

        pointObjects = Map.GetComponentsInChildren<Transform>(true);

        winPanel.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tiltInterval)
        {
            TiltMap();
            timer = 0f;
        }
    }

    public void RespawnBall()
    {
        ball.transform.position = spawnPoint.transform.position;
        ball.transform.rotation = spawnPoint.transform.rotation;

        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void TiltMap()
    {
        float x = Random.Range(-tiltAmount, tiltAmount);
        float z = Random.Range(-tiltAmount, tiltAmount);

        Map.transform.rotation = Quaternion.Euler(x, 0f, z);
    }

    public void Addpoint()
    {
        points++;
        pointsText.text = "POINTS: " + points;

        if (points >= 3)
        {
            winPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        points = 0;
        pointsText.text = "POINTS: 0";

        winPanel.SetActive(false);

        RespawnBall();

        Map.transform.position = mapStartPosition;
        Map.transform.rotation = mapStartRotation;

        for (int i = 0; i < mapRigidbodies.Length; i++)
        {
            Rigidbody rb = mapRigidbodies[i];

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.transform.position = rigidbodyStartPositions[i];
            rb.transform.rotation = rigidbodyStartRotations[i];

            rb.Sleep();
        }

        for (int i = 0; i < pointObjects.Length; i++)
        {
            if (pointObjects[i].CompareTag("POINT"))
            {
                pointObjects[i].gameObject.SetActive(true);
            }
        }

        Physics.SyncTransforms();

        timer = 0f;
    }
}
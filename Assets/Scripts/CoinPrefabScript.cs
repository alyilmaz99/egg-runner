using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CoinPrefabScript : MonoBehaviour
{

    [SerializeField] private Transform scoreTransform;
    [SerializeField] private GameObject scoreText;
    private Camera mainCamera;
    [SerializeField] private int speed;

    private Vector3 uiPos, result, targetPos;

    void Start()
    {
        mainCamera = Camera.main;

        scoreText = GameObject.FindWithTag("ScoreText");

        scoreTransform = scoreText.transform;

        //Invoke("DestroyObject", 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //MoveToUI();

        uiPos = scoreTransform.position;
        uiPos.z = (transform.position - mainCamera.transform.position).z;
        result = mainCamera.ScreenToWorldPoint(uiPos);
        targetPos = GetScorePosition(transform.position);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);

    }


    public Vector3 GetScorePosition(Vector3 target)
    {
        uiPos = scoreTransform.position;

        uiPos.z = (target - mainCamera.transform.position).z;


        result = mainCamera.ScreenToWorldPoint(uiPos);
        return result;
    }

    void MoveToUI()
    {
        targetPos = GetScorePosition(transform.position);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime* speed);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}

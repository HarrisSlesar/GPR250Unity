using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject targetPrefab;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore()
    {
        score++;
    }

    public void SpawnNewTarget()
    {

        Vector2 pos = new Vector2(Random.Range(-25.0f, 25.0f), Random.Range(-5.0f, 5.0f));

        GameObject target = Instantiate(targetPrefab);
        target.name = "Target";
        target.SetActive(true);
        target.GetComponent<Particle2D>().enabled = true;
        target.GetComponent<TargetSpawn>().enabled = true;
        //target.GetComponent<Particle2D>().physicsData.pos = pos;
        target.transform.position = pos;
    }
}

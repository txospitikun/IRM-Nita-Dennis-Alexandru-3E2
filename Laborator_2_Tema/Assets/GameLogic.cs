using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public GameObject colors;
    public GameObject ball;
    public float total_score = 0f;
    public GameObject score_text;
    public TextMeshProUGUI score;
    private void OnTriggerEnter(Collider other)
    {
        total_score += 50f;
        score.text = $"Total score: {total_score}";
        score_text.SetActive(true);
        StartCoroutine(OnScoreCoroutine());
        colors.SetActive(true);

    }
    private IEnumerator OnScoreCoroutine()
    {
        yield return new WaitForSeconds(2f);
        score_text.SetActive(false);
        colors.SetActive(false);
        ball.transform.position = new Vector3(0.0810000002f, 0.167999998f, 4.30999994f);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityEvent events;

    private Material answer;

    private Color[] playerColors, AnswerColors;

    private string[] colors;

    private void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        colors = player.GetComponent<EggLogic>().colors;


        GameObject answerEgg = GameObject.FindGameObjectWithTag("Finish");

        answer = answerEgg.GetComponent<MeshRenderer>().material;

        events.AddListener(CompareAnswers);

    }

    private void CompareAnswers() {

        StartCoroutine(Compare());

    }


    private IEnumerator Compare() {

        yield return new WaitForSeconds(0.5f);

        Debug.Log("compare");

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        playerColors = player.GetComponent<EggLogic>().currentAnswers();

        int count = 0;

        for (int i = 0; i < playerColors.Length; i++)
        {
            if (playerColors[i] == answer.GetColor(colors[i])) {

                count += 1;

            }
        }

        if (count == 11) {

            player.GetComponent<EggLogic>().Validate();

        }

    }

}

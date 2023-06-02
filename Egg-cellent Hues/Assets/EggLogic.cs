using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggLogic : MonoBehaviour
{

    public Animator finalWipe;

    private bool glasses, bow, hat, snout, cup;

    public bool[] masks = new bool[11];

    public string[] colors = new string[11];

    public Material material;

    private void Awake()
    {
        colors[0] = "_Teal";
        colors[1] = "_Red";
        colors[2] = "_Pink";
        colors[3] = "_Blue";
        colors[4] = "_DarkBlue";
        colors[5] = "_Green";
        colors[6] = "_Brown";
        colors[7] = "_Yellow";
        colors[8] = "_Beige";
        colors[9] = "_DarkPink";
        colors[10] = "_White";
    }

    // Start is called before the first frame update
    void Start()
    {
        Color color;
        ColorUtility.TryParseHtmlString("#F9B08C", out color);
        for (int i = 0; i < masks.Length; i++)
        {

            material.SetColor(colors[i], color);

        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetColor(string col) {


        Color color;
        ColorUtility.TryParseHtmlString(col, out color);
        for (int i = 0; i < masks.Length; i++)
        {
            if (!masks[i])
            {

                material.SetColor(colors[i], color);

            }
        }

    }

    public void SetBool(int num) {

        switch (num)
        {
            case(1):
                bow = !bow;
                break;
            case (2):
                cup = !cup;
                break;
            case (3):
                hat = !hat;
                break;
            case (4):
                glasses = !glasses;
                break;
            case (5):
                snout = !snout;
                break;
        }

    }

    public void SetMasks()
    {
        for (int i = 0; i < masks.Length; i ++)
        {
            masks[i] = false;
        }

        if (bow == true) {

            masks[4] = true;
            masks[5] = true;
            masks[6] = true;

        }
        if (cup == true)
        {

            masks[6] = true;
            masks[7] = true;

        }
        if (hat == true)
        {

            masks[0] = true;
            masks[8] = true;
            masks[9] = true;

        }
        if (glasses == true)
        {

            masks[1] = true;
            masks[2] = true;
            masks[8] = true;
            masks[9] = true;

        }
        if (snout == true)
        {

            masks[2] = true;
            masks[3] = true;
            masks[4] = true;
            masks[9] = true;

        }
    }

    public Color[] currentAnswers() {

        Color[] output = new Color[11];

        for (int i = 0; i < colors.Length; i++)
        {
            output[i] = material.GetColor(colors[i]);
        }

        return output;

    }

    public void Validate() {

        bool valid = true;

        for (int i = 0; i < masks.Length; i++)
        {
            if (masks[i] == true) {

                valid = false;

            }
        }

        if (valid == true) {

            finalWipe.Play("Wall_Out");

            Invoke("ChangeScene", 3);

        }

    }

    private void ChangeScene() {

        Debug.Log("Scenes: " + SceneManager.sceneCount);

        if (8 > SceneManager.GetActiveScene().buildIndex)
        {
            Debug.Log("loading: " + (SceneManager.GetActiveScene().buildIndex + 1));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else {

            Debug.Log("Main");

            SceneManager.LoadScene(0);

        }

    }

}

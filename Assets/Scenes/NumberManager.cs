using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberManager : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] Button button6;
    [SerializeField] Button button7;
    [SerializeField] Button button8;
    [SerializeField] Button button9;
    [SerializeField] Button button10;
    [SerializeField] Button button11;
    [SerializeField] Button button12;
    [SerializeField] Button button13;
    [SerializeField] Button button14;
    [SerializeField] Button button15;
    Button[] buttons;
    [SerializeField] TextMeshProUGUI scoreLabel;
    int[] numbers = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
    int[, ] relasionshipNumbers = {
    //   1  2  3  4  5  6  7  8  9  10 11 12 13 14 15
        {0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0},

        {0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0},
        {0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0},
        {0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0},
        {0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0},
        {0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1},
        
        {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
    };
    int randomNumber = 0;
    int scoreNumber = 0;

    // Start is called before the first frame update
    void Start() {
        buttons = new Button[] {button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15};

        resetLights();
        scoreReload();
    }

    // Update is called once per frame
    void Update() {
    }

    public void clickButton(int number) {
        if (numbers[number - 1] == 1) {
            buttons[number - 1].GetComponent<Image>().color = new Color32(100, 0, 200, 255);
            numbers[number - 1] = 0;
        } else if (numbers[number - 1] == 0) {
            buttons[number - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            numbers[number - 1] = 1;
        }

        scoreNumber = scoreNumber + 1;
        scoreReload();

        for (int i = 0; i < numbers.Length; i++) {
            if (relasionshipNumbers[number - 1, i] == 1 && numbers[i] == 1) {
                buttons[i].GetComponent<Image>().color = new Color32(100, 0, 200, 255);
                numbers[i] = 0;
            } else if (relasionshipNumbers[number - 1, i] == 1 && numbers[i] == 0) {
                buttons[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                numbers[i] = 1;
            }
        }
    }

    public void resetLights() {
        for (int i = 0; i < numbers.Length; i++) {
            buttons[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            numbers[i] = 1;
        }

        for (int i = 0; i < numbers.Length; i++) {
            // output 0 ~ 1
            randomNumber = UnityEngine.Random.Range(0, 2);

            if (randomNumber == 1 && numbers[i] == 1) {
                buttons[i].GetComponent<Image>().color = new Color32(100, 0, 200, 255);
                numbers[i] = 0;
            } else if (randomNumber == 1 && numbers[i] == 0) {
                buttons[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                numbers[i] = 1;
            }

            if (randomNumber == 1) {
                for (int j = 0; j < numbers.Length; j++) {
                    if (relasionshipNumbers[i, j] == 1) {
                        if (numbers[j] == 1) {
                            buttons[j].GetComponent<Image>().color = new Color32(100, 0, 200, 255);
                            numbers[j] = 0;
                        } else if (numbers[j] == 0) {
                            buttons[j].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                            numbers[j] = 1;
                        }
                    }
                }
            }
        }

        scoreNumber = 0;
        scoreReload();
    }

    public void scoreReload() {
        scoreLabel.text = "Move:" + scoreNumber.ToString();
    }
}

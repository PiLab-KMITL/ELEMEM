using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private DataController dataController;
    public Text answeringText, answeringResult, questionIndex, questionText, countdownText;
    private string _answeringPlayer, _answeringElement, _correctAnswer;
    private int _randomNumber , _questionsPerRound;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();

        PlayerPrefs.SetString("currentVuMarksPlayer", "");
        PlayerPrefs.SetString("currentVuMarksElement", "");
        dataController.roundData.currentQuestionIndex += 1;
        PlayerPrefs.SetInt("isCorrect", 0);
        PlayerPrefs.SetInt("isTimeout", 0);

        _questionsPerRound = PlayerPrefs.GetInt("QuestionsPerRound");

        timeLeft = PlayerPrefs.GetInt("SecondsPerRound");

        ShowQuestionIndex();
        ShowQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        _answeringPlayer = PlayerPrefs.GetString("currentVuMarksPlayer");
        _answeringElement = PlayerPrefs.GetString("currentVuMarksElement");
        UpdateStatusText();

        CountdownTime();


    }

    private void UpdateStatusText()
    {
        answeringText.text = "";
        answeringResult.text = "";

        if ((_answeringPlayer != "") && (dataController.GetPlayerName(_answeringPlayer) != "") && (_answeringElement == ""))
        {
            answeringText.text = dataController.GetPlayerName(_answeringPlayer);
            answeringResult.text = "Element card not found";
        }

        if ((_answeringElement != "") && (dataController.GetElementName(_answeringElement) != "") && (_answeringPlayer == ""))
        {
            answeringText.text = dataController.GetElementName(_answeringElement);
            answeringResult.text = "Player card not found";
        }

        if ((_answeringElement != "") && (_answeringPlayer != "") && (dataController.GetPlayerName(_answeringPlayer) != ""))
        {
            answeringText.text = "\"" + dataController.GetPlayerName(_answeringPlayer) + "\" has just answered \"" + dataController.GetElementName(_answeringElement) + "\"";

            if (dataController.GetElementName(_answeringElement) == _correctAnswer)
            {
                answeringResult.text = "Correct !";
                PlayerPrefs.SetInt("isCorrect", 1);
                PlayerPrefs.SetInt("isTimeout", 0);
                PlayerPrefs.SetString("currentVuMarksPlayer", dataController.GetPlayerName(_answeringPlayer));
                GameOver();
            }
            else
            {
                answeringResult.text = "Incorrect";
            }
        }


    }

    private void ShowQuestion()
    {
        int randCat = RandomNumber(0, dataController.categoryData.Length-1);

        if (dataController.roundData.selectedData[randCat].isSelected == true)
        {
            int randQIndex = RandomNumber(0, dataController.categoryData[randCat].questions.Length - 1);
            questionText.text = dataController.categoryData[randCat].questions[randQIndex].question;
            _correctAnswer = dataController.categoryData[randCat].questions[randQIndex].answer;
            Debug.Log("Q :" + questionText.text);
            Debug.Log("A :" + _correctAnswer);
            PlayerPrefs.SetString("currentQuestion", questionText.text);
            PlayerPrefs.SetString("currentAnswer", _correctAnswer);
        }
        else
        {
            ShowQuestion();
        }
    }

    private void ShowQuestionIndex()
    {
        questionIndex.text = "Question " + dataController.GetCurrentQuestionIndex() + " of " + _questionsPerRound;
    }

    private int RandomNumber(int min, int max)
    {
        _randomNumber = Random.Range(min, max+1);
        return _randomNumber;
    }

    private void CountdownTime()
    {
        timeLeft -= Time.deltaTime;

        int seconds = Mathf.RoundToInt(timeLeft);

        countdownText.text = seconds + " seconds left";
        PlayerPrefs.SetInt("currentTimeLeft", seconds);

        if (timeLeft < 0)
        {
            PlayerPrefs.SetInt("isCorrect", 0);
            PlayerPrefs.SetInt("isTimeout", 1);
            GameOver();
        }
    }

    private void GameOver()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
    }
}

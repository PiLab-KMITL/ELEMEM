using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreenController : MonoBehaviour
{
    private DataController dataController;
    public Text titleText, subTitleText, questionText, answerText, streakBonusText, currentPlayerScoreText, totalScoreText;
    private int _isCorrect, _isTimeout;

    public Image marker;
    public Button nextQuestionButton, endGameButton;

    private float scoreAddedForCorrectAnswer;
    private float _score, _bonusScore;

    void Start()
    {
        dataController = FindObjectOfType<DataController>();

        _isCorrect = PlayerPrefs.GetInt("isCorrect");
        _isTimeout = PlayerPrefs.GetInt("isTimeout");

        streakBonusText.text = "";
        currentPlayerScoreText.text = "";
        totalScoreText.text = "";

        UpdateTitleText();

        scoreAddedForCorrectAnswer = PlayerPrefs.GetFloat("ScorePerRound");

        questionText.text = PlayerPrefs.GetString("currentQuestion");
        answerText.text = PlayerPrefs.GetString("currentAnswer");

        marker.GetComponent<Image>().sprite = Resources.Load<Sprite>("Marker/" + dataController.GetAtomicNumber(PlayerPrefs.GetString("currentAnswer")));

        if (_isCorrect == 1)
        {
            CalculateScore(PlayerPrefs.GetInt("currentTimeLeft"));
            SetNewPlayerScore((PlayerPrefs.GetString("currentVuMarksPlayer")), (Mathf.RoundToInt(_score)));
        }

        if (dataController.GetCurrentQuestionIndex() >= PlayerPrefs.GetInt("QuestionsPerRound"))
        {
            nextQuestionButton.gameObject.SetActive(false);
            endGameButton.gameObject.SetActive(true);
        }
        else
        {
            nextQuestionButton.gameObject.SetActive(true);
            endGameButton.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        
    }

    public void EndGameButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Leaderboard");
    }

    public void NextQuestion()
    {

            UnityEngine.SceneManagement.SceneManager.LoadScene("LoadGame");

    }

    private void UpdateTitleText()
    {
    
        if ((_isCorrect == 0) && (_isTimeout == 1))
        {
            titleText.text = "GAME TIMEOUT";
            subTitleText.text = "Oh no .. You ran out of time, let's try again later next question.";
            ResetStreakBonus();
        }

        if ((_isCorrect == 1) && (_isTimeout == 0))
        {
            titleText.text = "CORRECT !";
            subTitleText.text = "Good job, " + PlayerPrefs.GetString("currentVuMarksPlayer") + " has just send correct answer.";
        }
    }

    private void CalculateScore(int timeLeft)
    {

        float _timeLeft = timeLeft;

        _score = (scoreAddedForCorrectAnswer * (1 - ( ((60-_timeLeft)/60) / 2)));
        //_bonusScore = 0;

        //if (PlayerPrefs.GetString("currentPlayer") == dataController.roundData.streakBonusPlayer)
        //{
        //    _bonusScore = 100 * (dataController.roundData.streakBonusCount);

        //    if (_bonusScore > 500)
        //    {
        //        _bonusScore = 500;
        //    }
        //    dataController.roundData.streakBonusCount++;
        //    //Debug.Log(dataController.roundData.streakBonusCount + "X Streak Bonus Score  +" + _bonusScore);
        //    streakBonusText.text = dataController.roundData.streakBonusCount + "X Streak Bonus Score  +" + _bonusScore;
        //}
        //else
        //{
        //    dataController.roundData.streakBonusPlayer = PlayerPrefs.GetString("currentVuMarksPlayer");
        //    dataController.roundData.streakBonusCount = 1;
        //}

        streakBonusText.text = "";
        _score += _bonusScore;

        //Debug.Log(PlayerPrefs.GetString("currentPlayer") + " answered correct answer  +" + _score);
        currentPlayerScoreText.text = PlayerPrefs.GetString("currentVuMarksPlayer") + " answered correct answer  +" + Mathf.RoundToInt(_score);

    }

    private void SetNewPlayerScore(string player, int score)
    {
        foreach (var item in dataController.roundData.playersData)
        {
            if (item.name == player)
            {
                item.score += score;
                Debug.Log(item.name + " new total score : " + item.score);
                totalScoreText.text = "Total Score = " + item.score;
            }
        }

    }

    private void ResetStreakBonus()
    {
        dataController.roundData.streakBonusCount = 0;
        dataController.roundData.streakBonusPlayer = "";
    }

    public void ReadMoreButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ElementDetails");
    }
}

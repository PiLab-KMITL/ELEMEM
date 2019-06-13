using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    public InputField questionsField, timeField, scoreField;

    private string _questions, _time, _score;

    // Use this for initialization
    void Start()
    {
        ActiveTimeInputField();
        ActiveScoreInputField();
        ActiveQuestionsInputField();

        questionsField.text = PlayerPrefs.GetInt("QuestionsPerRound").ToString();
        timeField.text = PlayerPrefs.GetInt("SecondsPerRound").ToString();
        scoreField.text = PlayerPrefs.GetFloat("ScorePerRound").ToString();

    }

    // Update is called once per frame
    void Update() {

    }

    public void SaveButton()
    {
        if (_questions != null) {

            PlayerPrefs.SetInt("QuestionsPerRound", int.Parse(_questions));
        }

        if (_questions == "" || _questions == " " || _questions == null)
        {
            questionsField.text = PlayerPrefs.GetInt("QuestionsPerRound").ToString();
            PlayerPrefs.SetInt("QuestionsPerRound", PlayerPrefs.GetInt("QuestionsPerRound"));
        }

        if (_time != null)
        {
            PlayerPrefs.SetInt("SecondsPerRound", int.Parse(_time));
        }

        if (_time == "" || _time == " " || _time == null)
        {
            timeField.text = PlayerPrefs.GetInt("SecondsPerRound").ToString();
            PlayerPrefs.SetInt("SecondsPerRound", PlayerPrefs.GetInt("SecondsPerRound"));
        }

        if (_score != null)
        {
            PlayerPrefs.SetFloat("ScorePerRound", float.Parse(_score));
        }

        if (_score == "" || _score == " " || _score == null)
        {
            scoreField.text = PlayerPrefs.GetFloat("ScorePerRound").ToString();
            PlayerPrefs.SetFloat("ScorePerRound", PlayerPrefs.GetFloat("ScorePerRound"));
        }


        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScreen");
    }

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScreen");
    }

    private void ActiveQuestionsInputField()
    {
        var input = questionsField;
        var se = new InputField.SubmitEvent();
        se.AddListener(QuestionsTextSubmitted);
        input.onEndEdit = se;
    }

    private void ActiveTimeInputField()
    {
        var input = timeField;
        var se = new InputField.SubmitEvent();
        se.AddListener(TimeTextSubmitted);
        input.onEndEdit = se;
    }

    private void ActiveScoreInputField()
    {
        var input = scoreField;
        var se = new InputField.SubmitEvent();
        se.AddListener(ScoreTextSubmitted);
        input.onEndEdit = se;
    }

    private void QuestionsTextSubmitted(string arg0)
    {
        Debug.Log("NewPlayer : " + arg0);
        _questions = arg0;

    }

    private void ScoreTextSubmitted(string arg0)
    {
        Debug.Log("NewPlayer : " + arg0);
        _score = arg0;

    }

    private void TimeTextSubmitted(string arg0)
    {
        Debug.Log("NewPlayer : " + arg0);
        _time = arg0;

    }

}

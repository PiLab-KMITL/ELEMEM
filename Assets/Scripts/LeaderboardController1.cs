using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController1 : MonoBehaviour
{

    private DataController dataController;

    public Image avatar1, avatar2, avatar3, avatar4;
    public GameObject player1, player2, player3, player4;
    public Text name1, name2, name3, name4, score1, score2, score3, score4;
    private int player1score, player2score, player3score, player4score, max;

    private int _currentPlayer, _tempIndex;


    // Use this for initialization
    void Start()
    {

        dataController = FindObjectOfType<DataController>();


        UnHideRank();

        ShowData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenuButton()
    {
        dataController.ResetCurrentQuestionIndex();
        dataController.ResetPlayerData();
        dataController.ResetStreakBonus();
        dataController.ResetCurrentQuestionIndex();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Persistent");
        Destroy(GameObject.Find("DataController"));
    }

    private void UnHideRank()
    {
        for (int i = 0; i < dataController.GetCountPlayer(); i++)
        {
            if (i == 0)
            {
                player1.gameObject.SetActive(true);
            }
            if (i == 1)
            {
                player2.gameObject.SetActive(true);
            }
            if (i == 2)
            {
                player3.gameObject.SetActive(true);
            }
            if (i == 3)
            {
                player4.gameObject.SetActive(true);
            }

        }
    }

    private void ShowData()
    {
        GetTempScore();

        for (int i = 0; i < dataController.GetCountPlayer(); i++)
        {
            _currentPlayer = i + 1;
            GetHighestScore();
            FindPlayerIndex(max);
        }


    }

    private void GetHighestScore()
    {

            if (player1score > player2score)
            {
                max = player1score;
                _tempIndex = 1;
            }

            if (player1score < player2score)
            {
                max = player2score;
                _tempIndex = 2;
            }

            if (max < player3score)
            {
                max = player3score;
                _tempIndex = 3;
            }

            if (max < player4score)
            {
                max = player4score;
                _tempIndex = 4;
            }


        if (_tempIndex == 1)
        {
            player1score = -999;
        }
        if (_tempIndex == 2)
        {
            player2score = -999;
        }
        if (_tempIndex == 3)
        {
            player3score = -999;
        }
        if (_tempIndex == 4)
        {
            player4score = -999;
        }
    }

    private void GetTempScore()
    {

        if (dataController.roundData.playersData[0].isActive == true)
        {
            player1score = dataController.roundData.playersData[0].score;
        }
        else
        {
            player1score = 0;
        }

        if (dataController.roundData.playersData[1].isActive == true)
        {
            player2score = dataController.roundData.playersData[1].score;
        }
        else
        {
            player2score = 0;
        }

        if (dataController.roundData.playersData[2].isActive == true)
        {
            player3score = dataController.roundData.playersData[2].score;
        }
        else
        {
            player3score = 0;
        }

        if (dataController.roundData.playersData[3].isActive == true)
        {
            player4score = dataController.roundData.playersData[3].score;
        }
        else
        {
            player4score = 0;
        }
    }

    private void FindPlayerIndex(int score)
    {
        foreach (var item in dataController.roundData.playersData)
        {
            if (score == item.score && ((item.isActive == true) && (item.isDisplayed == false)))
            {
                if (_currentPlayer == 1)
                {
                    name1.text = item.name;
                    avatar1.GetComponent<Image>().sprite = Resources.Load<Sprite>("avatar-" + item.avatar);
                    score1.text = item.score.ToString();
                    item.isDisplayed = true;
                    break;
                }

                if (_currentPlayer == 2)
                {
                    name2.text = item.name;
                    avatar2.GetComponent<Image>().sprite = Resources.Load<Sprite>("avatar-" + item.avatar);
                    score2.text = item.score.ToString();
                    item.isDisplayed = true;
                    break;
                }

                if (_currentPlayer == 3)
                {
                    name3.text = item.name;
                    avatar3.GetComponent<Image>().sprite = Resources.Load<Sprite>("avatar-" + item.avatar);
                    score3.text = item.score.ToString();
                    item.isDisplayed = true;
                    break;
                }

                if (_currentPlayer == 4)
                {
                    name4.text = item.name;
                    avatar4.GetComponent<Image>().sprite = Resources.Load<Sprite>("avatar-" + item.avatar);
                    score4.text = item.score.ToString();
                    item.isDisplayed = true;
                    break;
                }
            }
        }
    }

}

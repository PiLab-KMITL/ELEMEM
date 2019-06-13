using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour {

    private DataController dataController;

    public Image avatar1, avatar2, avatar3, avatar4;
    public GameObject player1, player2, player3, player4, leaderboard;
    public Text name1, name2, name3, name4, score1, score2, score3, score4;


	// Use this for initialization
	void Start () {

        dataController = FindObjectOfType<DataController>();

        UpdateScore();
        MoveLeaderboard();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateScore()
    {

        if (dataController.roundData.playersData[0].isActive == true)
        {
            player1.gameObject.SetActive(true);
            avatar1.GetComponent<Image>().sprite = Resources.Load<Sprite>("avatar-" + dataController.roundData.playersData[0].avatar);
            name1.text = dataController.roundData.playersData[0].name;
            score1.text = dataController.roundData.playersData[0].score.ToString();
        } else
        {
            player1.gameObject.SetActive(false);
        }

        if (dataController.roundData.playersData[1].isActive == true)
        {
            player2.gameObject.SetActive(true);
            avatar2.GetComponent<Image>().sprite = Resources.Load<Sprite>("avatar-" + dataController.roundData.playersData[1].avatar);
            name2.text = dataController.roundData.playersData[1].name;
            score2.text = dataController.roundData.playersData[1].score.ToString();
        }
        else
        {
            player2.gameObject.SetActive(false);
        }

        if (dataController.roundData.playersData[2].isActive == true)
        {
            player3.gameObject.SetActive(true);
            avatar3.GetComponent<Image>().sprite = Resources.Load<Sprite>("avatar-" + dataController.roundData.playersData[2].avatar);
            name3.text = dataController.roundData.playersData[2].name;
            score3.text = dataController.roundData.playersData[2].score.ToString();
        }
        else
        {
            player3.gameObject.SetActive(false);
        }

        if (dataController.roundData.playersData[3].isActive == true)
        {
            player4.gameObject.SetActive(true);
            avatar4.GetComponent<Image>().sprite = Resources.Load<Sprite>("avatar-" + dataController.roundData.playersData[3].avatar);
            name4.text = dataController.roundData.playersData[3].name;
            score4.text = dataController.roundData.playersData[3].score.ToString();
        }
        else
        {
            player4.gameObject.SetActive(false);
        }
    }

    private void MoveLeaderboard()
    {
        if (dataController.GetCountPlayer() <= 2)
        {
            Vector3 positionLeaderboard = leaderboard.transform.position;
            positionLeaderboard.y -= 90;
            leaderboard.transform.position = positionLeaderboard;
        }

        if (dataController.GetCountPlayer() == 1)
        {
            Vector3 positionPlayer = player1.transform.position;
            positionPlayer.x += 325;
            player1.transform.position = positionPlayer;
        }

        //if (dataController.GetCountPlayer() == 3)
        //{
        //    Vector3 positionPlayer = player3.transform.position;
        //    positionPlayer.x += 325;
        //    player3.transform.position = positionPlayer;
        //}

    }
}

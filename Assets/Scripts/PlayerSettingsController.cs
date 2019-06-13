using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSettingsController : MonoBehaviour
{

    public Text playerName1, playerName2, playerName3, playerName4 ;
    public Image player1, player2, player3, player4;
    public Button newplayer1, newplayer2, newplayer3, newplayer4, nextButton;

    private DataController dataController;

    void Start()
    {

        dataController = FindObjectOfType<DataController>();

        ActiveNextButton();
        ActiveNewPlayerButton();
        ActivePlayerImage();
        Debug.Log(dataController.GetCountPlayer().ToString());

    }

    void Update()
    {

    }

    public void AddNewPlayerButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NewPlayer");
    }

    public void NextButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadGame");
    }

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectLevel");
    }
      

    private void ActiveNextButton()
    {
        if (dataController.GetCountPlayer() == 0)
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
        }
    }

    private void ActiveNewPlayerButton()
    {
        if (dataController.GetCountPlayer() == 0)
        {
            newplayer1.gameObject.SetActive(true);
            newplayer2.gameObject.SetActive(false);
            newplayer3.gameObject.SetActive(false);
            newplayer4.gameObject.SetActive(false);
        }
        if (dataController.GetCountPlayer() == 1)
        {
            newplayer1.gameObject.SetActive(false);
            newplayer2.gameObject.SetActive(true);
            newplayer3.gameObject.SetActive(false);
            newplayer4.gameObject.SetActive(false);
        }
        if (dataController.GetCountPlayer() == 2)
        {
            newplayer1.gameObject.SetActive(false);
            newplayer2.gameObject.SetActive(false);
            newplayer3.gameObject.SetActive(true);
            newplayer4.gameObject.SetActive(false);
        }
        if (dataController.GetCountPlayer() == 3)
        {
            newplayer1.gameObject.SetActive(false);
            newplayer2.gameObject.SetActive(false);
            newplayer3.gameObject.SetActive(false);
            newplayer4.gameObject.SetActive(true);
        }
        if (dataController.GetCountPlayer() == 4)
        {
            newplayer1.gameObject.SetActive(false);
            newplayer2.gameObject.SetActive(false);
            newplayer3.gameObject.SetActive(false);
            newplayer4.gameObject.SetActive(false);
        }
    }

    void ActivePlayerImage()
    {
        for (int i = 0; i < dataController.GetCountPlayer(); i++)
        {
            if(i == 0 && (dataController.roundData.playersData[i].isActive == true))
            {
                player1.gameObject.SetActive(true);
                player1.GetComponent<Image>().sprite = Resources.Load<Sprite>("player-" + dataController.roundData.playersData[i].avatar);
                playerName1.text = dataController.roundData.playersData[i].name;
            }

            if (i == 1 && (dataController.roundData.playersData[i].isActive == true))
            {
                player2.gameObject.SetActive(true);
                player2.GetComponent<Image>().sprite = Resources.Load<Sprite>("player-" + dataController.roundData.playersData[i].avatar);
                playerName2.text = dataController.roundData.playersData[i].name;
            }

            if (i == 2 && (dataController.roundData.playersData[i].isActive == true))
            {
                player3.gameObject.SetActive(true);
                player3.GetComponent<Image>().sprite = Resources.Load<Sprite>("player-" + dataController.roundData.playersData[i].avatar);
                playerName3.text = dataController.roundData.playersData[i].name;
            }

            if (i == 3 && (dataController.roundData.playersData[i].isActive == true))
            {
                player4.gameObject.SetActive(true);
                player4.GetComponent<Image>().sprite = Resources.Load<Sprite>("player-" + dataController.roundData.playersData[i].avatar);
                playerName4.text = dataController.roundData.playersData[i].name;
            }
        }
    }



}

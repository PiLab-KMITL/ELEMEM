using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayerController : MonoBehaviour
{

    private DataController dataController;
    public Button avatarButton96, avatarButton97, avatarButton98, avatarButton99, submitButton, backButton;
    public InputField nameInputField;
    public Text error;
    private string _PlayerName, _SelectedAvatar;

    private bool _isNameTaken;

    void Start()
    {
        dataController = FindObjectOfType<DataController>();


        UnInterractSelectedAvatar();
        ActiveInputField();

        avatarButton96.onClick.AddListener(delegate { _SelectedAvatar = "96"; SelectImage(); });
        avatarButton97.onClick.AddListener(delegate { _SelectedAvatar = "97"; SelectImage(); });
        avatarButton98.onClick.AddListener(delegate { _SelectedAvatar = "98"; SelectImage(); });
        avatarButton99.onClick.AddListener(delegate { _SelectedAvatar = "99"; SelectImage(); });

        backButton.onClick.AddListener(delegate ()
        { 
            SceneManager.LoadScene("Player");
        });

        submitButton.onClick.AddListener(delegate ()
        {
            SetNewPlayerData();
            SceneManager.LoadScene("Player");
        });



    }

    void Update()
    {

        SetActiveSubmitButton();

    }

    private void UnInterractSelectedAvatar()
    {
        foreach (var item in dataController.roundData.playersData)
        {
            if (item.isActive == true)
            {
                if (item.avatar == "96")
                {
                    avatarButton96.interactable = false;
                }
                else if (item.avatar == "97")
                {
                    avatarButton97.interactable = false;
                }
                else if (item.avatar == "98")
                {
                    avatarButton98.interactable = false;
                }
                else if (item.avatar == "99")
                {
                    avatarButton99.interactable = false;
                }
            }
        }
    }

    private void TextSubmitted(string arg0)
    {
        Debug.Log("NewPlayer : " + arg0);
        _PlayerName = arg0;

        IsThisNameTaken();
    }

    private void SetActiveSubmitButton()
    {


        //set submit button visible
        if (_isNameTaken == true)
        {
            submitButton.gameObject.SetActive(false);
            error.gameObject.SetActive(true);
        } else
        {
            if (_PlayerName != null && _SelectedAvatar != null && _PlayerName != "")
            {
                submitButton.gameObject.SetActive(true);
                error.gameObject.SetActive(false);
            }
            else
            {
                submitButton.gameObject.SetActive(false);
                error.gameObject.SetActive(false);
            }
        }


    }

    private void ActiveInputField()
    {
        var input = nameInputField;
        var se = new InputField.SubmitEvent();
        se.AddListener(TextSubmitted);
        input.onEndEdit = se;
    }

    private void SetNewPlayerData()
    {
        int _countPlayer = dataController.GetCountPlayer();

        dataController.roundData.playersData[_countPlayer].isActive = true;
        dataController.roundData.playersData[_countPlayer].name = _PlayerName;
        dataController.roundData.playersData[_countPlayer].avatar = _SelectedAvatar;
        dataController.roundData.playersData[_countPlayer].score = 0;
        error.gameObject.SetActive(false);
    }

    private void SelectImage()
    {
        if (_SelectedAvatar == "96")
        {
            avatarButton96.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar96-s");
            avatarButton97.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar97");
            avatarButton98.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar99");
            avatarButton99.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar98");
        }

        if (_SelectedAvatar == "97")
        {
            avatarButton96.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar96");
            avatarButton97.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar97-s");
            avatarButton98.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar99");
            avatarButton99.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar98");
        }

        if (_SelectedAvatar == "99")
        {
            avatarButton96.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar96");
            avatarButton97.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar97");
            avatarButton98.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar99");
            avatarButton99.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar98-s");
        }

        if (_SelectedAvatar == "98")
        {
            avatarButton96.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar96");
            avatarButton97.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar97");
            avatarButton98.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar99-s");
            avatarButton99.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-avatar98");
        }
    }

    void IsThisNameTaken()
    {
        _isNameTaken = false;

        foreach (var item in dataController.roundData.playersData)
        {
            if (item.isActive == true)
            {
                if (item.name == _PlayerName)
                {
                    _isNameTaken = true;
                }
            }
        }
    }
}

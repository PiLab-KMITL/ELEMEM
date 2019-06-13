using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelController : MonoBehaviour
{

    private DataController dataController;
    private Button _nextButton;

    public Text textOnScreen;
    private string _selectedData;
    private int _count;

    void Awake()
    {
        _nextButton = GetComponent<Button>();
    }


    void Start()
    {
        dataController = FindObjectOfType<DataController>();

        _nextButton = GameObject.Find("Next Button").GetComponent<Button>();
        _nextButton.gameObject.SetActive(false);

    }


    void Update()
    {
        ShowSelectedData();
        SetActiveNextButton();
    }

  
    public void NextButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Player");
    }

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScreen");
    }

    public void SetActiveNextButton()
    {
        if (dataController.GetCountSelectedData() > 0)
        {
            _nextButton.gameObject.SetActive(true);
        }
        else
        {
            _nextButton.gameObject.SetActive(false);
        }
    }

    public void ShowSelectedData()
    {
        _selectedData = "";
        foreach (var item in dataController.roundData.selectedData)
        {
            if (item.isSelected == true)
            {
                if(_selectedData != "")
                {
                    _selectedData += ", ";
                }
                _selectedData += item.category;
            }
        }
        textOnScreen.text = "Selected : " + _selectedData;
    }

}

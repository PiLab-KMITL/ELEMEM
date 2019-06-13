using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsController : MonoBehaviour {

    private DataController dataController;

    public Text atomicNum, symbol, group, period, series, phase, mp, bp, details, name;
    public Image marker;

    private string _atomicNum;
    private int _atomicNumInt;

	// Use this for initialization
	void Start () {

        dataController = FindObjectOfType<DataController>();

        _atomicNum = dataController.GetAtomicNumber(PlayerPrefs.GetString("currentAnswer"));
        _atomicNumInt = int.Parse(_atomicNum);

        marker.GetComponent<Image>().sprite = Resources.Load<Sprite>("Marker/" + _atomicNum);

        atomicNum.text = _atomicNum;
        name.text = PlayerPrefs.GetString("currentAnswer");

        atomicNum.text = dataController.elementsData[_atomicNumInt].name;
        symbol.text = dataController.elementsData[_atomicNumInt].symbol;
        group.text = dataController.elementsData[_atomicNumInt].group;
        period.text = dataController.elementsData[_atomicNumInt].period;
        series.text = dataController.elementsData[_atomicNumInt].elementCategory;
        phase.text = dataController.elementsData[_atomicNumInt].phase;
        mp.text = dataController.elementsData[_atomicNumInt].meltingPoint;
        bp.text = dataController.elementsData[_atomicNumInt].boilingPoint;
        details.text = dataController.elementsData[_atomicNumInt].shortDetails;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
    }
}

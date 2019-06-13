using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryController : MonoBehaviour
{
    private DataController dataController;

    public Button categoryButton1, categoryButton2, categoryButton3, categoryButton4, categoryButton5, categoryButton6, categoryButton7, categoryButton8, categoryButton9;
    private bool isSelected1, isSelected2, isSelected3, isSelected4, isSelected5, isSelected6, isSelected7, isSelected8, isSelected9;


    void Start()
    {
        dataController = FindObjectOfType<DataController>();

        categoryButton1.onClick.AddListener(delegate { SelectCategory(6,1); });
        categoryButton2.onClick.AddListener(delegate { SelectCategory(8,2); });
        categoryButton3.onClick.AddListener(delegate { SelectCategory(7,3); });
        categoryButton4.onClick.AddListener(delegate { SelectCategory(0,4); });
        categoryButton5.onClick.AddListener(delegate { SelectCategory(1,5); });
        categoryButton6.onClick.AddListener(delegate { SelectCategory(4,6); });
        categoryButton7.onClick.AddListener(delegate { SelectCategory(3,7); });
        categoryButton8.onClick.AddListener(delegate { SelectCategory(5,8); });
        categoryButton9.onClick.AddListener(delegate { SelectCategory(2,9); });

        updateSelectedCategory();
    }

    void Update()
    {

    }

    public void SelectCategory(int index, int button)
    {

        
        Button myButton = GameObject.Find("Category " + button).GetComponent<Button>();


        if (dataController.roundData.selectedData[index].isSelected == false)
        {
            dataController.roundData.selectedData[index].isSelected = true;

            myButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat"+button+"-s");


        }
        else
        {
            dataController.roundData.selectedData[index].isSelected = false;

            myButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat" + button);
        }

    }

    private void updateSelectedCategory()
    {
        for (int index = 0; index < 9; index++)
        {
            if (dataController.roundData.selectedData[index].isSelected == true)
            {
                if (index ==0)
                {
                    categoryButton4.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat4-s");
                }
                if (index == 1)
                {
                    categoryButton5.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat5-s");
                }
                if (index == 2)
                {
                    categoryButton9.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat9-s");
                }
                if (index == 3)
                {
                    categoryButton7.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat7-s");
                }
                if (index == 4)
                {
                    categoryButton6.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat6-s");
                }
                if (index == 5)
                {
                    categoryButton8.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat8-s");
                }
                if (index == 6)
                {
                    categoryButton1.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat1-s");
                }
                if (index == 7)
                {
                    categoryButton3.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat3-s");
                }
                if (index == 8)
                {
                    categoryButton2.GetComponent<Image>().sprite = Resources.Load<Sprite>("button-cat2-s");
                }


            }
           
        }
    }

}
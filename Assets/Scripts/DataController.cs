using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public ElementsData[] elementsData;
    public CategoryData[] categoryData;
    public RoundData roundData;
    //public GameData[] gameData;

    private string dataAsJson;
    private string playerName, elementName, elementAtomicNumber;

//    private readonly string elementsDataRoute = "https://elementswithfriends.firebaseio.com/ElementsData.json";
    private readonly string gameDataFileName = "data3.json";

    public static string Get { get; internal set; }

    void Start()
    {
        PlayerPrefs.DeleteAll();
        DontDestroyOnLoad(this.gameObject);
        LoadElementsData();
        LoadCategoryToRoundData();

        ResetPlayerData();
        ResetSelectedData();
        ResetCurrentQuestionIndex();
        ResetStreakBonus();

        PlayerPrefs.SetInt("QuestionsPerRound", 20);
        PlayerPrefs.SetInt("SecondsPerRound", 60);
        PlayerPrefs.SetFloat("ScorePerRound", 1500);
        SceneManager.LoadScene("MenuScreen");


    }


    void Update()
    {
        
    }


    private void LoadElementsData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            dataAsJson = File.ReadAllText(filePath);

            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            elementsData = loadedData.elementsData;
            categoryData = loadedData.categoryData;

            //Debug.Log(elementsData[1].name);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

    public int GetCountPlayer()
    {
        int count = 0;
        foreach (var item in roundData.playersData)
        {
            if (item.isActive == true)
            {
                count++;
            }
        }
        return count;
    }

    public int GetCurrentQuestionIndex()
    {
        return roundData.currentQuestionIndex;
    }

    public int GetCountSelectedData()
    {
        int count = 0;
        foreach (var item in roundData.selectedData)
        {
            if (item.isSelected == true)
            {
                count++;
            }
        }
        return count;
    }

    public void ResetPlayerData()
    {
        for (int i = 0; i < roundData.playersData.Length; i++)
        {
            roundData.playersData[i].name = "";
            roundData.playersData[i].avatar = "";
            roundData.playersData[i].score = 0;
            roundData.playersData[i].isDisplayed = false;
        }
    }

    public void ResetSelectedData()
    {
        for (int i = 0; i < categoryData.Length; i++)
        {
            roundData.selectedData[i].isSelected = false;
        }
    }

    public void ResetCurrentQuestionIndex()
    {
        roundData.currentQuestionIndex = 0;
    }

    private void LoadCategoryToRoundData()
    {
        int _countCategory = categoryData.Length;

        for (int i = 0; i < _countCategory; i++)
        {
            roundData.selectedData[i].category = categoryData[i].category;
        }
    }

    public string GetPlayerName (string avatar)
    {
        foreach (var item in roundData.playersData)
        {
            if (avatar == item.avatar)
            {
                playerName = item.name;
            }
        }
        return playerName;
    }

    public string GetElementName (string atomicNumber)
    {
        elementName = elementsData[int.Parse(atomicNumber)].name;

        return elementName;
    }

    public void ResetStreakBonus()
    {
        roundData.streakBonusCount = 0;
        roundData.streakBonusPlayer = "";
    }

    public string GetAtomicNumber (string name)
    {
        foreach (var item in elementsData)
        {
            if (item.name == name)
            {
                elementAtomicNumber = item.atomicNumber;
            }
        }

        return elementAtomicNumber;
    }

}

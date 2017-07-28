using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public Button[] buttonList;
    public Button pickAxebtn;
    public Button Axebtn;
    public Button Explosivesbtn;
    public Button woodBtn;
    public Button stoneBtn;
    public Button diamondBtn;
    public Text pickAxetxt;
    public Text axeTxt;
    public Text ExplosivesTxt;
    public Text woodText;
    public Text stoneText;
    public Text diamondText;
    public Slider energySlid;
    public Text energyText;
    private bool isFocused;
    private int pickAxeResources = 0;
    private int axeResources = 0;
    private int ExplosivesResources = 0;
    private int woodResources = 0;
    private int stoneResources = 0;
    private int diamResources = 0;
    private int resourcesPerClick = 1;
    private int startingEnergy = 10;
    private int currentEnergy = 10;
    private int explosiveEnergy = 10;
    private int selectedButton = 0;
    private long tempTime;
    private float timeAway;
    public float hours = 12 * 3600.0f;
    public float startTime;
    float cost = 10.0f;
    float m_cost;

	void Start ()
    {
        buttonList = new Button[5];

        buttonList[0].image = GameObject.Find("DiamondButton").GetComponent<Image>();
        buttonList[0].image.color = Color.yellow;
        buttonList[1].image = GameObject.Find("StoneButton").GetComponent<Image>();
        buttonList[1].image.color = Color.yellow;
        buttonList[2].image = GameObject.Find("WoodButton").GetComponent<Image>();
        buttonList[2].image.color = Color.yellow;
        buttonList[3].image = GameObject.Find("PickAxeBtn").GetComponent<Image>();
        buttonList[3].image.color = Color.yellow;
        buttonList[4].image = GameObject.Find("AxeBtn").GetComponent<Image>();
        buttonList[4].image.color = Color.yellow;
        buttonList[5].image = GameObject.Find("ExplosiveBtn").GetComponent<Image>();
        buttonList[5].image.color = Color.yellow;


        woodBtn = woodBtn.GetComponent<Button>();
        woodBtn.onClick.AddListener(UpdateBtnWood);
        stoneBtn = stoneBtn.GetComponent<Button>();
        stoneBtn.onClick.AddListener(UpdateBtnStone);
        diamondBtn = diamondBtn.GetComponent<Button>();
        diamondBtn.onClick.AddListener(UpdateBtnDiamond);
        pickAxebtn = pickAxebtn.GetComponent<Button>();
        pickAxebtn.onClick.AddListener(UpdateBtnPick);
        Axebtn = Axebtn.GetComponent<Button>();
        Axebtn.onClick.AddListener(UpdateBtnAxe);
        Explosivesbtn = Explosivesbtn.GetComponent<Button>();
        Explosivesbtn.onClick.AddListener(UpdateExBtn);
	}

    public void UpdateExBtn()
    {
        if(currentEnergy >= explosiveEnergy)
        {
            currentEnergy -= explosiveEnergy;
            ExplosivesResources += resourcesPerClick;
            cost = Mathf.Round(cost * 1.15f);
            m_cost = Mathf.Pow(cost, m_cost = cost);
            resourcesPerClick += explosiveEnergy;
        }else if (currentEnergy < explosiveEnergy)
        {
            Explosivesbtn.interactable = false;
        }
    }

    public void UpdateBtnAxe()
    {
        if (currentEnergy >= 5)
        {
            currentEnergy -= 5;
            axeResources += resourcesPerClick;
            cost = Mathf.Round(cost * 1.15f);
            m_cost = Mathf.Pow(cost, m_cost = cost);
            resourcesPerClick += 5;
        }else if (currentEnergy < 5)
        {
            Axebtn.interactable = false;
        }
    }

    public void UpdateBtnPick()
    {
        if(currentEnergy >= 2)
        {
            currentEnergy -= 2;
            pickAxeResources += resourcesPerClick;
            cost = Mathf.Round(cost * 1.15f);
            m_cost = Mathf.Pow(cost, m_cost = cost);
            resourcesPerClick += 2;
        }else if (currentEnergy < 2)
        {
            pickAxebtn.interactable = false;
        }
    }

    void Update ()
    {
        startTime += Time.deltaTime;
        woodText.text = "Wood : " + woodResources;
        stoneText.text = "Stone : " + stoneResources;
        diamondText.text = "Diamond : " + diamResources;
        energyText.text = "Energy : " + currentEnergy + "/10";
        pickAxetxt.text = "How Many PickAxe : " + pickAxeResources;
        axeTxt.text = "How Many Axe : " + axeResources;
        ExplosivesTxt.text = "How Many Explosives : " + ExplosivesResources;
        energySlid.value = currentEnergy;
        DisableBtn();
        RegenerateEnergy();
        PlayerPrefs.Save();

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            MoveToNextButton();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveToPreviousButton();
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            MoveToPreviousButton();
            MoveToPreviousButton();
            MoveToPreviousButton();
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            MoveToNextButton();
            MoveToNextButton();
            MoveToNextButton();
        }

	}


    public void UpdateBtnWood()
    {
        woodResources += resourcesPerClick;
        currentEnergy--;
    }

    public void UpdateBtnStone()
    {
        stoneResources += resourcesPerClick;
        currentEnergy--;
    }
    public void UpdateBtnDiamond()
    {
        diamResources += resourcesPerClick;
        currentEnergy--;
    }

    void RegenerateEnergy()
    {
        if(startTime >= hours)
        {
            currentEnergy = startingEnergy;
            startTime = 0;
        }
    }

    public void DisableBtn()
    {
        if(currentEnergy == 0)
        {
            woodBtn.interactable = false;
            diamondBtn.interactable = false;
            stoneBtn.interactable = false;
            pickAxebtn.interactable = false;
            Axebtn.interactable = false;
            Explosivesbtn.interactable = false;
        }
        else
        {
            woodBtn.interactable = true;
            diamondBtn.interactable = true;
            stoneBtn.interactable = true;
            pickAxebtn.interactable = true;
            Axebtn.interactable = true;
            Explosivesbtn.interactable = true;
        }
    }

    private void Awake()
    {
        currentEnergy = PlayerPrefs.GetInt("Energy");
        if(PlayerPrefs.HasKey("Energy"))
        {
            tempTime = Convert.ToInt64(PlayerPrefs.GetString("Energy"));
            timeAway = DateTime.Now.Subtract(DateTime.FromBinary(tempTime)).Seconds;
        }
        currentEnergy += (int)timeAway;
        resourcesPerClick = PlayerPrefs.GetInt("Click");
        startTime = PlayerPrefs.GetFloat("TimeSpend");
        diamResources = PlayerPrefs.GetInt("Diamond");
        woodResources = PlayerPrefs.GetInt("Wood");
        stoneResources = PlayerPrefs.GetInt("Stone");
        pickAxeResources = PlayerPrefs.GetInt("PickAxe");
        axeResources = PlayerPrefs.GetInt("Axe");
        ExplosivesResources = PlayerPrefs.GetInt("Explosives");
        PlayerPrefs.Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetString("Energy", DateTime.Now.ToBinary().ToString());
            PlayerPrefs.SetInt("Click", resourcesPerClick);
            PlayerPrefs.SetInt("Energy", currentEnergy);
            PlayerPrefs.SetFloat("TimeSpend", startTime);
            PlayerPrefs.SetInt("Diamond", diamResources);
            PlayerPrefs.SetInt("Wood", woodResources);
            PlayerPrefs.SetInt("Stone", stoneResources);
            PlayerPrefs.SetInt("PickAxe", pickAxeResources);
            PlayerPrefs.SetInt("Axe", axeResources);
            PlayerPrefs.SetInt("Explosives", ExplosivesResources);
            long timeb4alarm = (long)(startingEnergy - currentEnergy) * 1000L;
            using (AndroidJavaClass aJC = new AndroidJavaClass("com.example.a1630077.tpfinal"))
            {
                aJC.CallStatic("ScheduleNotification", timeb4alarm, "Your energy is now full", 5997348);
            }
            PlayerPrefs.Save();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Energy", DateTime.Now.ToBinary().ToString());
        PlayerPrefs.SetInt("Energy", currentEnergy);
        PlayerPrefs.SetInt("Click", resourcesPerClick);
        PlayerPrefs.SetFloat("TimeSpend", startTime);
        PlayerPrefs.SetInt("Diamond", diamResources);
        PlayerPrefs.SetInt("Wood", woodResources);
        PlayerPrefs.SetInt("Stone",stoneResources);
        PlayerPrefs.SetInt("PickAxe",pickAxeResources);
        PlayerPrefs.SetInt("Axe",axeResources);
        PlayerPrefs.SetInt("Explosives", ExplosivesResources);
        long timeb4alarm = (long)(startingEnergy - currentEnergy) * 1000L;
        using (AndroidJavaClass aJC = new AndroidJavaClass("com.example.a1630077.tpfinal"))
        {
            aJC.CallStatic("ScheduleNotification", timeb4alarm , "Your energy is now full", 5997348);
        }
        PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
    }

    private void OnApplicationFocus(bool focus)
    {
        focus = isFocused;
        if(focus)
        {
            currentEnergy = PlayerPrefs.GetInt("Energy");
            if (PlayerPrefs.HasKey("Energy"))
            {
                tempTime = Convert.ToInt64(PlayerPrefs.GetString("Energy"));
                timeAway = DateTime.Now.Subtract(DateTime.FromBinary(tempTime)).Seconds;
            }
            currentEnergy += (int)timeAway;
            resourcesPerClick = PlayerPrefs.GetInt("Click");
            startTime = PlayerPrefs.GetFloat("TimeSpend");
            diamResources = PlayerPrefs.GetInt("Diamond");
            woodResources = PlayerPrefs.GetInt("Wood");
            stoneResources = PlayerPrefs.GetInt("Stone");
            pickAxeResources = PlayerPrefs.GetInt("PickAxe");
            axeResources = PlayerPrefs.GetInt("Axe");
            ExplosivesResources = PlayerPrefs.GetInt("Explosives");
            PlayerPrefs.Save();
        }
    }


    void MoveToNextButton()
    {
        buttonList[selectedButton].image.color = Color.white;
        selectedButton++;
        if (selectedButton >= buttonList.Length)
        {
            selectedButton = 0;
        }
        buttonList[selectedButton].image.color = Color.yellow;
    }

    void MoveToPreviousButton()
    {
        buttonList[selectedButton].image.color = Color.white;
        selectedButton--;
        if (selectedButton < 0)
        {
            selectedButton = (buttonList.Length - 1);
        }
        buttonList[selectedButton].image.color = Color.yellow;
    }


}

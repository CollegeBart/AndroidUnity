using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
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
    int pickAxeResources = 0;
    int axeResources = 0;
    int ExplosivesResources = 0;
    int woodResources = 0;
    int stoneResources = 0;
    int diamResources = 0;
    int resourcesPerClick = 1;
    int startingEnergy = 10;
    int currentEnergy;
    int explosiveEnergy = 10;
    public float hours = 12 * 3600.0f;
    float startTime;
    float cost = 10.0f;
    float m_cost;

	void Start ()
    {
        currentEnergy = startingEnergy;
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
        startTime += Time.deltaTime;
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
            currentEnergy = 10;
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


}

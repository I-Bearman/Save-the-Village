using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ImageTimer HarvestTimer;
    public ImageTimer EatingTimer;
    public Image RaidTimerImg;
 
    public Button peasantButton;
    public Button warriorButton;

    public Text countText;

    public int wheatCount;
    public int peasantCount;
    public int warriorCount;
    private int totalWarriors;
    public int assassinsCount;

    public int peasantCost;
    public int warriorCost;

    public int wheatPerPeasant;
    public int wheatPerWarrior;

    public float peasantCreateTime;
    public float warriorCreateTime;

    public int beforeFirstAttack;
    public int raidMaxTime;
    public int raidIncrease;
    public Text RaidCountTitle;
    public Text RaidCountText;
    public Text GameOverText, VictoryText;
    

    public GameObject GameOverScreen, VictoryScreen;
    public AudioSource HarvestAudio, EatingAudio, AttackAudio, ClickSound;
    private AudioSource DiferentSounds;
    
    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;
    private int raidCount = 0;

    public int winCount;

    void Start()
    {
        UpdateText();
        raidTimer = raidMaxTime;
        RaidCountText.text = beforeFirstAttack.ToString();
        totalWarriors = warriorCount;
    }

    // Update is called once per frame
    void Update()
    {
        raidTimer -= Time.deltaTime;
        RaidTimerImg.fillAmount = raidTimer / raidMaxTime;

        if (raidTimer <= 0)
        {
            if (beforeFirstAttack == 0)
            {
                RaidCountTitle.text = "Атак отбито";
                raidTimer = raidMaxTime;
                warriorCount -= assassinsCount;
                assassinsCount += raidIncrease;
                AttackAudio.Play();
                raidCount++;
                RaidCountText.text = raidCount.ToString();
            }
            else
            {
                raidTimer = raidMaxTime;
                beforeFirstAttack--;
                RaidCountText.text = beforeFirstAttack.ToString();
            }            
        }
            

        if (HarvestTimer.tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
            HarvestAudio.Play();
            
        }
            
        if (EatingTimer.tick)
        {
            wheatCount -= warriorCount * wheatPerWarrior;
            EatingAudio.Play();
        }
            

        if (peasantTimer >0)
        {
            peasantTimer -= Time.deltaTime;
            peasantButton.image.fillAmount = peasantTimer / peasantCreateTime;
        }
        else if (peasantTimer > -1)
        {
            peasantButton.image.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            peasantTimer = -2;
            DiferentSounds = peasantButton.GetComponent<AudioSource>();
            DiferentSounds.Play();
        }
              
        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            warriorButton.image.fillAmount = warriorTimer / warriorCreateTime;
        }
        else if (warriorTimer > -1)
        {
            warriorButton.image.fillAmount = 1;
            warriorButton.interactable = true;
            warriorCount += 1;
            totalWarriors += 1;
            warriorTimer = -2;
            DiferentSounds = warriorButton.GetComponent<AudioSource>();
            DiferentSounds.Play();
        }

        if (peasantTimer == -2 && peasantButton.interactable == true && wheatCount < peasantCost)
            peasantButton.interactable = false;
        if (peasantTimer == -2 && peasantButton.interactable == false && wheatCount >= peasantCost)
            peasantButton.interactable = true;

        if (warriorTimer == -2 && warriorButton.interactable == true && wheatCount < warriorCost)
            warriorButton.interactable = false;
        if (warriorTimer == -2 && warriorButton.interactable == false && wheatCount >= warriorCost)
            warriorButton.interactable = true;

        UpdateText();

        if( warriorCount < 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
            RaidCountText.text = (raidCount-1).ToString();
            GameOverText.text = $"Прежито набегов: {raidCount-1}\nКрестьян уведено в плен: {peasantCount}\nВойнов убито: {totalWarriors}\nРазграблено зерна: {wheatCount}";
            
        }

        if (peasantCount == winCount)
        {
            Time.timeScale = 0;
            VictoryScreen.SetActive(true);            
            VictoryText.text = $"Деревня выжила и разраслась!\nКоличество крестьян: {peasantCount}\nВыжило войнов: {warriorCount}\nЗапасы зерна: {wheatCount}";
            
        }

    }

    public void CreatePeasant()
    {
        wheatCount -= peasantCost;
        peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;
        ClickSound.Play();
    }

    public void CreateWarrior()
    {
        wheatCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        warriorButton.interactable = false;
        ClickSound.Play();
    }

    private void UpdateText()
    {
        countText.text = wheatCount + "\n" + peasantCount + "\n\n" + warriorCount + "\n" + assassinsCount;
    }
}

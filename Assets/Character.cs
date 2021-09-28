using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public InputField characterNameInputField;
    public InputField alignmentInputField;
    public InputField maxXPInputField;
    public InputField maxHPInputField;
    public InputField currentXPInputField;
    public InputField currentHPInputField;
    public InputField armorClassInputField;
    public InputField itemListInputField;

    public InputField jsonDataInputField;

    public Text strengthText;
    public Text dexterityText;
    public Text constitutionText;
    public Text intelligenceText;
    public Text wisdomText;
    public Text charismaText;

    public Text walkingText;
    public Text runningText;
    public Text jumpText;

    public Dropdown raceDropDown;
    public Dropdown classDropDown;

    public Slider walkingSpeedSlider;
    public Slider runningSpeedSlider;
    public Slider jumpHeightSlider;

    public Button exitButton;
    public Button saveButton;

    public void Start()
    {
        armorClassInputField.onValueChanged.AddListener(delegate { GetArmorValue(); });

        walkingSpeedSlider.onValueChanged.AddListener(delegate { SliderValueChanged(walkingSpeedSlider, walkingText); });
        runningSpeedSlider.onValueChanged.AddListener(delegate { SliderValueChanged(runningSpeedSlider, runningText); });
        jumpHeightSlider.onValueChanged.AddListener(delegate { SliderValueChanged(jumpHeightSlider, jumpText); });

        exitButton.onClick.AddListener(() => ExitGame());
        saveButton.onClick.AddListener(() => SaveCharacter());


    }

    private void GetArmorValue()
    {
        int armorValue = 0;
        int.TryParse(armorClassInputField.text, out int value);
        armorValue = value;

        if (armorValue < 1 || armorValue > 100 || armorClassInputField.text == "-")
        {
            armorClassInputField.text = armorClassInputField.text.Remove(armorClassInputField.text.Length - 1, 1);
        }
    }

    private void SliderValueChanged(Slider slider, Text textLabel)
    {
        textLabel.text = slider.value.ToString();
    }

    private void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void SaveCharacter()
    {
        var character = new CharacterObject
        {
            characterName = characterNameInputField.text,
            alignment = alignmentInputField.text,
            race = raceDropDown.options[raceDropDown.value].text,
            classValue = classDropDown.options[classDropDown.value].text,
            abilityStregth = float.Parse(strengthText.text),
            abilityDexterity = float.Parse(dexterityText.text),
            abilityConstitution = float.Parse(constitutionText.text),
            abilityIntelligence = float.Parse(intelligenceText.text),
            abilityWisdom = float.Parse(wisdomText.text),
            abilityCharisma = float.Parse(charismaText.text),
            maxXP = int.Parse(maxXPInputField.text),
            maxHP = int.Parse(maxHPInputField.text),
            currentXP = int.Parse(currentXPInputField.text),
            currentHP = int.Parse(currentHPInputField.text),
            armorClass = int.Parse(armorClassInputField.text),
            walking = (int)walkingSpeedSlider.value,
            running = (int)runningSpeedSlider.value,
            jump = (int)jumpHeightSlider.value,
            itemList = new List<string>()
        };

        string jsonString = JsonUtility.ToJson(character);

        jsonDataInputField.text = jsonString;

    }
}


[System.Serializable]
public class CharacterObject
{
    public string characterName;
    public string alignment;
    public string race;
    public string classValue;

    public float abilityStregth;
    public float abilityDexterity;
    public float abilityConstitution;
    public float abilityIntelligence;
    public float abilityWisdom;
    public float abilityCharisma;

    public int maxXP;
    public int maxHP;
    public int currentXP;
    public int currentHP;
    public int armorClass;

    public int walking;
    public int running;
    public int jump;

    public List<string> itemList;
}

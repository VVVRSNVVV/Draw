using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboHandler : MonoBehaviour
{
    public static ComboHandler Instance;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text comboLabel;
    [SerializeField] private float comboDecreaseSpeed;
    [SerializeField] private float deltaCombo;
    private int maxCombo = 4;
    public float value;
    public int combo = 1;
    private void Awake()
    {
        Instance = this;
    }
    public void Add()
    {
        Add(deltaCombo);
    }
    public void Add(float dCombo)
    {
        value += dCombo;
        while(value > 1)
        {
            value--;
            combo++;
            if (combo > 4)
            {
                combo = 4;
                value = 1;
                break;
            }
        }
        UpdateVisuals();
    }
    private void UpdateVisuals()
    {
        image.fillAmount = value;
        comboLabel.text = $"x{combo}";
    }
    
    private void Update()
    {
        value -= Time.deltaTime * comboDecreaseSpeed;
        while(value < 0)
        {
            if(combo == 1)
            {
                value = 0;
                break;
            }
            combo--;
            value++;
        }
        UpdateVisuals();
    }
}

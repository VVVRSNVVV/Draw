using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBallON : MonoBehaviour
{
    [SerializeField] NewBallON newBallON;
    [SerializeField] ScoreManager _scoreManager;
   

    [SerializeField] public int startCoast;
    [SerializeField] public int coastStep;
    public int coast;
    

    private void Update()
    {
        
    }
    private void Pricing()
    {
        coast = coast * coastStep;
    }


}

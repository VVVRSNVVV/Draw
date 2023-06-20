using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStageButton : MonoBehaviour
{
    [SerializeField] Button nextStageButton;
    [SerializeField] private int sceneIndex;
    [SerializeField] ScoreManager _scoreManager;
   

    private void UpdateVisibility( )
    {
        
          nextStageButton.interactable=true;
        

    }
    private void Awake()
    {
        nextStageButton.interactable=false;
        _scoreManager.onComplited+=UpdateVisibility;
        nextStageButton.onClick.AddListener(NextStage);              
    }

    private void NextStage()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

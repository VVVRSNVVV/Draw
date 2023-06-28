using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStage : MonoBehaviour
{
    [SerializeField] Button nextStageButton;

    private void Awake()
    {
       
        nextStageButton.onClick.AddListener(NextStageED);
    }
    private void NextStageED()
    {
        SceneManager.LoadScene("Scene 1");
    }
}

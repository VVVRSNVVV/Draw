using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Privacy : MonoBehaviour
{

    private string policyKey = "policy";

    private void Start()
    {
        var accepted = PlayerPrefs.GetInt(policyKey, 0) == 1;
        if (accepted) { return; }

        SimpleGDPR.ShowDialog(new TermsOfServiceDialog().
            SetTermsOfServiceLink("https://www.rollicgames.com/terms").
            SetPrivacyPolicyLink("https://www.take2games.com/privacy/en-US"),
            onMenuClosed);
    }
    private void onMenuClosed()
    {
        Debug.LogWarning("Policy accepted");
        PlayerPrefs.SetInt(policyKey, 1);
        SceneManager.LoadScene("Education");
    }
}
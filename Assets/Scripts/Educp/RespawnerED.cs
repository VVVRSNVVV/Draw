using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RespawnerED : MonoBehaviour
{
    [SerializeField] private float showTryAgainDuration;
    [SerializeField] private GameObject tryAgain;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("ball")) return;
        StartCoroutine(Show(tryAgain, showTryAgainDuration));
        Destroy(collision.gameObject);
        foreach (var line in TutorialLine.lines.ToArray())
        {
            Destroy(line.gameObject);
        }
    }
    private IEnumerator Show(GameObject go, float duration)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(duration);
        go.SetActive(false);
    }
}

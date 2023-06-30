using TMPro;
using UnityEngine;
using DG.Tweening;
public class TextSpawner : MonoBehaviour
{
    [SerializeField] private TMP_Text labelPrefab;
    [SerializeField] private float animDuration;
    [SerializeField] private float fullDuration;
    [SerializeField] private Vector3 offset;

    public void Spawn(Vector3 position, string text)

    {
        var label = Instantiate(labelPrefab, position, Quaternion.identity);
        label.text = text;
        label.transform.DOMove(position + offset, animDuration);
        label.transform.DOScale(Vector3.one, animDuration);
        Destroy(label.gameObject, animDuration + fullDuration);
    }

}

using UnityEngine;

public class RindEDHandler : MonoBehaviour
{
    [SerializeField] private ringED[] rings;
    [SerializeField] private GameObject next;
    public void Check()
    {
        foreach (var ring in rings)
        {
            if (!ring.ready) return;
        }
        next.SetActive(true);
    }
    public void reset()
    {
        foreach (var ring in rings) { ring.reset(); }
    }
}

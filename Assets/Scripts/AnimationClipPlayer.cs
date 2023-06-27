using UnityEngine;

public class AnimationClipPlayer : MonoBehaviour
{
    public Animator animator;
    public string state;
    public float duration;
    public void Play()
    {
        gameObject.SetActive(true);
        animator.Play(state);
        Invoke("HideObject", duration);
    }
    private void HideObject()
    {
        gameObject.SetActive(false);
    }
}

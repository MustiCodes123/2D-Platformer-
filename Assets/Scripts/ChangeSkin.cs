using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController animatorController;
    [SerializeField] AnimatorOverrideController[] extraSkins;
    public UnityEngine.UI.Image img;
    public Sprite[] allSkins;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator.runtimeAnimatorController = animatorController;   
    }

    // Update is called once per frame
    void Update()
    {
        img.sprite = allSkins[index];
    }
    public void UpdateSkin()
    {
        if (index == extraSkins.Length)
        {
            animator.runtimeAnimatorController = animatorController;
            index = 0;
        }
        else
        {
            animator.runtimeAnimatorController = extraSkins[index];
            index++;
        }
    }
}

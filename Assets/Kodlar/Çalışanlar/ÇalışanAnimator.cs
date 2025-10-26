using UnityEngine;
using UnityEngine.UI;

public class ÇalışanAnimator : MonoBehaviour
{
    public Çalışan çalışan;
    public Animator animator;

    private void Awake()
    {
        çalışan = gameObject.GetComponent<Çalışan>();
        animator = gameObject.GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("ÇalışıyorMu", çalışan.ÇalışıyorMu);
    }
}

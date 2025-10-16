using UnityEngine;
using UnityEngine.UI;

public class OyunEkranıUI : MonoBehaviour
{
    public Şirket şirket;

    #region UIText
    public Text ParaText;
    public Text TecrübeText;
    public Text İtibarText;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ParaText.text = "Para: " + şirket.Para + "$";
        TecrübeText.text = "Tecrübe:" + şirket.TecrübePuanı;
        İtibarText.text = "İtibar: %" + şirket.İtibarPuanı; 
    }
}

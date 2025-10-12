using UnityEngine;
using UnityEngine.UI;

public class Şirket : MonoBehaviour
{
    [Header("Birimler")]
    public int Para;
    public int İtibar;
    public float TecrübePuanı;

    [Header("Şirket Ekonomisi")]
    public int Kira;

    #region ŞirketEkonomisi
    public void KiraÖde()
    {
        Para -= Kira;
    }
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

using UnityEngine;

public class Şirket : MonoBehaviour, IŞirketEkonomisi
{
    [Header("Birimler")]
    public int Para;
    [Range(-50f,50f)]
    public int İtibarPuanı;
    public float TecrübePuanı;

    [Header("Şirket Ekonomisi")]
    [SerializeField] private int kira;  // Inspector'da görünecek alan

    // Interface property, field üzerinden çalışıyor
    public int Kira
    {
        get => kira;
        set => kira = value;
    }

    #region ŞirketEkonomisi
    public void KiraÖde()
    {
        Para -= Kira;
        //Debug.Log($"Kira ödendi. Kalan para: {Para}");
    }
    #endregion

    void Start()
    {

    }
}
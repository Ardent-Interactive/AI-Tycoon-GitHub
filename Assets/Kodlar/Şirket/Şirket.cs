using UnityEngine;

public class Şirket : MonoBehaviour, IŞirketEkonomisi
{
    private ToplamÇalışanGücü toplamÇalışanGücü;

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

    public void MaaşlarıÖde()
    {
        foreach (var araştırmacı in toplamÇalışanGücü.araştırmacılar)
        {
            Para-= araştırmacı.MaaşBeklentisi;
        }
        foreach (var kodlamacı in toplamÇalışanGücü.kodlamacılar)
        {
            Para -= kodlamacı.MaaşBeklentisi;
        }
        foreach (var tasarımcı in toplamÇalışanGücü.tasarımcılar)
        {
            Para -= tasarımcı.MaaşBeklentisi;
        }
    }
    #endregion
    private void Awake()
    {
        toplamÇalışanGücü = FindFirstObjectByType<ToplamÇalışanGücü>();
    }
    void Start()
    {

    }
}
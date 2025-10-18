using UnityEngine;
using UnityEngine.UI;

public class Kontrat : MonoBehaviour
{
    [Header("Genel Bilgiler")]
    public string ÝþverenÝsmi;
    public int VerilenGünSüresi;
    public int KalanGünSüresi;
    [Tooltip("Zamanla ve itibarla deðiþecek.")]
    public int VerilecekPara;
    [Tooltip("Ýþin baþarýsýna göre azalacak veya artacak.")]
    public int ÝtibarPuaný;
    [Tooltip("Ýþ kontartdan ne zaman kalkacak.")]
    public int BaþvuruGeçerlilikGünü;
    public float KalanGeçerlilikGünü;
    [Tooltip("Kontrat anlaþmasý imzalandý mý.")]
    public bool AlýndýMý;
    public Sprite ÞirketLogosu;

    [Header("Detaylar")]
    [Tooltip("Ýþte ne istendiði hakkýnda kýsa bir açýklama")]
    [TextArea()]
    public string Açýklama;
    [Tooltip("Ýþveren hangi tür kaynaklara ihtiyaç duyacak. Yapay zeka hangi tür kaynaklarla eðitilmeli")]
    public enum ÝþTürü
    {
        Eðitimsel,   // Bilgi verici, öðretici, yol gösterici yarý samimi ve okulun resmi kaynaklarýndan bilgi alýnýyor.
        Samimi,      // Arkadaþça, rahat, konuþkan
        Araþtýrmacý, //Daha bilimsel kaynaklar
        Resmi //Daha kurumsal dil
    }
    public ÝþTürü iþTürü;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KalanGeçerlilikGünü <= 0 && gameObject.name != "Kontrat Listesi" && !AlýndýMý)
        {
            Destroy(gameObject);
        }
    }
}

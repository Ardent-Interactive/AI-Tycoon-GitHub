using UnityEngine;
using UnityEngine.UI;

public class Kontrat : MonoBehaviour
{
    [Header("Genel Bilgiler")]
    public string ÝþverenÝsmi;
    public int VerilenGünSüresi;
    [Tooltip("Zamanla ve itibarla deðiþecek.")]
    public int Maaþ;
    [Tooltip("Ýþin baþarýsýna göre azalacak veya artacak.")]
    public int ÝtibarPuaný;
    [Tooltip("Ýþ kontartdan ne zaman kalkacak.")]
    public int BaþvuruGeçerlilikGünü;
    [Tooltip("Kontrat anlaþmasý imzalandý mý.")]
    public bool AlýndýMý;

    [Header("Detaylar")]
    [Tooltip("Ýþte ne istendiði hakkýnda kýsa bir açýklama")]
    [TextArea()]
    public string açýklama;
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
        
    }
}

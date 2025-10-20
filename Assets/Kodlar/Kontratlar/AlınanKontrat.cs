using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AlınanKontrat : MonoBehaviour
{
    #region Kontrat Bilgileri
    [Header("Genel Bilgiler")]
    public string İşverenİsmi;
    public int VerilenGünSüresi;
    public int KalanGünSüresi;
    [Tooltip("Zamanla ve itibarla değişecek.")]
    public int VerilecekPara;
    [Tooltip("İşin başarısına göre azalacak veya artacak.")]
    public int İtibarPuanı;
    [Tooltip("İş kontartdan ne zaman kalkacak.")]
    public int BaşvuruGeçerlilikGünü;
    public float KalanGeçerlilikGünü;
    public bool AlındıMı;
    public int indeks;

    [Tooltip("İşveren hangi tür kaynaklara ihtiyaç duyacak. Yapay zeka hangi tür kaynaklarla eğitilmeli")]
    public enum İşTürü
    {
        Eğitimsel,   // Bilgi verici, öğretici, yol gösterici yarı samimi ve okulun resmi kaynaklarından bilgi alınıyor.
        Samimi,      // Arkadaşça, rahat, konuşkan
        Araştırmacı, //Daha bilimsel kaynaklar
        Resmi //Daha kurumsal dil
    }
    public İşTürü işTürü;
    #endregion

    private void Update()
    {
        if(KalanGünSüresi <= 0)
        {
            İşverenİsmi = "";
            VerilenGünSüresi = 0;
            KalanGünSüresi = 0;
            VerilecekPara = 0;
            İtibarPuanı = 0;
            BaşvuruGeçerlilikGünü = 0;
            KalanGeçerlilikGünü = 0;
            indeks = 0;
            AlındıMı = false;
            FindFirstObjectByType<GelenİşlerEkranı>().KontratPaneliniGüncelle();
        }
    }
}

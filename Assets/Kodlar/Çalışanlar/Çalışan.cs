using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Genel çalışan verisini tutacak
public class Çalışan : MonoBehaviour
{
    [Header("Diğer sınıflar")]
    public Şirket şirket;

    [Header("Genel Bilgiler")]
    public string Ad;
    public string Soyad;
    public string Uyruk;

    [Header("Çalışan Bilgileri")]
    public int MaaşBeklentisi;
    [Tooltip("Her çalışma periyodunda vereceği eğitim puanı.")]
    public float ÖğrenmePuanı;
    [Tooltip("Puan üretme veya tamir bu değişken yönetiminde olacak. Ne kadar küçükse o kadar sık.")]
    public float ÇalışmaInterval;
    [Tooltip("Çalışanın anlık olarak iş tapıp tapmadığını gösterir. Eğer iş yapıyorsa eğitim puanı kazanır.")]
    public bool ÇalışıyorMu;
    [Range(-50, 50)]
    public int Motivasyon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        StartCoroutine(ÇalışCoroutine());
        ÇalışmaInterval = FindFirstObjectByType<Tarih>().DayInSeconds - ((FindFirstObjectByType<Tarih>().DayInSeconds / 100) * Motivasyon);
        print("ÇalışamInterval 1 günlük süreye eşitlendi (motivasyon etkeniyle beraber).");
    }

    // Update is called once per frame
    public void Update()
    {
        ÇalışmaInterval = FindFirstObjectByType<Tarih>().DayInSeconds - ((FindFirstObjectByType<Tarih>().DayInSeconds / 100) * Motivasyon);
        //print(ÇalışmaInterval);
    }

    IEnumerator ÇalışCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(ÇalışmaInterval);
            Çalış();
        }
    }

    public void Çalış()
    {
        if(ÇalışıyorMu)
        şirket.TecrübePuanı += ÖğrenmePuanı;
        //print("Worked");
    }
}

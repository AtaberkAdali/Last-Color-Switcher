using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopControl : MonoBehaviour
{
    public string mevcutRenk="Pembe";
    public float ziplamaGucu = 7f;
    public Color TopunRengi;
    public Color Mavi;
    public Color Sari;
    public Color Pembe;
    public Color Mor;
    public Text scoreYazisi;
    public Text bestScoreYazisi;
    public static int score;
    public GameObject Daire;
    public GameObject renkTekeri;
    public GameObject Daire1;
    public GameObject renkTekeri1;
    public GameObject Daire2;
    public GameObject Yildiz;
    private int rastgele;
    const string BEST_S = "best_ss";
    // Start is called before the first frame update
    void Start()
    {
        RastgeleRenkBelirle();
        scoreYazisi.text = score.ToString();
        bestScoreYazisi.text = PlayerPrefs.GetInt(BEST_S).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * ziplamaGucu;
        }
        if (Input.GetKey("space"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * ziplamaGucu;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Yildiz")
        {
            rastgele = Random.Range(0, 6);
            score += 25;
            scoreYazisi.text = score.ToString();
            Destroy(collision.gameObject);
            if (score < 51)
            {
                Instantiate(Daire, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                Instantiate(renkTekeri1, new Vector3(transform.position.x, transform.position.y + 14f, transform.position.z), Quaternion.identity);
            }
            else if (score < 101)
            {
                Instantiate(Daire1, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 14f, transform.position.z), Quaternion.identity);
                Instantiate(Yildiz, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
            }
            else if (score < 126)
            {
                Instantiate(Daire2, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                Instantiate(renkTekeri1, new Vector3(transform.position.x, transform.position.y + 14f, transform.position.z), Quaternion.identity);
            }
            else
            {
                switch (rastgele)
                {
                    case 0:
                        Instantiate(Daire, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 14f, transform.position.z), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(Daire1, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        Instantiate(renkTekeri1, new Vector3(transform.position.x, transform.position.y + 14f, transform.position.z), Quaternion.identity);
                        Instantiate(Yildiz, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(Daire1, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        Instantiate(Daire, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 14f, transform.position.z), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(Daire1, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        Instantiate(renkTekeri1, new Vector3(transform.position.x, transform.position.y + 11f, transform.position.z), Quaternion.identity);
                        Instantiate(Yildiz, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(Daire2, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 14f, transform.position.z), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(Daire2, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);
                        Instantiate(renkTekeri1, new Vector3(transform.position.x, transform.position.y + 10.5f, transform.position.z), Quaternion.identity);
                        break;
                }
               
            }
            
        }
        if(collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            return;//alttaki koda bakmadan çıkmasını sağlıyor. Performans için.
        }
        if(collision.tag != mevcutRenk && collision.tag !="Yildiz")
        {
            if(score > PlayerPrefs.GetInt(BEST_S))
            {
                PlayerPrefs.SetInt(BEST_S, score);
                bestScoreYazisi.text = PlayerPrefs.GetInt(BEST_S).ToString();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
            scoreYazisi.text = score.ToString();
            Debug.Log("Kaybettin");
        }
    }
    void RastgeleRenkBelirle()
    {
        int rastgeleSayi = Random.Range(0, 4);
        switch (rastgeleSayi)
        {
            case 0: mevcutRenk = "Mavi";
                TopunRengi = Mavi;
                break;
            case 1:
                mevcutRenk = "Sari";
                TopunRengi = Sari;
                break;
            case 2:
                mevcutRenk = "Pembe";
                TopunRengi = Pembe;
                break;
            case 3:
                mevcutRenk = "Mor";
                TopunRengi = Mor;
                break;
        }
        GetComponent<SpriteRenderer>().color = TopunRengi;
    }
}

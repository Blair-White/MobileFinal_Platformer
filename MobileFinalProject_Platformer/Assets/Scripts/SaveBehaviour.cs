using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveBehaviour : MonoBehaviour
{
    public static SaveBehaviour instance = null;
    public bool isLoading;
    // Start is called before the first frame update
    public float[] SavedPosition;
    public int SavedScore;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
       

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLoading()
    {
        isLoading = true;
    }
    public void SaveAll(float x, float y, float z, float rot, int score)
    {
        if(PlayerPrefs.GetInt("HasSave") == 0)
        {
            PlayerPrefs.SetInt("HasSave", 1);
        }
        SaveScore(score);
        SaveCheckpoint(x, y, z, rot);
    }
  
    void SaveScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void LoadAll()
    {
        LoadScore();
        LoadCheckpoint();
    }
    void LoadScore()
    {
        GameObject s = GameObject.Find("ScoreValue");
        s.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score").ToString();
    }
    void SaveCheckpoint(float x, float y, float z, float rot)
    {
        PlayerPrefs.SetFloat("posX", x);
        PlayerPrefs.SetFloat("posY", y);
        PlayerPrefs.SetFloat("posZ", z);
        PlayerPrefs.SetFloat("Rot", rot);
    }

    void LoadCheckpoint()
    {
        GameObject p = GameObject.Find("Player");
        Vector3 pos;
        float rot = PlayerPrefs.GetFloat("Rot");
        pos.x = PlayerPrefs.GetFloat("posX");
        pos.y = PlayerPrefs.GetFloat("posY");
        pos.z = PlayerPrefs.GetFloat("posZ");
        p.transform.eulerAngles = new Vector3(0, rot, 0) ;
        p.transform.position = pos;

    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker Instance { get; private set; }
    public int previousScore = 0;
    private int currentScore = 0;
    private TMP_Text highScoreField;

    void Awake()
    {
        // We want to make this persistent in order to keep track of the score. 
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded; // here we are starting an event
    }

    //We want to call the update score tracker so that when we return to the main menu it is an updated number...
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateScoreTracker(previousScore);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // stopping the tracking of that event
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreTracker(int score)
    {
        highScoreField = GameObject.FindWithTag("HighScoreText").GetComponent<TMP_Text>();
        currentScore = score;
        highScoreField.text = "High Score: " + previousScore;
        if (previousScore <  currentScore)
        {
            previousScore = currentScore;
            print("New high score: " + previousScore);
            highScoreField.text = "High Score: " + previousScore;
        }
    }

}

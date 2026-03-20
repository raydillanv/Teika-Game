using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker Instance { get; private set; }
    public int previousScore = 0;
    private int currentScore = 0;

    //Adding tracking of high score across sessions as long as you dont clear cache on browser
    private const string HIGH_SCORE_KEY = "HighScore";

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

        // Load the cache
        previousScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);

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

            // save the new high score
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, previousScore);
            PlayerPrefs.Save(); // saving to the browser cache
        }
    }

}

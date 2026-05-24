using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public static AudioManager instance { get; private set; }
    [SerializeField] private AudioClip starcollect;
    [SerializeField] private AudioClip fireball;
    [SerializeField] private AudioClip gameoverclip;
    [SerializeField] private AudioClip winlevelclip;
    [SerializeField] private AudioClip jumpclip;
    [SerializeField] private AudioClip runclip;
    [SerializeField] private AudioClip backgroundMusic;

    private AudioSource oneShotSource;
    private AudioSource loopSource;
    private AudioSource musicSource;

    private void Awake()
    {
        

        oneShotSource=gameObject.AddComponent<AudioSource>();
        loopSource=gameObject.AddComponent<AudioSource>();

        loopSource.loop = true;
        loopSource.playOnAwake = false;

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;



        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
    }
    void Start()
    {
        
    }
    public void PlaystarCollect() => oneShotSource.PlayOneShot(starcollect);
    public void PlayFireWoosh() => oneShotSource.PlayOneShot(fireball);  

    public void PlayGameOver () => oneShotSource.PlayOneShot(gameoverclip);

    public void PlayWinLevel() => oneShotSource.PlayOneShot(winlevelclip);

    public void PlayJump() => oneShotSource.PlayOneShot(jumpclip);

    public void StartRun()
    {
        if (loopSource.isPlaying) return;
        loopSource.clip = runclip;
        loopSource.Play();
    }

    public void StopRun()
    {
        if (loopSource.isPlaying)
            loopSource.Stop();
    }


    void Update()
    {
        
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource.clip == backgroundMusic && musicSource.isPlaying)
            return;

        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

}

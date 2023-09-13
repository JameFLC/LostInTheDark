using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Banks")]
    [SerializeField] AK.Wwise.Bank amb_bleeding_swamps = null;
    [SerializeField] AK.Wwise.Bank amb_gate = null;
    [SerializeField] AK.Wwise.Bank amb_howling_swamps = null;
    [SerializeField] AK.Wwise.Bank amb_maldirach_swamps = null;
    [SerializeField] AK.Wwise.Bank amb_moon_shadow = null;
    [SerializeField] AK.Wwise.Bank amb_serpent_vigne = null;
    [SerializeField] AK.Wwise.Bank SB_carnivist_choir = null;
    [SerializeField] AK.Wwise.Bank SB_howling_swamps = null;
    [SerializeField] AK.Wwise.Bank SB_reine_gouillante = null;
    [SerializeField] AK.Wwise.Bank UI = null;


    [Header("Events")]
    [SerializeField] AK.Wwise.Event _Music = null;
    [SerializeField] AK.Wwise.Event Play_amb_bleeding_swamps = null;
    [SerializeField] AK.Wwise.Event Play_amb_gate = null;
    [SerializeField] AK.Wwise.Event Play_amb_maldirach = null;
    [SerializeField] AK.Wwise.Event Play_amb_moon_shadow = null;
    [SerializeField] AK.Wwise.Event Play_amb_spawn = null;
    [SerializeField] AK.Wwise.Event Play_howling_swamps = null;
    [SerializeField] AK.Wwise.Event Play_serpent_vigne = null;
    [SerializeField] AK.Wwise.Event Play_sound_bites_howling_swamps = null;
    [SerializeField] AK.Wwise.Event Play_sound_bites_reine_gouillante = null;
    [SerializeField] AK.Wwise.Event Play_ui_death_generic = null;
    [SerializeField] AK.Wwise.Event Play_ui_death_reine_gouillante = null;
    [SerializeField] AK.Wwise.Event _stopAll = null;

    private static AudioManager instance;
    public static AudioManager Instance => instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(Instance.gameObject);
        instance = this;

        DontDestroyOnLoad(this.gameObject);

        //loading Banks
        amb_bleeding_swamps.Load();
        amb_gate.Load();
        amb_howling_swamps.Load();
        amb_maldirach_swamps.Load();
        amb_moon_shadow.Load();
        amb_serpent_vigne.Load();
        SB_carnivist_choir.Load();
        SB_howling_swamps.Load();
        SB_reine_gouillante.Load();
        UI.Load();
        

    }

    private void Start()
    {
        UIDeathGeneric();
    }

    // Musics
    public void MusicEvent(bool play)
    {
        if (play)
        {
            _Music.Post(gameObject);
        }
        else
        {
            _Music.Stop(gameObject, 200);
        }

    }

    // Ambs
    public void AmbianceBleedingSwamps()
    {
        Play_amb_bleeding_swamps.Post(gameObject);

    }

    public void AmbianceGate()
    {
        Play_amb_gate.Post(gameObject);

    }

    public void AmbianceMaldirach()
    {
        Play_amb_maldirach.Post(gameObject);

    }

    public void AmbianceMoonShadow()
    {
        Play_amb_moon_shadow.Post(gameObject);

    }

    public void AmbianceSpawn()
    {
        Play_amb_spawn.Post(gameObject);

    }

    public void AmbianceHowlingSwamps()
    {
        Play_howling_swamps.Post(gameObject);

    }

    public void AmbianceSerpentVigne()
    {
        Play_serpent_vigne.Post(gameObject);

    }

    //Sound Bites 
    public void SBHowlingSwamps()
    {
        Play_sound_bites_howling_swamps.Post(gameObject);

    }

    public void SBReineGrouillante()
    {
        Play_sound_bites_reine_gouillante.Post(gameObject);

    }

    //UI
    public void UIDeathGeneric()
    {
        Play_ui_death_generic.Post(gameObject);

    }

    public void UIDeathReineGrouillante()
    {
        Play_ui_death_reine_gouillante.Post(gameObject);

    }
    //utility
    public void StopAll()
    {

        _stopAll.Post(gameObject);
    }
}

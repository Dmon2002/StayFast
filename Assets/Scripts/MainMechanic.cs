using System.Collections;
using System.Collections.Generic;
using StayFast;
using UnityEngine;
using UnityEngine.UI;

public class MainMechanic : MonoBehaviour
{

    [SerializeField]
    private GameObject Puls;

    [SerializeField]
    private Vector2 Min;
    [SerializeField]
    private Vector2 Max;

    [SerializeField]
    private static Slider slider;
    [SerializeField]
    private float AdrenalinSpeed;
    [SerializeField]
    private float AdrenalinSpeedPlus;
    [SerializeField]
    private float AdrenalinSpeedMinus;
    [SerializeField]
    private bool IsTouched=false;
    // Start is called before the first frame update

    [SerializeField]
    private Color colorActive;
    [SerializeField]
    private Color colorPassive;
    private SpriteRenderer SR;

    private static Animator anim;

   
    private static bool IsActive=false;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.enabled = false;
        SR = gameObject.GetComponent<SpriteRenderer>();
        SR.color = colorPassive;
        StartCoroutine(Timer());
        PulsReLocate();
        IsActive = true;//удалить
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
    }

    private void PulsReLocate()
    {
        Puls.transform.localPosition = new Vector3(transform.localPosition.x, Random.Range(Min.y, Max.y), transform.localPosition.z);
        print("Relocate");
        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.1f);
        
        slider.value = slider.value + AdrenalinSpeed/10f;
        if (slider.value == slider.maxValue)
        {
            BadEndStart();
        }
        if (IsActive)
        {
            StartCoroutine(Timer());
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && IsActive)
        {
            if (IsTouched)
            {
                Sounding.PlayAudio(ClipType.TapeLose);
                PulsReLocate();
                slider.value = slider.value - AdrenalinSpeedMinus;
            }
            
            else
            {

                Sounding.PlayAudio(ClipType.TapeWin);
                Sounding.PlayAudio(ClipType.TapeWinTwo);

                slider.value = slider.value + AdrenalinSpeedPlus;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Puls")
        {
            SR.color = colorActive;
            IsTouched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Puls")
        {
            SR.color = colorPassive;
            IsTouched = false;
        }
    }

    public static void BadEndStart()
    {
        
    }

    public static void AnimationStop()
    {
        IsActive =false;
        anim.enabled = false;
    }
    public static void AnimationGO()
    {
        IsActive = true;
        anim.enabled = true;
    }
    public static void NewDay()
    {
        slider.value = 0;
        anim.enabled = true;
    }
}

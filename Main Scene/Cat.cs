using System;
using System.Collections;
using UnityEngine;


public class Cat : MonoBehaviour
{
    Animator mainanAnimator;
    CatBehaviour pet;
    UIControl uiControl;
    Animator animator;
    LoadData loadData;
    CheckData checkData;

    int totaldays;

    const int hungerDelay = 12;
    const int happinessDelay = 2;
    const int healthDelay = 20;
    const int cleanlinessDelay = 15;
    const int peeDelay = 1;
    const int poopDelay = 6;
    const int thristyDelay = 5;

    public bool isPlaying;

    DateTime newBreakfastParameterTimer;
    DateTime newPoopParameterTimer;
    DateTime newPeeParameterTimer;
    DateTime newLunchParameterTimer;
    DateTime newThristyParameterTimer;
    DateTime newDinnerParameterTimer;
    DateTime newHealthParameterTimer,
        newHappinessParameterTimer,
        newCleanlinessParameterTimer;

    public enum State
    {
        isBreakfast,
        isPee1,
        isPoop,
        isLicking,
        isPlayInMorning,
        isPlayInNight,
        isLunch,
        isPee2,
        isThristy,
        isObserving,
        isDinner,
        isSleep,
        isGoOut,
        isSick,
        isDied

    }

    public State state;

    void Awake()
    {
        pet = FindObjectOfType<CatBehaviour>();
        uiControl = FindObjectOfType<UIControl>();
        animator = GetComponent<Animator>();
        mainanAnimator = GetComponent<Animator>();
        loadData = FindObjectOfType<LoadData>();
        checkData = FindObjectOfType<CheckData>();

        isPlaying = false;

        StartCoroutine(SleepAnimation());
        StartCoroutine(PlayAnimation());
    }

    void Update()
    {
        loadData.date = DateTime.Today;

        if (!loadData.isDied && !loadData.isSick)
        {
            loadData.time = DateTime.Now;

            if (DateTime.Today > loadData.date)
            {
                Debug.Log("tanggal hari ini" + DateTime.Today);
                Debug.Log("tanggal tersimpan" + loadData.date);
                Debug.Log("Ganti Hari dech");
                loadData.age += 1;
                loadData.date = DateTime.Today;
                checkData.ResetStatus();

            }

            switch (loadData.time.Hour)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    SetState(State.isSleep);
                    break;

                case 6:
                    if (loadData.time.Minute == loadData.peeMinute1 && !loadData.alreadyPee1)
                    {
                        SetState(State.isPee1);
                    }
                    else if (loadData.time.Minute == loadData.poopMinute && !loadData.alreadyPoop)
                    {
                        SetState(State.isPoop);
                    }
                    else if (!loadData.breakfast)
                    {
                        SetState(State.isBreakfast);
                    }
                    else if (loadData.breakfast)
                    {
                        SetState(State.isLicking);
                    }
                    else if (loadData.time.Minute > 30 && !loadData.breakfast)
                    {
                        loadData.breakfast = true;
                    }
                    break;

                case 7:
                    SetState(State.isPlayInMorning);
                    break;

                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    mainanAnimator.SetInteger("mainan", 4);
                    SetState(State.isSleep);
                    break;

                case 14:
                    if (loadData.time.Minute == loadData.thristyMinute && !loadData.giveWater)
                    {
                        SetState(State.isThristy);
                    }
                    else if (!loadData.lunch)
                    {
                        SetState(State.isLunch);
                    }

                    else if (loadData.lunch)
                    {
                        SetState(State.isLicking);

                        Debug.Log("mandi dulu yaa");
                    }
                    else if (loadData.time.Minute > 30 && !loadData.lunch)
                    {
                        loadData.breakfast = true;
                        SetState(State.isLicking);
                    }

                    break;

                case 15:
                case 16:
                case 17:
                case 18:
                    SetState(State.isSleep);
                    break;

                case 19:
                    if (loadData.time.Minute == loadData.peeMinute1)
                    {
                        if (!loadData.alreadyPee2)
                        {
                            SetState(State.isPee2);
                        }
                    }
                    else if (state != State.isPee2)
                    {
                        SetState(State.isPlayInNight);
                    }

                    break;

                case 20:
                    SetState(State.isPlayInNight);
                    break;

                case 21:
                    if (!loadData.dinner)
                    {
                        SetState(State.isDinner);
                    }
                    else if (loadData.dinner)
                    {
                        SetState(State.isLicking);
                    }
                    break;

                case 22:
                case 23:
                    SetState(State.isObserving);
                    break;

            }

            if (loadData.peeOutStatus || loadData.poopOutStatus || loadData.isDirty)
            {
                Debug.Log("cleanlinessParameterTimer = " + loadData.cleanlinessParameterTimer);
                newCleanlinessParameterTimer = DateTime.Now;
                TimeSpan cleanlinessTimerSpan = newCleanlinessParameterTimer - loadData.cleanlinessParameterTimer;
                if (cleanlinessTimerSpan.TotalMinutes >= cleanlinessDelay)
                {
                    loadData.cleanliness -= (int)cleanlinessTimerSpan.TotalMinutes / cleanlinessDelay;
                    loadData.cleanlinessParameterTimer = newCleanlinessParameterTimer;
                }
            }
        }
        else if (loadData.isSick)
        {
            SetState(State.isSick);
        }
        else
        {
            SetState(State.isDied);
        }
    }

    public void SetState(State newState)
    {
        state = newState;

        switch (state)
        {
            case State.isBreakfast:
                this.transform.position = new Vector3(-2f, -3f, 1.5f);
                newBreakfastParameterTimer = DateTime.Now;

                TimeSpan breakfastTimerSpan = newBreakfastParameterTimer - loadData.breakfastParameterTimer;
                if (breakfastTimerSpan.TotalSeconds >= hungerDelay)
                {
                    loadData.breakfastLevel -= (int)breakfastTimerSpan.TotalSeconds / hungerDelay;
                    loadData.breakfastParameterTimer = newBreakfastParameterTimer;
                    Debug.Log("hunger = " + (int)breakfastTimerSpan.TotalSeconds);
                }

                pet.BreakfastBehavior();
                break;

            case State.isLunch:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                newLunchParameterTimer = DateTime.Now;

                TimeSpan lunchTimerSpan = newLunchParameterTimer - loadData.lunchParameterTimer;
                if (lunchTimerSpan.TotalSeconds >= hungerDelay)
                {
                    loadData.lunchLevel -= (int)lunchTimerSpan.TotalSeconds / hungerDelay;
                    loadData.lunchParameterTimer = newLunchParameterTimer;
                    Debug.Log("hunger = " + (int)lunchTimerSpan.TotalSeconds / hungerDelay);
                }

                pet.LunchBehavior();
                break;

            case State.isDinner:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                newDinnerParameterTimer = DateTime.Now;
                mainanAnimator.SetInteger("mainan", 4);
                TimeSpan dinnerTimerSpan = newDinnerParameterTimer - loadData.dinnerParameterTimer;
                if (dinnerTimerSpan.TotalSeconds >= hungerDelay)
                {
                    loadData.dinnerLevel -= (int)dinnerTimerSpan.TotalSeconds / hungerDelay;
                    loadData.dinnerParameterTimer = newDinnerParameterTimer;
                    Debug.Log("hunger = " + (int)dinnerTimerSpan.TotalSeconds);
                }

                pet.DinnerBehavior();
                break;

            case State.isPlayInMorning:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                pet.HappinessInMorning();

                if (loadData.playingWithToy)
                {
                    loadData.happinessInMorningLevel = 100;
                    uiControl.mainan.SetActive(true);
                }
                else
                {
                    newHappinessParameterTimer = DateTime.Now;
                    TimeSpan playTimerSpan = newHappinessParameterTimer - loadData.happinessInMorningParameterTimer;
                    if (playTimerSpan.TotalMinutes >= happinessDelay)
                    {
                        loadData.happinessInMorningLevel -= (int)playTimerSpan.TotalMinutes / happinessDelay;
                        loadData.happinessInMorningParameterTimer = newHappinessParameterTimer;
                        Debug.Log("happiness = " + (int)playTimerSpan.TotalSeconds);
                    }
                    Debug.Log("happiness = " + loadData.happinessInMorningLevel);
                }
                break;

            case State.isPlayInNight:
                this.transform.position = new Vector3(-2f, -3f, 1.5f);
                pet.HappinessInNight();

                if (loadData.playingWithToy)
                {
                    loadData.happinessInNightLevel = 100;
                    uiControl.mainan.SetActive(true);
                    if(!isPlaying)
                    {
                        StartCoroutine(PlayAnimation());
                        isPlaying = true;
                    }
                }
                else
                {
                    newHappinessParameterTimer = DateTime.Now;
                    TimeSpan playTimerSpan = newHappinessParameterTimer - loadData.happinessInNightParameterTimer;
                    if (playTimerSpan.TotalMinutes >= happinessDelay)
                    {
                        loadData.happinessInNightLevel -= (int)playTimerSpan.TotalMinutes / happinessDelay;
                        loadData.happinessInNightParameterTimer = newHappinessParameterTimer;
                        Debug.Log("happiness = " + (int)playTimerSpan.TotalSeconds);
                    }
                    Debug.Log("happiness = " + loadData.happinessInNightLevel);
                }
                break;

            case State.isLicking:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                pet.Licking();
                break;

            case State.isObserving:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                pet.Observing();
                break;

            case State.isPee1:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                newPeeParameterTimer = DateTime.Now;
                TimeSpan peeTimerSpan = newPeeParameterTimer - loadData.pee1ParameterTimer;
                if (peeTimerSpan.TotalSeconds >= peeDelay)
                {
                    loadData.pee1Level -= (int)peeTimerSpan.TotalSeconds / peeDelay;
                    loadData.pee1ParameterTimer = newPeeParameterTimer;
                }
                break;

            case State.isPee2:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                newPeeParameterTimer = DateTime.Now;
                TimeSpan pee2TimerSpan = newPeeParameterTimer - loadData.pee2ParameterTimer;
                if (pee2TimerSpan.TotalSeconds >= peeDelay)
                {
                    loadData.pee2Level -= (int)pee2TimerSpan.TotalSeconds / peeDelay;
                    loadData.pee2ParameterTimer = newPeeParameterTimer;
                }
                break;

            case State.isPoop:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                newPoopParameterTimer = DateTime.Now;
                TimeSpan poopTimerSpan = newPoopParameterTimer - loadData.poopParameterTimer;
                if (poopTimerSpan.TotalSeconds >= poopDelay)
                {
                    loadData.poopLevel -= (int)poopTimerSpan.TotalSeconds / poopDelay;
                    loadData.poopParameterTimer = newPoopParameterTimer;
                }
                break;

            case State.isSleep:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                pet.Sleeping();
                break;

            case State.isThristy:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                newThristyParameterTimer = DateTime.Now;
                TimeSpan thristyTimerSpan = newThristyParameterTimer - loadData.thristyParameterTimer;
                if (thristyTimerSpan.TotalSeconds >= thristyDelay)
                {
                    loadData.thristyLevel -= (int)thristyTimerSpan.TotalSeconds / thristyDelay;
                    loadData.thristyParameterTimer = newThristyParameterTimer;
                }
                pet.Drink();
                break;

            case State.isGoOut:
                transform.position = new Vector3(40, -20, -10);
                break;

            case State.isSick:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                newHealthParameterTimer = DateTime.Now;
            TimeSpan healthTimerSpan = newHealthParameterTimer - loadData.healthParameterTimer;
            if (healthTimerSpan.TotalMinutes >= healthDelay)
            {
                loadData.health -= (int)healthTimerSpan.TotalMinutes / healthDelay;
                loadData.healthParameterTimer = newHealthParameterTimer;
            }
            pet.Sick();
                break;

            case State.isDied:
                transform.position = new Vector3(-2f, -3f, 1.5f);
                pet.Died();
                break;

        }
    }

    

    IEnumerator SleepAnimation()
    {
        yield return new WaitForSeconds(30.0f);
        while (state == State.isSleep)
        {
            yield return new WaitForSeconds(30.0f);
            int rnd = UnityEngine.Random.Range(0, 4);
            animator.SetInteger("isSleep", rnd);
            yield return null;
        }
        yield return null;

    }

    IEnumerator PlayAnimation()
    {
        while (loadData.playingWithToy)
        {
            mainanAnimator = GameObject.FindGameObjectWithTag("mainan").GetComponent<Animator>();
            int rnd = UnityEngine.Random.Range(1, 3);
            Debug.Log(rnd);
            animator.SetInteger("Playing", rnd);
            mainanAnimator.SetInteger("mainan", rnd);

            yield return new WaitForSeconds(30.0f);
        }
        yield return null;
    }

    private void OnMouseDown()
    {
        if (state == State.isSleep)
        {
            uiControl.AwakeButton();
        }
    }
}

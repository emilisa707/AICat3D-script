using System;
using UnityEngine;

public abstract class SetStatePet : Cat
{
    protected override void SetState(State newState)
    {
        state = newState;

        switch (newState)
        {
            case State.isBreakfast:
                newBreakfastParameterTimer = DateTime.Now;

                TimeSpan breakfastTimerSpan = newBreakfastParameterTimer - loadData.breakfastParameterTimer;
                if (breakfastTimerSpan.TotalSeconds >= hungerDelay)
                {
                    OnState.Invoke();
                    loadData.breakfastLevel -= (int)breakfastTimerSpan.TotalSeconds / hungerDelay;
                    loadData.breakfastParameterTimer = newBreakfastParameterTimer;
                    Debug.Log("hunger = " + (int)breakfastTimerSpan.TotalSeconds);
                }

                BreakfastBehavior();
                break;

            case State.isLunch:
                newLunchParameterTimer = DateTime.Now;

                TimeSpan lunchTimerSpan = newLunchParameterTimer - loadData.lunchParameterTimer;
                if (lunchTimerSpan.TotalSeconds >= hungerDelay)
                {
                    OnState.Invoke();
                    loadData.lunchLevel -= (int)lunchTimerSpan.TotalSeconds / hungerDelay;
                    loadData.lunchParameterTimer = newLunchParameterTimer;
                    Debug.Log("hunger = " + (int)lunchTimerSpan.TotalSeconds / hungerDelay);
                }

                LunchBehavior();
                break;

            case State.isDinner:
                newDinnerParameterTimer = DateTime.Now;
                TimeSpan dinnerTimerSpan = newDinnerParameterTimer - loadData.dinnerParameterTimer;
                if (dinnerTimerSpan.TotalSeconds >= hungerDelay)
                {
                    OnState.Invoke();
                    loadData.dinnerLevel -= (int)dinnerTimerSpan.TotalSeconds / hungerDelay;
                    loadData.dinnerParameterTimer = newDinnerParameterTimer;
                    Debug.Log("hunger = " + (int)dinnerTimerSpan.TotalSeconds);
                }

                DinnerBehavior();
                break;

            case State.isPlayInMorning:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                if (loadData.playingWithToy)
                {
                    loadData.happinessInMorningLevel = 100;
                    uiControl.mainan.SetActive(true);
                    Debug.Log("jadila pulo bug tu woi ");
                    if (!isPlaying)
                    {
                        PlayAnimation();
                        isPlaying = true;
                        timer.Duration = 5;
                        timer.Run();
                        startTime = Time.time;
                        Debug.Log("Mulai timer");
                    }
                    if (timer.Finished)
                    {
                        PlayAnimation();
                        timer.Duration = 5;
                        timer.Run();
                        Debug.Log("Selesai timer");
                    }
                }
                else
                {
                    HappinessInMorning();
                    newHappinessParameterTimer = DateTime.Now;
                    TimeSpan playTimerSpan = newHappinessParameterTimer - loadData.happinessInMorningParameterTimer;
                    if (playTimerSpan.TotalMinutes >= happinessDelay)
                    {
                        OnState.Invoke();
                        loadData.happinessInMorningLevel -= (int)playTimerSpan.TotalMinutes / happinessDelay;
                        loadData.happinessInMorningParameterTimer = newHappinessParameterTimer;
                        Debug.Log("happiness = " + (int)playTimerSpan.TotalSeconds);
                    }
                    Debug.Log("happiness = " + loadData.happinessInMorningLevel);
                }
                break;

            case State.isPlayInNight:
                //this.transform.position = new Vector3(-2f, -3f, 1.5f);
                

                if (loadData.playingWithToy)
                {
                    Debug.Log("apalah ini");

                    loadData.happinessInNightLevel = 100;
                    uiControl.mainan.SetActive(true);
                    if (!isPlaying)
                    {
                        isPlaying = true;
                        PlayAnimation();
                        timer.Duration = 5;
                        timer.Run();
                        startTime = Time.time;
                    }

                    if (timer.Finished)
                    {
                        PlayAnimation();
                        timer.Duration = 5;
                        timer.Run();
                    }
                }
                else if (!loadData.playingWithToy)
                {
                    if (!loadData.playingWithPlayerInMorning || !loadData.playingWithPlayerInNight)
                    {
                        HappinessInNight();
                        newHappinessParameterTimer = DateTime.Now;
                        TimeSpan playTimerSpan = newHappinessParameterTimer - loadData.happinessInNightParameterTimer;
                        if (playTimerSpan.TotalMinutes >= happinessDelay)
                        {
                            OnState.Invoke();
                            loadData.happinessInNightLevel -= (int)playTimerSpan.TotalMinutes / happinessDelay;
                            loadData.happinessInNightParameterTimer = newHappinessParameterTimer;
                            Debug.Log("happiness = " + (int)playTimerSpan.TotalSeconds);
                        }
                    }
                }
                break;

            case State.isLicking:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                Licking();
                break;

            case State.isObserving:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                Observing();
                break;

            case State.isPee1:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                Pee();
                newPeeParameterTimer = DateTime.Now;
                TimeSpan peeTimerSpan = newPeeParameterTimer - loadData.pee1ParameterTimer;
                if (peeTimerSpan.TotalSeconds >= peeDelay)
                {
                    OnState.Invoke();
                    loadData.pee1Level -= (int)peeTimerSpan.TotalSeconds / peeDelay;
                    loadData.pee1ParameterTimer = newPeeParameterTimer;
                }
                break;

            case State.isPee2:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                Pee();
                newPeeParameterTimer = DateTime.Now;
                TimeSpan pee2TimerSpan = newPeeParameterTimer - loadData.pee2ParameterTimer;
                if (pee2TimerSpan.TotalSeconds >= peeDelay)
                {
                    OnState.Invoke();
                    loadData.pee2Level -= (int)pee2TimerSpan.TotalSeconds / peeDelay;
                    loadData.pee2ParameterTimer = newPeeParameterTimer;
                }
                break;

            case State.isPoop:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                Poop();
                newPoopParameterTimer = DateTime.Now;
                TimeSpan poopTimerSpan = newPoopParameterTimer - loadData.poopParameterTimer;
                if (poopTimerSpan.TotalSeconds >= poopDelay)
                {
                    OnState.Invoke();
                    loadData.poopLevel -= (int)poopTimerSpan.TotalSeconds / poopDelay;
                    loadData.poopParameterTimer = newPoopParameterTimer;
                    Debug.Log("Poop = " + (int)poopTimerSpan.TotalSeconds);
                }
                Debug.Log("pop = " + loadData.poopLevel);
                break;

            case State.isSleep:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                uiControl.mainan.SetActive(false);
                if (!isSleep)
                {
                    Sleeping();
                    isSleep = true;
                    timer.Duration = 60;
                    timer.Run();
                    startTime = Time.time;
                }

                if (timer.Finished)
                {
                    Sleeping();
                    timer.Duration = 60;
                    timer.Run();
                }

                break;

            case State.isThristy:
                newThristyParameterTimer = DateTime.Now;
                TimeSpan thristyTimerSpan = newThristyParameterTimer - loadData.thristyParameterTimer;
                if (thristyTimerSpan.TotalSeconds >= thristyDelay)
                {
                    OnState.Invoke();
                    loadData.thristyLevel -= (int)thristyTimerSpan.TotalSeconds / thristyDelay;
                    loadData.thristyParameterTimer = newThristyParameterTimer;
                }
                Drink();
                break;

            case State.isGoOut:
                transform.position = new Vector3(40, -20, -10);
                break;

            case State.isSick:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                newHealthParameterTimer = DateTime.Now;
                TimeSpan healthTimerSpan = newHealthParameterTimer - loadData.healthParameterTimer;
                if (healthTimerSpan.TotalMinutes >= healthDelay)
                {
                    loadData.health -= (int)healthTimerSpan.TotalMinutes / healthDelay;
                    loadData.healthParameterTimer = newHealthParameterTimer;
                }
                Sick();
                break;

            case State.isDied:
                //transform.position = new Vector3(-2f, -3f, 1.5f);
                Died();
                break;
        }
    }

    void PlayAnimation()
    {
        mainanAnimator = GameObject.FindGameObjectWithTag("mainan").GetComponent<Animator>();
        int rnd = UnityEngine.Random.Range(1, 3);
        Debug.Log(rnd);
        animator.SetInteger("Playing", rnd);
        animator.SetInteger("isSleep", 10);
        mainanAnimator.SetInteger("mainan", rnd);
    }

    protected abstract void BreakfastBehavior();
    protected abstract void LunchBehavior();
    protected abstract void DinnerBehavior();
    protected abstract void HappinessInMorning();
    protected abstract void HappinessInNight();
    protected abstract void Pee();
    protected abstract void Poop();
    protected abstract void Licking();
    protected abstract void Observing();
    protected abstract void Sleeping();
    protected abstract void Drink();
    protected abstract void Sick();
    protected abstract void Died();
}


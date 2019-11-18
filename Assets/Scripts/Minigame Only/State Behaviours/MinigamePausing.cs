﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePausing : PauseBehaviour
{
    [SerializeField] private GameObject _pauseCanvas = null;
    [SerializeField] private TransitionData _mainMenuEnterTransition = null;
    [SerializeField] private Transform _mainMenuTransform = null;
    [SerializeField] private Transform _settingsTransform = null;
    private bool _paused = false;

    protected override void Start() {
        base.Start();
        _pauseCanvas.SetActive(false);
    }

    protected override void OnStateEnter() {
        _paused = true;
        _pauseCanvas.SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (_paused) {
                ReturnToGame();
            } else {
                GameStateManager.INSTANCE.TriggerStateChange(GameState.INPAUSE);
            }
        }
    }

    public void Pause() {
        if (!_paused) GameStateManager.INSTANCE.TriggerStateChange(GameState.INPAUSE);
    }

    protected override void OnStateExit() {
        _pauseCanvas.SetActive(false);
        _paused = false;
    }

    public void ExitRun() {
        PersistentDataManager.RUN.ExitEarly();
    }

    public void ReturnToGame() {
        GameStateManager.INSTANCE.TriggerStateChange(GameState.INGAME);
    }

    public void OpenSettings() {
        _settingsTransform.gameObject.SetActive(true);
        StartCoroutine(_mainMenuEnterTransition.StartTransitionScale(_mainMenuTransform.GetComponent<RectTransform>(), false, complete => {}));
        StartCoroutine(_mainMenuEnterTransition.StartTransitionScale(_settingsTransform.GetComponent<RectTransform>(), true, complete => {}));
    }
    
}

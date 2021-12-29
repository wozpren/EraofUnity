using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameState
{
    Loading, Title, Hall, Battle, UI
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private List<BaseManager> managerPool = new List<BaseManager>();


    [SerializeField]
    private GameState gameState;
    public GameState GameState
    {
        get => gameState;
        set
        {
            gameState = value;
            GameStateChanged(gameState);
        }
    }

    public event Action<GameState> GameStateChanged;
    public event Action UpdateEvent;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        GameInit();
        InitEvent();
        InitManager();
    }

    private void GameInit()
    {
        GameStateChanged += GameManager_GameStateChanged;
    }

    private void InitEvent()
    {


    }

    private void InitManager()
    {
        managerPool.Add(UIManager.Instance);
        foreach (var manager in managerPool)
        {
            manager.Init();
        }
    }


    private void Start()
    {
        foreach (var manager in managerPool)
        {
            manager.Start();
        }

        GameState = GameState.Title;
    }

    private void Update()
    {
        foreach (var manager in managerPool)
        {
            manager.Update();
        }
        UpdateEvent?.Invoke();
    }

    private void LateUpdate()
    {
        foreach (var manager in managerPool)
        {
            manager.LateUpdate();
        }
    }

    private void FixedUpdate()
    {
        foreach (var manager in managerPool)
        {
            manager.FixedUpdate();
        }
    }

    private void GameManager_GameStateChanged(GameState state)
    {
        switch (state)
        {
        }
    }



#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        if (SceneManager.GetActiveScene().name == "Awake")
        {
            return;
        }
        SceneManager.LoadScene(0);
    }
#endif
}

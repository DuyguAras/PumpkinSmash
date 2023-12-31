using Core.Games.GameName.EventBus;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance;
    public static GameStateManager Instance => instance;

    public GameState currentGameState = GameState.Prepare;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;
        Debug.Log("Game State: " + newGameState);
    }

    public GameState GetGameState()
    {
        return currentGameState;
    }
    
    public enum GameState
    {
        Prepare,
        Start,
        NextLevel,
        RestartLevel,
        Over,
        End
    }
    public void StartTransitionState()
    {
        EventBus<GameStartEvent>.Emit(this, new GameStartEvent());
    }
}
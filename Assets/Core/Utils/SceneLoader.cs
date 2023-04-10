using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : IDisposable
{
    public SceneLoader()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _token = _cancellationTokenSource.Token;
    }

    public float Progress { get { return _loadOperation == null ? 0 : _loadOperation.progress;} }

    private CancellationTokenSource _cancellationTokenSource;
    private CancellationToken _token;

    private AsyncOperation _loadOperation;

    public async void LoadSceneAsync(string sceneName)
    {
        try
        {
            await PerformSceneLoading(sceneName);
        }
        catch (OperationCanceledException e)
        {
            if (e.CancellationToken == _cancellationTokenSource.Token)
            {
                Debug.LogError($"Scene loading operation is cancelled: {e.Message} {e.StackTrace}");
            }
        }
        finally
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }

    public void AllowActivateScene()
    {
        if (_loadOperation == null)
            return;

        _loadOperation.allowSceneActivation = true;
    }

    private async Task PerformSceneLoading(string sceneName)
    {
        _token.ThrowIfCancellationRequested();

        _loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        _loadOperation.allowSceneActivation = false;

        while (true)
        {
            _token.ThrowIfCancellationRequested();

            if (_loadOperation.progress >= 0.9f)
                break;
        }
    }

    public void Dispose() { }
}
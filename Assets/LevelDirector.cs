using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelDirector : MonoBehaviour {

    public Player _player;
    protected List<CheckPoint> _checkpoints;
    protected int _currentCheckPointIndex;



    private void Start() {

        //_checkpoints = FindObjectsOfType<CheckPoint>().OrderBy(t => t.transform.position.x).ToList();
        _checkpoints = FindObjectsOfType<CheckPoint>().ToList();

        var listeners = FindObjectsOfType<MonoBehaviour>().OfType<IPlayerRespawnListener>();
        foreach (var listener in listeners)
        {
            for (var i = _checkpoints.Count - 1; i >= 0; i--)
            {
                var distance = ((MonoBehaviour)listener).transform.position.x - _checkpoints[i].transform.position.x;
                if (distance < 0)
                    continue;

                _checkpoints[i].AssignObjectToCheckPoint(listener);
                break;
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            StartCoroutine(KillPlayerCo());
        }
    }

    protected virtual IEnumerator KillPlayerCo()
    {
        //_player.Kill();
        //_cameraController.FollowsPlayer = false;
        yield return new WaitForSeconds(1f);

       // _cameraController.FollowsPlayer = true;
        if (_currentCheckPointIndex != -1)
            _checkpoints[_currentCheckPointIndex].SpawnPlayer(_player);

        //_started = DateTime.UtcNow;
        //GameManager.Instance.SetPoints(_savedPoints);
    }
}

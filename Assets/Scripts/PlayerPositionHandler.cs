using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerPositionHandler : MonoBehaviour
{
    #region Condition
    Vector2 playerCurrentPosition;
    Vector2 currentCheckpointPosition;
    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
    }
    public void OnEnemy()

    {
        ChangePlayerPosition(currentCheckpointPosition);
    }
    public void OnFinish()
    {
        SceneManager.LoadScene("EndScreen");

    }
    public void OnTrap()
    {
        ChangePlayerPosition(currentCheckpointPosition);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            OnFinish();
        }
    }
    #endregion

    #region SaveLoad
    public TransformData playerPositionData;
    private void LoadPosition()
    {
            transform.position = playerPositionData.position;
    }
    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }
    #endregion

    #region Instruction
    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
    #endregion
    void Start()
    {

    }
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Scritps.Command;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float stepDistance;
    [SerializeField] private float stepTime;
    
    
    private List<Command> _commandJournal = new List<Command>();
    private bool _isBusy = false;
    private Command lastCommand;
    
    #region InputHandler

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) Move(Vector3.forward, stepDistance, stepTime);
        if(Input.GetKeyDown(KeyCode.S)) Move(-Vector3.forward, stepDistance, stepTime);
        if(Input.GetKeyDown(KeyCode.D)) Move(Vector3.right, stepDistance, stepTime);
        if(Input.GetKeyDown(KeyCode.A)) Move(-Vector3.right, stepDistance, stepTime);
        
        if(Input.GetKeyDown(KeyCode.U)) Undo();
        if(Input.GetKeyDown(KeyCode.R)) Repeat();
    }

    #endregion
    
    
    /// <summary>
    /// Moves the object in the specified direction
    /// </summary>
    /// <param name="direction"> Direction to move target </param>
    /// <param name="stepDistance"> The distance to move the object </param>
    /// <param name="stepTime"> Time to move the object </param>
    private async void Move(Vector3 direction, float stepDistance = 1f, float stepTime = 1f)
    {
        if (!_isBusy)
        {
            _isBusy = true;
            
            var move = new MoveCommand(playerTransform, direction, stepDistance, stepTime);
            
            await move.Execute();
            _commandJournal.Add(move);

            _isBusy = false;
        }
    }

    /// <summary>
    /// Cancels the last action performed
    /// </summary>
    private async void Undo()
    {
        if (!_isBusy && _commandJournal.Count > 0)
        {
            _isBusy = true;
            
            lastCommand = _commandJournal.Last();
                    
            await lastCommand.Undo();
            _commandJournal.Remove(lastCommand);

            _isBusy = false;
        }
    }
    
    
    /// <summary>
    /// Repeats the last undo action performed
    /// </summary>
    private async void Repeat()
    {
        if (!_isBusy && lastCommand != null)
        {
            _isBusy = true;
                    
            await lastCommand.Execute();
            _commandJournal.Add(lastCommand);

            lastCommand = null;
            
            _isBusy = false;
        }
    }

}

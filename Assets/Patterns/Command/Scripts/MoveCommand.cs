using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Scritps.Command
{
    public class MoveCommand : Command
    {
        private Vector3 _direction;
    
        private float _stepDistance;
    
        private float _stepTime;
    

        public MoveCommand(Transform transform, Vector3 direction, float stepDistance = 1f, float stepTime = 1f) : base(transform)
        {
            this._direction = direction.normalized;
            this._stepDistance = stepDistance;
            this._stepTime = stepTime;
        }

        public override async UniTask Execute()
        {
            Vector3 endValue = targetTransform.position + _direction * _stepDistance;
            targetTransform.LookAt(endValue);
            Tween tween = targetTransform.DOMove(endValue, _stepTime);
            await tween.ToUniTask();
        }

        public override async UniTask Undo()
        {
            Vector3 endValue = targetTransform.position - _direction * _stepDistance;
            targetTransform.LookAt(targetTransform.position + _direction * _stepDistance);
            
            Tween tween = targetTransform.DOMove(endValue, _stepTime);
            await tween.ToUniTask();
        }
    }
}

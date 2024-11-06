using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scritps.Command
{
    public abstract class Command
    {
        protected Transform targetTransform;
        public Command(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
        }

        public abstract UniTask Execute();

        public abstract UniTask Undo();

    }
}

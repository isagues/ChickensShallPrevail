using Interface;
using UnityEngine;

namespace Command
{
    public class CmdRotation : ICommand
    {
        private readonly IMovable _movable;

        private readonly Vector3 _direction;

        public CmdRotation(IMovable movable, Vector3 direction)
        {
            _movable = movable;
            _direction = direction;
        }

        public void Execute() => _movable.Rotate(_direction);

    }
}
﻿using Interface;
using UnityEngine;

namespace Command
{
    public class CmdMovement : ICommand
    {
        private IMovable _movable;

        private Vector3 _direction;

        public CmdMovement(IMovable movable, Vector3 direction)
        {
            _movable = movable;
            _direction = direction;
        }

        public void Execute() => _movable.Travel(_direction);

    }
}
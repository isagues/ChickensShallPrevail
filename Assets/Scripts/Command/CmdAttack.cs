using Interface;
using UnityEngine;

namespace Command
{
    public class CmdAttack : ICommand
    {
        private ITurret _turret;
        

        public CmdAttack(ITurret turret)
        {
            _turret = turret;
        }

        public void Execute() => _turret.Attack();

    }
}
using Interface;

namespace Command
{
    public class CmdDeploy : ICommand
    {
        private IDeployer _deployer;
        

        public CmdDeploy(IDeployer deployer)
        {
            _deployer = deployer;
        }

        public void Execute() => _deployer.Deploy();

    }
}
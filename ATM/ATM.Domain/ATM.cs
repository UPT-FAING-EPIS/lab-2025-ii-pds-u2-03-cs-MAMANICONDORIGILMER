namespace ATM.Domain
{
    public class ATM
    {
        ICommand _command;
        public ATM(ICommand command)
        {
            _command = command;
        }
        public void Action()
        {
            _command.Execute();
        }
    }
}
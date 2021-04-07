using EDLibrary.Menu;
using System;

namespace EDLibrary.CommandFactory
{
    public class InGameCommand : Command
    {
        public string Action { get; set; }
        public bool PressState { get; set; }
        public override void Execute(object sender)
        {
            if (Action == null || Action == "") throw new ArgumentNullException("Action cannot be null");
            ((Controller)sender).ExecuteAction(Action, PressState);
        }
    }
}

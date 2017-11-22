using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Actions
{
    public class NilAction : Action
    {
        public override bool IsDone => true;

        public NilAction() : base(null)
        {
        }

        public override Action GetNextAction()
        {
            throw new NotImplementedException();
        }
    }
}

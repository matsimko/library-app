using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopApp.ORM
{
    public abstract class DomainObject
    {
        public Key Key { get; set; }
    }
}

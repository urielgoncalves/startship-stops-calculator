using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsApp.Shared.Enums
{
    public enum Consumable
    {
        Years= 8760,//365 * 24
        Months = 730,//365 * 24 / 12
        Weeks = 168,//Average hours per week in one year
        Days= 24,
        Unknown = -1
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace opp__04
{
    public interface ITrackable
    {
        string GetTrackingStatus();
    }

    public interface IInsurable
    {
        decimal CalculateInsurance();
    }
}

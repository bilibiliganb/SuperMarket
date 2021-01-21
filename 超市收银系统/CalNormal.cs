using System;
using System.Collections.Generic;
using System.Text;

namespace 超市收银系统
{
    class CalNormal : CalFather
    {
        public override double GetTotalMoney(double realMoney)
        {
            return realMoney;
        }
    }
}

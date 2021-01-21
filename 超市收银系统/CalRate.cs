using System;
using System.Collections.Generic;
using System.Text;

namespace 超市收银系统
{
    class CalRate : CalFather
    {
        public double Rate
        {
            get;set;
        }

        public CalRate(double rate)
        {
            this.Rate = rate;
        }
        public override double GetTotalMoney(double realMoney)
        {
            return realMoney * this.Rate;
        }
    }
}

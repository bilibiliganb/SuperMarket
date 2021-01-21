using System;
using System.Collections.Generic;
using System.Text;

namespace 超市收银系统
{
    class CalMN : CalFather
    {
        //买500送100
        public double M
        {
            get;set;
        }

        public double N
        {
            get;set;
        }

        public CalMN(double m,double n)
        {
            this.M = m;
            this.N = n;
        }

        public override double GetTotalMoney(double realMoney)
        {
            if(realMoney>=this.M)
            {
                return realMoney - this.N* (int)(realMoney / this.M);
            }
            else
            {
                return realMoney;
            }
        }
    }
}

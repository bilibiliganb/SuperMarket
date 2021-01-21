using System;
using System.Collections.Generic;
using System.Text;

namespace 超市收银系统
{
    class SupperMarket
    {
        CangKu ck = new CangKu();
        /// <summary>
        /// 创建超市对象的时候，给仓库的货架上导入货物
        /// </summary>
        public SupperMarket()
        {
            ck.GetPros("Acer", 1000);
            ck.GetPros("SamSung", 1000);
            ck.GetPros("JiangYou", 1000);
            ck.GetPros("Banana", 1000);
        }

        /// <summary>
        /// 用户交互
        /// </summary>
        public void AskBuying()
        {
            Console.WriteLine();
            Console.WriteLine("欢迎光临，请问您需要些什么？");
            Console.WriteLine("我们有Acer、SamSung、JiangYou、Banana");
            string strType = Console.ReadLine();
            Console.WriteLine("您需要多少");
            int count = Convert.ToInt32(Console.ReadLine());
            //去仓库取货
            ProductFather[] pros = ck.QuPros(strType, count);
            double realMoney = GetMoney(pros);
            Console.WriteLine("您总共应付{0}元",realMoney);
            Console.WriteLine("请选择您的打折方式    1---不打折 2---打9折 3---打85折 4---买300送50 5---买500送100");
            string input = Console.ReadLine();
            //通过简单工厂的设计模式根据用户的输入获得一个打折对象
            CalFather cal = GetCal(input);
            double totalMoney = cal.GetTotalMoney(realMoney);
            Console.WriteLine("打完折后，您应付{0}元",totalMoney);
            Console.WriteLine("以下是您的购物信息");

            foreach (var item in pros)
            {
                Console.WriteLine("货物名称:"+item.Name+",\t货物单价"+item.Price+"\t货物编号"+item.ID);
            }

        }

       
        public CalFather GetCal(string input)
        {
            CalFather cal = null;
            switch (input)
            {
                case "1":
                    cal = new CalNormal();
                    break;
                case "2":
                    cal = new CalRate(0.9);
                    break;
                case "3":
                    cal = new CalRate(0.85);
                    break;
                case "4":
                    cal = new CalMN(300, 50);
                    break;
                case "5":
                    cal = new CalMN(500, 100);
                    break;
            }


            return cal;
        }


        public double GetMoney(ProductFather[] pros)
        {
            double realMoney = 0;
            for (int i = 0; i < pros.Length; i++)
            {
                realMoney += pros[i].Price;
            }
            return realMoney;
        }



        public void ShowPros()
        {
            ck.ShowPros();
        }
    }
}

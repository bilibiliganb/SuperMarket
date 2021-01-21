using System;
using System.Collections.Generic;
using System.Text;

namespace 超市收银系统
{
    class CangKu
    {
        //List<ProductFather> list = new List<ProductFather>();
        List<List<ProductFather>> list = new List<List<ProductFather>>();



        public void ShowPros()
        {
            foreach (var item in list)
            {
                if (item.Count != 0)
                    if (item[0].Name.Length <= 3)
                        Console.WriteLine("我们超市有:" + item[0].Name + "\t\t" + "有" + item.Count + "个\t每个" + item[0].Price + "元");
                    else
                        Console.WriteLine("我们超市有:" + item[0].Name + "\t" + "有" + item.Count + "个\t每个" + item[0].Price + "元");
            }
        }




        /// <summary>
        /// 在创建仓库对象的时候  向仓库中添加货架
        /// list[0]存储Acer电脑
        /// list[1]存储三星手机
        /// list[2]存储酱油
        /// list[3]存储香蕉
        /// </summary>
        public CangKu()
        {
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
        }
        /// <summary>
        /// 进货
        /// </summary>
        /// <param name="strType">货物的类型</param>
        /// <param name="count">货物的数量</param>
        public void GetPros(string strType,int count)
        {
            for(int i=0;i<count;i++)
                switch(strType)
                {
                    case "Acer":list[0].Add(new Acer(Guid.NewGuid().ToString(), 1000, "弘基笔记本"));
                        break;
                    case "SamSung":list[1].Add(new SamSung(Guid.NewGuid().ToString(), 2000, "三星炸弹"));
                        break;
                    case "JiangYou":list[2].Add(new JiangYou(Guid.NewGuid().ToString(), 100, "酱油"));
                        break;
                    case "Banana":list[3].Add(new Banana(Guid.NewGuid().ToString(), 50, "香蕉"));
                        break;
                }
        }
        /// <summary>
        /// 取货
        /// </summary>
        /// <param name="strType">货物的类型</param>
        /// <param name="count">货物的数量</param>
        /// <returns></returns>
        public ProductFather[] QuPros(string strType,int count)
        {
            ProductFather[] pros = new ProductFather[count];
            for (int i = 0; i < count; i++)
            {
                switch(strType)
                {
                    case "Acer":
                        if (list[0].Count != 0)
                        {
                            pros[i] = list[0][0];
                            list[0].RemoveAt(0);
                        }
                        break;
                    case "SamSung":
                        if (list[1].Count != 0)
                        {
                            pros[i] = list[1][0];
                            list[1].RemoveAt(0);
                        }
                        break;
                    case "JiangYou":
                        if (list[2].Count != 0)
                        {
                            pros[i] = list[2][0];
                            list[2].RemoveAt(0);
                        }
                        break;
                    case "Banana":
                        if (list[3].Count != 0)
                        {
                            pros[i] = list[3][0];
                            list[3].RemoveAt(0);
                        }
                        break;
                }
            }
            return pros;
        }

    }
}

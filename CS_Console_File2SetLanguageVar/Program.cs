using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace CS_Console_File2SetLanguageVar
{

    class Program
    {
        //static ArrayList ALStr = new ArrayList();
        static ArrayList ALStrName = new ArrayList();
        static ArrayList ALStrValue = new ArrayList();
        static public void ReadLangSet(int index)
        {
            //ALStr.Clear();
            //int i = 0;
            ALStrName.Clear();
            ALStrValue.Clear();
            StreamReader sr = null;
            switch (index)
            {
                case 0:
                    sr = new StreamReader("language\\list_tw.csv");//修改語系檔放在執行檔目錄下的language資料夾中 at 2017/04/06
                    break;
                case 1:
                    sr = new StreamReader("language\\list_cn.csv");//修改語系檔放在執行檔目錄下的language資料夾中 at 2017/04/06
                    break;
                case 2:
                    sr = new StreamReader("language\\list_en.csv");//修改語系檔放在執行檔目錄下的language資料夾中 at 2017/04/06
                    break;
                case 3:
                    sr = new StreamReader("language\\list_other.csv");//修改語系檔放在執行檔目錄下的language資料夾中 at 2017/04/06
                    break;
            }
            while (!sr.EndOfStream)// 每次讀取一行，直到檔尾
            {
                string line = sr.ReadLine();// 讀取文字到 line 變數
                if (line.Length > 0 && line.IndexOf(',') > 0)
                {
                    //String StrBuf = line.Substring(line.IndexOf(',') + 1);
                    string[] strs = line.Split(',');
                    ALStrName.Add(strs[0]);
                    ALStrValue.Add(strs[1]);
                    //ALStr.Add(StrBuf);
                    //i++;
                }
            }
            sr.Close();// 關閉串流
        }
        static void pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();// 引用stopwatch物件
            ReadLangSet(1);
            sw.Reset();
            sw.Start();//碼表開始計時
            String m_StrControllerMsg00 = (String)ALStrValue[ALStrName.IndexOf("m_StrControllerMsg00")];
            sw.Stop();//碼錶停止
            string result1 = sw.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine("語言檔總行數 = {0}", ALStrName.Count);
            Console.WriteLine("最後一筆資料內容 = {0}", m_StrControllerMsg00);
            Console.WriteLine("讀取檔案+搜尋一筆所花的時間 = {0}ms", result1);
            pause();
        }
    }
}

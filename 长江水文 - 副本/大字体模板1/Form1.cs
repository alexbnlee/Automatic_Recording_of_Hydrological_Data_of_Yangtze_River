using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace 大字体模板1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hashtable lunarYear = new Hashtable();
            lunarYear.Add(1, "一");
            lunarYear.Add(2, "二");
            lunarYear.Add(3, "三");
            lunarYear.Add(4, "四");
            lunarYear.Add(5, "五");
            lunarYear.Add(6, "六");
            lunarYear.Add(7, "七");
            lunarYear.Add(8, "八");
            lunarYear.Add(9, "九");
            lunarYear.Add(0, "零");

            Hashtable lunarMonth = new Hashtable();
            lunarMonth.Add(1, "正");
            lunarMonth.Add(2, "二");
            lunarMonth.Add(3, "三");
            lunarMonth.Add(4, "四");
            lunarMonth.Add(5, "五");
            lunarMonth.Add(6, "六");
            lunarMonth.Add(7, "七");
            lunarMonth.Add(8, "八");
            lunarMonth.Add(9, "九");
            lunarMonth.Add(10, "十");
            lunarMonth.Add(11, "十一");
            lunarMonth.Add(12, "十二");

            Hashtable lunarDay = new Hashtable();
            lunarDay.Add(1, "初一");
            lunarDay.Add(2, "初二");
            lunarDay.Add(3, "初三");
            lunarDay.Add(4, "初四");
            lunarDay.Add(5, "初五");
            lunarDay.Add(6, "初六");
            lunarDay.Add(7, "初七");
            lunarDay.Add(8, "初八");
            lunarDay.Add(9, "初九");
            lunarDay.Add(10, "初十");
            lunarDay.Add(11, "十一");
            lunarDay.Add(12, "十二");
            lunarDay.Add(13, "十三");
            lunarDay.Add(14, "十四");
            lunarDay.Add(15, "十五");
            lunarDay.Add(16, "十六");
            lunarDay.Add(17, "十七");
            lunarDay.Add(18, "十八");
            lunarDay.Add(19, "十九");
            lunarDay.Add(20, "二十");
            lunarDay.Add(21, "二十一");
            lunarDay.Add(22, "二十二");
            lunarDay.Add(23, "二十三");
            lunarDay.Add(24, "二十四");
            lunarDay.Add(25, "二十五");
            lunarDay.Add(26, "二十六");
            lunarDay.Add(27, "二十七");
            lunarDay.Add(28, "二十八");
            lunarDay.Add(29, "二十九");
            lunarDay.Add(30, "三十");

            char[] yearNums = new char[4];
            yearNums = new ChineseLunisolarCalendar().GetYear(dateTimePicker1.Value.Date).ToString().ToCharArray();
            string year =
                lunarYear[Convert.ToInt32(yearNums[0].ToString())].ToString() +
                lunarYear[Convert.ToInt32(yearNums[1].ToString())].ToString() +
                lunarYear[Convert.ToInt32(yearNums[2].ToString())].ToString() +
                lunarYear[Convert.ToInt32(yearNums[3].ToString())].ToString();
            string month = lunarMonth[GetMonthFromYear(dateTimePicker1.Value.Date)].ToString();
            string day = lunarDay[new ChineseLunisolarCalendar().GetDayOfMonth(dateTimePicker1.Value.Date)].ToString();
            textBox1.Text = year + "年" +month + "月" + day;
        }

        private int GetMonthFromYear(DateTime time)
        {
            ChineseLunisolarCalendar clc = new ChineseLunisolarCalendar();
            if (clc.GetLeapMonth(time.Year) != 0)   //存在闰月
            {
                if (clc.GetMonth(time) > clc.GetLeapMonth(time.Year))   //如果月份大于闰月
                {
                    return clc.GetMonth(time) - 1;
                }
            }
            return clc.GetMonth(time);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = "123.56";
            int num1 = a.IndexOf('.');
            MessageBox.Show(num1.ToString());
        }

        
    }
}

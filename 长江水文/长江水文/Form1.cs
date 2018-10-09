using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace 长江水文
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 全局变量设置
        public struct Info
        {
            public string name;
            public string date;
            public string water;
            public string stream;
        }

        Excel.Application ex = new Excel.Application();
        Excel.Workbook eWorkbook;
        Excel.Worksheet eWorksheet;


        int countRecorderDay = 0;   //用来记录白天的记载次数
        int countRecorderNight = 0; //用来记录夜间的记录次数
        int count = 0;  //倒计时来用

        string saveFilePath = Environment.CurrentDirectory + @"\长江水文\长江水文.xlsx"; //Excel的文件地址
        #endregion

        private void timer1_Tick(object sender, EventArgs e)    //计时器1
        {
            if ((DateTime.Now.Hour == 8 && DateTime.Now.Minute >= 30 && countRecorderDay == 0) 
                || (DateTime.Now.Hour == 20 && DateTime.Now.Minute >= 30 && countRecorderNight == 0))
            {
	            timer2.Enabled = true;  //开启 timer2
                lbTimer2.Text = "计时器2开启！";
                lbTimer1.Text = "计时器1关闭！";
                timer1.Enabled = false;
                return;
            }

            if (DateTime.Now.Hour == 23 && DateTime.Now.Minute >= 55)    //夜间11点，将数据归零，等待第二天记录
            {
                countRecorderDay = 0;
                countRecorderNight = 0;
            }

            lbTimer1.Text = "计时器1开启！";
            lbRecord.Text = "上一次操作时间：" + DateTime.Now.ToShortTimeString();    //记录 timer1 操作时间
            上次操作时间ToolStripMenuItem.Text = lbRecord.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = new System.Uri("http://219.140.196.71/sq/data/sc.action?scid=cjh.sq");
            lbRecord.Text = "上一次操作时间：" + DateTime.Now.ToShortTimeString();
            上次操作时间ToolStripMenuItem.Text = lbRecord.Text;
        }

        private void btRefresh_Click(object sender, EventArgs e)  //刷新网站
        {
            webBrowser1.Url = new System.Uri("http://219.140.196.71/sq/data/sc.action?scid=cjh.sq");
        }

        private void btRecorder_Click(object sender, EventArgs e)   //记录数据
        {
            #region 获取网站的中的数据，并存到 List 中
            webBrowser1.Url = new System.Uri("http://219.140.196.71/sq/data/sc.action?scid=cjh.sq");  //刷新网站
            string strText = webBrowser1.Document.Body.InnerText;   
            if (strText == null)
                return;

            int indexFront = strText.IndexOf("寸滩");
            //int indexAfter = strText.IndexOf("防汛测报");
            string text = null;
            if (indexFront > 0)
                text = strText.Substring(indexFront);  //获取有用的部分
            else
                return;

            string[] strLines = new string[20];
            strLines = text.Split(new char[] { '\n' }); //将内容按回车分割成数组

            List<Info> content = new List<Info>();  //获取数据的每一个部分

            for (int i = 0; i < strLines.Length; i++)
            {
                string[] parts = new string[6]; //一般是六部分
                if (strLines[i].Length < 6)
                    break;
                parts = strLines[i].Split(new char[] { ' ' });  //分成三部分：名称+日期+数据
                Info inner = new Info();
                //名称内容
                inner.name = parts[0];
                if (inner.name == "茅坪(二)" || inner.name == "龙王庙")
                    continue;   //这两个不加入,直接跳过!

                //日期内容
                inner.date = parts[1] + parts[2] + parts[3];

                //水位数据，基本都有
                inner.water = parts[4];

                //流量数据，有时候没有为“-”，有时候存在负数,判断存在“-”，并且并且“-”后面没有内容时候为空值
                if (!parts[5].Contains('-'))
                    inner.stream = parts[5];
                else
                    inner.stream = "0";

                if (inner.stream.Contains('(')) //包括(入) 和 (出)
                {
                    inner.stream = inner.stream + strLines[i + 1];  //将下一行的(出)也加进来,然后i自加!
                    i++;
                }
                else if (inner.name.Contains('-'))
                {
                    inner.stream = "0";
                }

                content.Add(inner);
            }
            #endregion

            int countDay = 0;
            int countNight = 0;

            foreach (Info info in content)
            {
                if (info.date.Contains("8时"))   //获取8时的数据
                    countDay++;
                else if (info.date.Contains("20时"))
                    countNight++;
            }

            #region 定义 lunarMonth 和 lunarDay
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
            #endregion

            if (countDay == 11)   //countDay == 11
            {
                #region 8时
                string excelPath = saveFilePath;

                eWorkbook = ex.Workbooks.Open(excelPath);　　　　//打开文件，赋值到工作簿
                ex.Visible = false;　　　　　　　　　　　　　　　　　　　　//程序显示
                eWorksheet = (Excel.Worksheet)eWorkbook.Sheets[1];　　//获取第一个工作表

                //新格式
                string date = DateTime.Today.Month + "月" + DateTime.Today.Day + "日";
                ChineseLunisolarCalendar lunar = new ChineseLunisolarCalendar();
                string dateLunar = lunarMonth[GetMonthFromYear(DateTime.Today.Date)] + "月" + 
                    lunarDay[lunar.GetDayOfMonth(DateTime.Today.Date)]; 
                int row = ex.Application.get_Range("B65535", Type.Missing).get_End(Excel.XlDirection.xlUp).Row;

                eWorksheet.get_Range("A" + (row + 1).ToString()).Value = date;
                eWorksheet.get_Range("B" + (row + 1).ToString()).Value = DateTime.Now.Hour + "时";
                eWorksheet.get_Range("C" + (row + 1).ToString()).Value = dateLunar;

                eWorksheet.get_Range("D" + (row + 1).ToString()).Value = Convert.ToSingle(content[0].water);
                if (content[0].stream != "0")
                    eWorksheet.get_Range("E" + (row + 1).ToString()).Value = Convert.ToSingle(content[0].stream);
                else
                    eWorksheet.get_Range("E" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("F" + (row + 1).ToString()).Value = Convert.ToSingle(content[1].water);
                if (content[1].stream != "0")
                    eWorksheet.get_Range("G" + (row + 1).ToString()).Value = Convert.ToSingle(content[1].stream);
                else
                    eWorksheet.get_Range("G" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("H" + (row + 1).ToString()).Value = Convert.ToSingle(content[2].water);
                if (content[2].stream != "0")
                    eWorksheet.get_Range("I" + (row + 1).ToString()).Value = Convert.ToSingle(content[2].stream);
                else
                    eWorksheet.get_Range("I" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("J" + (row + 1).ToString()).Value = Convert.ToSingle(content[3].water);
                if (content[3].stream != "0")
                    eWorksheet.get_Range("K" + (row + 1).ToString()).Value = Convert.ToSingle(content[3].stream);
                else
                    eWorksheet.get_Range("K" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("L" + (row + 1).ToString()).Value = Convert.ToSingle(content[4].water);
                if (content[4].stream != "0")
                    eWorksheet.get_Range("M" + (row + 1).ToString()).Value = Convert.ToSingle(content[4].stream);
                else
                    eWorksheet.get_Range("M" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("N" + (row + 1).ToString()).Value = Convert.ToSingle(content[5].water);
                if (content[5].stream != "0")
                    eWorksheet.get_Range("O" + (row + 1).ToString()).Value = Convert.ToSingle(content[5].stream);
                else
                    eWorksheet.get_Range("O" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("P" + (row + 1).ToString()).Value = Convert.ToSingle(content[6].water);
                if (content[6].stream != "0")
                    eWorksheet.get_Range("Q" + (row + 1).ToString()).Value = Convert.ToSingle(content[6].stream);
                else
                    eWorksheet.get_Range("Q" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("R" + (row + 1).ToString()).Value = Convert.ToSingle(content[7].water);
                if (content[7].stream != "0")
                    eWorksheet.get_Range("S" + (row + 1).ToString()).Value = Convert.ToSingle(content[7].stream);
                else
                    eWorksheet.get_Range("S" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("T" + (row + 1).ToString()).Value = Convert.ToSingle(content[8].water);
                if (content[8].stream != "0")
                    eWorksheet.get_Range("U" + (row + 1).ToString()).Value = Convert.ToSingle(content[8].stream);
                else
                    eWorksheet.get_Range("U" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("V" + (row + 1).ToString()).Value = Convert.ToSingle(content[9].water);
                if (content[9].stream.Contains('('))
                {
                    int inFront = content[9].stream.IndexOf('(');
                    int inBack = content[9].stream.IndexOf(')');
                    int outFront = content[9].stream.LastIndexOf('(');
                    string streamIn = content[9].stream.Substring(0, inFront);
                    string streamOut = content[9].stream.Substring(inBack + 1, outFront - inBack - 1);
                    eWorksheet.get_Range("W" + (row + 1).ToString()).Value = Convert.ToSingle(streamOut);
                    eWorksheet.get_Range("X" + (row + 1).ToString()).Value = Convert.ToSingle(streamIn);
                }
                else
                {
                    eWorksheet.get_Range("W" + (row + 1).ToString()).Value = Convert.ToSingle(content[9].stream);
                }

                eWorksheet.get_Range("Y" + (row + 1).ToString()).Value = Convert.ToSingle(content[10].water);
                if (content[10].stream.Contains('('))
                {
                    int inFront = content[10].stream.IndexOf('(');
                    int inBack = content[10].stream.IndexOf(')');
                    int outFront = content[10].stream.LastIndexOf('(');
                    string streamIn = content[10].stream.Substring(0, inFront);
                    string streamOut = content[10].stream.Substring(inBack + 1, outFront - inBack - 1);
                    eWorksheet.get_Range("Z" + (row + 1).ToString()).Value = Convert.ToSingle(streamOut);
                    eWorksheet.get_Range("AA" + (row + 1).ToString()).Value = Convert.ToSingle(streamIn);
                }
                else
                {
                    eWorksheet.get_Range("Z" + (row + 1).ToString()).Value = Convert.ToSingle(content[10].stream);
                }


                eWorkbook.Save();
                ex.Quit();
                this.Focus();
                timer2.Enabled = false;
                lbTimer2.Text = "计时器2关闭！";
                timer1.Enabled = true;
                lbTimer1.Text = "计时器1开启！";
                label4.Text = DateTime.Now.ToShortDateString() + " 8时 记录完毕！";
                countRecorderDay++;
                #endregion
            }
            
            if (countNight == 11)
            {
                #region 20时
                string excelPath = saveFilePath;

                eWorkbook = ex.Workbooks.Open(excelPath);　　　　//打开文件，赋值到工作簿
                ex.Visible = false;　　　　　　　　　　　　　　　　　　　　//程序显示
                eWorksheet = (Excel.Worksheet)eWorkbook.Sheets[1];　　//获取第一个工作表

                //新格式
                string date = DateTime.Today.Month + "月" + DateTime.Today.Day + "日";
                ChineseLunisolarCalendar lunar = new ChineseLunisolarCalendar();
                string dateLunar = lunarMonth[GetMonthFromYear(DateTime.Today.Date)] + "月" +
                    lunarDay[lunar.GetDayOfMonth(DateTime.Today.Date)];
                int row = ex.Application.get_Range("B65535", Type.Missing).get_End(Excel.XlDirection.xlUp).Row;

                //eWorksheet.get_Range("A" + (row + 1).ToString()).Value = date;
                eWorksheet.get_Range("B" + (row + 1).ToString()).Value = DateTime.Now.Hour + "时";
                //eWorksheet.get_Range("C" + (row + 1).ToString()).Value = dateLunar;

                eWorksheet.get_Range("D" + (row + 1).ToString()).Value = Convert.ToSingle(content[0].water);
                if (content[0].stream != "0")
                    eWorksheet.get_Range("E" + (row + 1).ToString()).Value = Convert.ToSingle(content[0].stream);
                else
                    eWorksheet.get_Range("E" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("F" + (row + 1).ToString()).Value = Convert.ToSingle(content[1].water);
                if (content[1].stream != "0")
                    eWorksheet.get_Range("G" + (row + 1).ToString()).Value = Convert.ToSingle(content[1].stream);
                else
                    eWorksheet.get_Range("G" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("H" + (row + 1).ToString()).Value = Convert.ToSingle(content[2].water);
                if (content[2].stream != "0")
                    eWorksheet.get_Range("I" + (row + 1).ToString()).Value = Convert.ToSingle(content[2].stream);
                else
                    eWorksheet.get_Range("I" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("J" + (row + 1).ToString()).Value = Convert.ToSingle(content[3].water);
                if (content[3].stream != "0")
                    eWorksheet.get_Range("K" + (row + 1).ToString()).Value = Convert.ToSingle(content[3].stream);
                else
                    eWorksheet.get_Range("K" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("L" + (row + 1).ToString()).Value = Convert.ToSingle(content[4].water);
                if (content[4].stream != "0")
                    eWorksheet.get_Range("M" + (row + 1).ToString()).Value = Convert.ToSingle(content[4].stream);
                else
                    eWorksheet.get_Range("M" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("N" + (row + 1).ToString()).Value = Convert.ToSingle(content[5].water);
                if (content[5].stream != "0")
                    eWorksheet.get_Range("O" + (row + 1).ToString()).Value = Convert.ToSingle(content[5].stream);
                else
                    eWorksheet.get_Range("O" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("P" + (row + 1).ToString()).Value = Convert.ToSingle(content[6].water);
                if (content[6].stream != "0")
                    eWorksheet.get_Range("Q" + (row + 1).ToString()).Value = Convert.ToSingle(content[6].stream);
                else
                    eWorksheet.get_Range("Q" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("R" + (row + 1).ToString()).Value = Convert.ToSingle(content[7].water);
                if (content[7].stream != "0")
                    eWorksheet.get_Range("S" + (row + 1).ToString()).Value = Convert.ToSingle(content[7].stream);
                else
                    eWorksheet.get_Range("S" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("T" + (row + 1).ToString()).Value = Convert.ToSingle(content[8].water);
                if (content[8].stream != "0")
                    eWorksheet.get_Range("U" + (row + 1).ToString()).Value = Convert.ToSingle(content[8].stream);
                else
                    eWorksheet.get_Range("U" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("V" + (row + 1).ToString()).Value = Convert.ToSingle(content[9].water);
                if (content[9].stream.Contains('('))
                {
                    int inFront = content[9].stream.IndexOf('(');
                    int inBack = content[9].stream.IndexOf(')');
                    int outFront = content[9].stream.LastIndexOf('(');
                    string streamIn = content[9].stream.Substring(0, inFront);
                    string streamOut = content[9].stream.Substring(inBack + 1, outFront - inBack - 1);
                    eWorksheet.get_Range("W" + (row + 1).ToString()).Value = Convert.ToSingle(streamOut);
                    eWorksheet.get_Range("X" + (row + 1).ToString()).Value = Convert.ToSingle(streamIn);
                }
                else
                {
                    eWorksheet.get_Range("W" + (row + 1).ToString()).Value = Convert.ToSingle(content[9].stream);
                }

                eWorksheet.get_Range("Y" + (row + 1).ToString()).Value = Convert.ToSingle(content[10].water);
                if (content[10].stream.Contains('('))
                {
                    int inFront = content[10].stream.IndexOf('(');
                    int inBack = content[10].stream.IndexOf(')');
                    int outFront = content[10].stream.LastIndexOf('(');
                    string streamIn = content[10].stream.Substring(0, inFront);
                    string streamOut = content[10].stream.Substring(inBack + 1, outFront - inBack - 1);
                    eWorksheet.get_Range("Z" + (row + 1).ToString()).Value = Convert.ToSingle(streamOut);
                    eWorksheet.get_Range("AA" + (row + 1).ToString()).Value = Convert.ToSingle(streamIn);
                }
                else
                {
                    eWorksheet.get_Range("Z" + (row + 1).ToString()).Value = Convert.ToSingle(content[10].stream);
                }


                eWorkbook.Save();
                ex.Quit();
                this.Focus();
                //Application.Exit();
                timer2.Enabled = false;
                lbTimer2.Text = "计时器2关闭！";
                timer1.Enabled = true;
                lbTimer1.Text = "计时器1开启！";
                label4.Text = DateTime.Now.ToShortDateString() + " 20时 记录完毕！";
                countRecorderNight++;
                #endregion
            }
        }

        private void btOpenFile_Click(object sender, EventArgs e)  //打开工作簿
        {
            if (btOpenFile.Text == "打开Excel查看")
            {
                string excelPath = saveFilePath;
                eWorkbook = ex.Workbooks.Open(excelPath);　　　　//打开文件，赋值到工作簿
                int rowNum = ex.Application.get_Range("B65535", Type.Missing).get_End(Excel.XlDirection.xlUp).Row;
                eWorksheet = (Excel.Worksheet)eWorkbook.Sheets[1];
                eWorksheet.get_Range("B" + (rowNum + 5).ToString()).Value = null;   //保证滚到此位置
                ex.Visible = true;
                btOpenFile.Text = "保存关闭Excel";
            }       
            else if(btOpenFile.Text == "保存关闭Excel")
            {
                eWorkbook.Save();
                ex.Quit();
                btOpenFile.Text = "打开Excel查看";
            }
        }
        
        private void btDownloadData_Click(object sender, EventArgs e)  //添加到Excel，保存当前数据
        {
            #region 获取网站的中的数据，并存到 List 中
            webBrowser1.Url = new System.Uri("http://219.140.196.71/sq/data/sc.action?scid=cjh.sq");  //刷新网站
            string strText = webBrowser1.Document.Body.InnerText;   
            if (strText == null)
                return;

            int indexFront = strText.IndexOf("寸滩");
            //int indexAfter = strText.IndexOf("防汛测报");
            string text = null;
            if (indexFront > 0)
                text = strText.Substring(indexFront);  //获取有用的部分
            else
                return;

            string[] strLines = new string[20];
            strLines = text.Split(new char[] { '\n' }); //将内容按回车分割成数组

            List<Info> content = new List<Info>();  //获取数据的每一个部分

            for (int i = 0; i < strLines.Length; i++)
            {
                string[] parts = new string[6]; //一般是六部分
                if (strLines[i].Length < 6)
                    break;
                parts = strLines[i].Split(new char[] { ' ' });  //分成三部分：名称+日期+数据
                Info inner = new Info();
                //名称内容
                inner.name = parts[0];
                if (inner.name == "茅坪(二)" || inner.name == "龙王庙")
                    continue;   //这两个不加入,直接跳过!

                //日期内容
                inner.date = parts[1] + parts[2] + parts[3];

                //水位数据，基本都有
                inner.water = parts[4];

                //流量数据，有时候没有为“-”，有时候存在负数,判断存在“-”，并且并且“-”后面没有内容时候为空值
                if (!parts[5].Contains('-'))
                    inner.stream = parts[5];
                else
                    inner.stream = "0";

                if (inner.stream.Contains('(')) //包括(入) 和 (出)
                {
                    inner.stream = inner.stream + strLines[i + 1];  //将下一行的(出)也加进来,然后i自加!
                    i++;
                }
                else if (inner.name.Contains('-'))
                {
                    inner.stream = "0";
                }

                content.Add(inner);
            }
            #endregion

            int countDay = 0;
            int countNight = 0;

            foreach (Info info in content)
            {
                if (info.date.Contains("8时"))   //获取8时的数据
                    countDay++;
                else if (info.date.Contains("20时"))
                    countNight++;
            }

            #region 定义 lunarMonth 和 lunarDay
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
            #endregion

            if (true)
            {
                #region 当前时刻
                string excelPath = saveFilePath;

                eWorkbook = ex.Workbooks.Open(excelPath);　　　　//打开文件，赋值到工作簿
                ex.Visible = false;　　　　　　　　　　　　　　　　　　　　//程序显示
                eWorksheet = (Excel.Worksheet)eWorkbook.Sheets[1];　　//获取第一个工作表

                //新格式
                string date = DateTime.Today.Month + "月" + DateTime.Today.Day + "日";
                ChineseLunisolarCalendar lunar = new ChineseLunisolarCalendar();
                string dateLunar = lunarMonth[GetMonthFromYear(DateTime.Today.Date)] + "月" +
                    lunarDay[lunar.GetDayOfMonth(DateTime.Today.Date)];
                int row = ex.Application.get_Range("B65535", Type.Missing).get_End(Excel.XlDirection.xlUp).Row;

                eWorksheet.get_Range("A" + (row + 1).ToString()).Value = date;
                eWorksheet.get_Range("B" + (row + 1).ToString()).Value = DateTime.Now.ToShortTimeString();
                eWorksheet.get_Range("C" + (row + 1).ToString()).Value = dateLunar;

                eWorksheet.get_Range("D" + (row + 1).ToString()).Value = Convert.ToSingle(content[0].water);
                if (content[0].stream != "0")
                    eWorksheet.get_Range("E" + (row + 1).ToString()).Value = Convert.ToSingle(content[0].stream);
                else
                    eWorksheet.get_Range("E" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("F" + (row + 1).ToString()).Value = Convert.ToSingle(content[1].water);
                if (content[1].stream != "0")
                	eWorksheet.get_Range("G" + (row + 1).ToString()).Value = Convert.ToSingle(content[1].stream);
                else
                    eWorksheet.get_Range("G" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("H" + (row + 1).ToString()).Value = Convert.ToSingle(content[2].water);
                if (content[2].stream != "0")
                    eWorksheet.get_Range("I" + (row + 1).ToString()).Value = Convert.ToSingle(content[2].stream);
                else
                    eWorksheet.get_Range("I" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("J" + (row + 1).ToString()).Value = Convert.ToSingle(content[3].water);
                if (content[3].stream != "0")
                    eWorksheet.get_Range("K" + (row + 1).ToString()).Value = Convert.ToSingle(content[3].stream);
                else
                    eWorksheet.get_Range("K" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("L" + (row + 1).ToString()).Value = Convert.ToSingle(content[4].water);
                if (content[4].stream != "0")
                    eWorksheet.get_Range("M" + (row + 1).ToString()).Value = Convert.ToSingle(content[4].stream);
                else
                    eWorksheet.get_Range("M" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("N" + (row + 1).ToString()).Value = Convert.ToSingle(content[5].water);
                if (content[5].stream != "0")
                    eWorksheet.get_Range("O" + (row + 1).ToString()).Value = Convert.ToSingle(content[5].stream);
                else
                    eWorksheet.get_Range("O" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("P" + (row + 1).ToString()).Value = Convert.ToSingle(content[6].water);
                if (content[6].stream != "0")
                    eWorksheet.get_Range("Q" + (row + 1).ToString()).Value = Convert.ToSingle(content[6].stream);
                else
                    eWorksheet.get_Range("Q" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("R" + (row + 1).ToString()).Value = Convert.ToSingle(content[7].water);
                if (content[7].stream != "0")
                    eWorksheet.get_Range("S" + (row + 1).ToString()).Value = Convert.ToSingle(content[7].stream);
                else
                    eWorksheet.get_Range("S" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("T" + (row + 1).ToString()).Value = Convert.ToSingle(content[8].water);
                if (content[8].stream != "0")
                	eWorksheet.get_Range("U" + (row + 1).ToString()).Value = Convert.ToSingle(content[8].stream);
                else
                    eWorksheet.get_Range("U" + (row + 1).ToString()).Value = "";

                eWorksheet.get_Range("V" + (row + 1).ToString()).Value = Convert.ToSingle(content[9].water);
                if (content[9].stream.Contains('('))    //这两组数据,会出现下(入)和(出),因此要单独考虑
                {
                    int inFront = content[9].stream.IndexOf('(');
                    int inBack = content[9].stream.IndexOf(')');
                    int outFront = content[9].stream.LastIndexOf('(');
                    string streamIn = content[9].stream.Substring(0, inFront);
                    string streamOut = content[9].stream.Substring(inBack + 1, outFront - inBack - 1);
                    eWorksheet.get_Range("W" + (row + 1).ToString()).Value = Convert.ToSingle(streamOut);
                    eWorksheet.get_Range("X" + (row + 1).ToString()).Value = Convert.ToSingle(streamIn);
                }
                else
                {
                    eWorksheet.get_Range("W" + (row + 1).ToString()).Value = Convert.ToSingle(content[9].stream);
                }

                eWorksheet.get_Range("Y" + (row + 1).ToString()).Value = Convert.ToSingle(content[10].water);
                if (content[10].stream.Contains('('))
                {
                    int inFront = content[10].stream.IndexOf('(');
                    int inBack = content[10].stream.IndexOf(')');
                    int outFront = content[10].stream.LastIndexOf('(');
                    string streamIn = content[10].stream.Substring(0, inFront);
                    string streamOut = content[10].stream.Substring(inBack + 1, outFront - inBack - 1);
                    eWorksheet.get_Range("Z" + (row + 1).ToString()).Value = Convert.ToSingle(streamOut);
                    eWorksheet.get_Range("AA" + (row + 1).ToString()).Value = Convert.ToSingle(streamIn);
                }
                else
                {
                    eWorksheet.get_Range("Z" + (row + 1).ToString()).Value = Convert.ToSingle(content[10].stream);
                }



                eWorkbook.Save();
                ex.Quit();
                this.Focus();
                label4.Text = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + "记录完毕！";
                #endregion
            }
        }

        #region 其他杂项设置
        private int GetMonthFromYear(DateTime time) //获取农历数据中的月份
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

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible == false)
                {
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.Visible = false;
                    this.WindowState = FormWindowState.Minimized;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                notifyIcon1.ContextMenuStrip = contextMenuStrip2;
            }
        }

        private void 显示主窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.Focus();
            this.WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void 主窗体显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.Focus();
            this.WindowState = FormWindowState.Normal;
        }

        private void 打开Excel查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btOpenFile_Click(btOpenFile, e);
            打开Excel查看ToolStripMenuItem.Text = btOpenFile.Text;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void timer2_Tick(object sender, EventArgs e)    //计时器2
        {
            label4.Text = "上一次操作时间：" + DateTime.Now.ToShortTimeString();
            btRecorder_Click(btRecorder, e);
        }

        private void timer3_Tick(object sender, EventArgs e)    //计时器3
        {
            lbCountdown.Text = String.Format("{0:000}",(60 - (count % 60)));
            count++;
            
            if (DateTime.Now.Hour == 8 && DateTime.Now.Minute == 59 && DateTime.Now.Second == 30)  //最后时刻监测，若是还没有添加数据，则主动添加，并打开网页！
            {
                if (countRecorderDay == 0)
                {
                    btDownloadData_Click(btDownloadData, e);
                    System.Diagnostics.Process.Start("http://219.140.196.71/sq/data/sc.action?scid=cjh.sq");
                    timer1.Enabled = true;
                    timer2.Enabled = false;
                }
            }

            if (DateTime.Now.Hour == 20 && DateTime.Now.Minute == 59 && DateTime.Now.Second == 30)
            {
	            if (countRecorderNight == 0)
	            {
	                btDownloadData_Click(btDownloadData, e);
	                System.Diagnostics.Process.Start("http://219.140.196.71/sq/data/sc.action?scid=cjh.sq");
	                timer1.Enabled = true;
	                timer2.Enabled = false;
	            }
            }
            
            if (DateTime.Now.Hour == 10 && DateTime.Now.Minute == 30 && DateTime.Now.Second == 30)  //承接上面，若数据添加不全，则在一个半小时后再次添加！
            {
                btRefresh_Click(btRefresh, e);  //否则在执行20时的时候，此时网页还是8时的效果，因此还会加载一次！
                if (countRecorderDay == 0)
                {
                    btDownloadData_Click(btDownloadData, e);
                    System.Diagnostics.Process.Start("http://219.140.196.71/sq/data/sc.action?scid=cjh.sq");
                }
            }

            if (DateTime.Now.Hour == 22 && DateTime.Now.Minute == 30 && DateTime.Now.Second == 30)
            {
                btRefresh_Click(btRefresh, e);
	            if (countRecorderNight == 0)
	            {
	                btDownloadData_Click(btDownloadData, e);
	                System.Diagnostics.Process.Start("http://219.140.196.71/sq/data/sc.action?scid=cjh.sq");
	            }
            }
        }

    }
}

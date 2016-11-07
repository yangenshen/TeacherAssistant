using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherAssistant
{
    public partial class Report : Form
    {
        private Dictionary<string, int> Grade_Num;

        public Report(Dictionary<string, int> g_n)
        {
            Grade_Num = g_n;
            InitializeComponent();
            ShowData();
        }

        private void ShowData()
        {
            //详细
            double total = TeacherAssistant_Model.UserInfo.NumOfStu;
            int numOfUpper = 0;
            double proOfUpper;
            foreach (var item in Grade_Num)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.Key;
                dataGridView1.Rows[index].Cells[1].Value = item.Value;
                numOfUpper += item.Value;
                dataGridView1.Rows[index].Cells[2].Value = Math.Round(item.Value / total * 100, 2) + "%";
                dataGridView1.Rows[index].Cells[3].Value = numOfUpper;
                proOfUpper = Math.Round(numOfUpper / total * 100, 2);
                dataGridView1.Rows[index].Cells[4].Value = proOfUpper + "%";
                dataGridView1.Rows[index].Cells[5].Value = total - numOfUpper;
                dataGridView1.Rows[index].Cells[6].Value = (100 - proOfUpper) + "%";
            }

            //图表
            List<string> xData = new List<string>();
            List<int> yData = new List<int>();
            foreach(var g_n in Grade_Num)
            {
                xData.Add(g_n.Key);
                yData.Add(g_n.Value);
            }
            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);
        }
    }
}

using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System;
using System.IO;
using System.Collections.Generic;
using SchoolKiosk;

namespace Kiosk
{
    public partial class Main : Form
    {
        TextBox[] input_Nums = new TextBox[5];
        string resultInputNums = string.Empty;

        Timer screenTurnTimer = new Timer();
        List<string> students = new List<string>();
        List<string> checking_Students = new List<string>();
        int timerCount = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string studentNums = "{ " +
                    "\"test\": [ " +
                        "{ \"num\" : \"21101\" }, " +
                        "{ \"num\" : \"21102\" }, " +
                        "{ \"num\": \"21103\" }, " +
                        "{ \"num\": \"21104\" }, " +
                    "] " +
                "}";
            JObject jObject = JObject.Parse(studentNums);
            JToken jToken = jObject["test"];
            foreach (JToken members in jToken)
            {
                students.Add(members["num"].ToString());
            }

            input_Nums[0] = input_num0;
            input_Nums[1] = input_num1;
            input_Nums[2] = input_num2;
            input_Nums[3] = input_num3;
            input_Nums[4] = input_num4;

            this.but_1.Click += (sender2, e2) => { but_Click(sender2, e2, 1); };
            this.but_2.Click += (sender2, e2) => { but_Click(sender2, e2, 2); };
            this.but_3.Click += (sender2, e2) => { but_Click(sender2, e2, 3); };
            this.but_4.Click += (sender2, e2) => { but_Click(sender2, e2, 4); };
            this.but_5.Click += (sender2, e2) => { but_Click(sender2, e2, 5); };
            this.but_6.Click += (sender2, e2) => { but_Click(sender2, e2, 6); };
            this.but_7.Click += (sender2, e2) => { but_Click(sender2, e2, 7); };
            this.but_8.Click += (sender2, e2) => { but_Click(sender2, e2, 8); };
            this.but_9.Click += (sender2, e2) => { but_Click(sender2, e2, 9); };
            this.but_0.Click += (sender2, e2) => { but_Click(sender2, e2, 0); };
            this.but_Suc.Click += (sender2, e2) => { but_Click(sender2, e2, 10); };
            this.but_Back.Click += (sender2, e2) => { but_Click(sender2, e2, -1); };
        }

        private void but_Click(object sender, EventArgs e, int num)
        {
            if (num != 10 && num != -1 && resultInputNums.Length < 5) // 완료
            {
                resultInputNums += num.ToString();
                input_Nums[resultInputNums.Length - 1].Text = resultInputNums[resultInputNums.Length - 1].ToString();
            }
            else if (num == -1 && resultInputNums.Length > 0) // 지우기
            {
                resultInputNums = resultInputNums.Substring(0, resultInputNums.Length - 1);
                input_Nums[resultInputNums.Length].Text = "";
            }
            else if (num == 10 && resultInputNums.Length < 5)
            {
                MessageBox.Show("입력되지 않았습니다.");
            }
            else if (num == 10)
            {
                CheckClass();
            }
        }

        void CheckClass()
        {
            if (students.Contains(resultInputNums) && !checking_Students.Contains(resultInputNums))
            {
                checking_Students.Add(resultInputNums);
                checking_Students.Sort();

                panel_Screen2.Visible = true;
                label_timerCount.Text = (3 - timerCount).ToString();
                screenTurnTimer.Interval = 1000;
                screenTurnTimer.Tick += (sender, e) => timer_GoInitScene(sender, e);
                screenTurnTimer.Start();
            }
            else if(checking_Students.Contains(resultInputNums))
            {
                MessageBox.Show("이미 출석이 된 번호입니다.");
            }
            else
            {
                MessageBox.Show("올바르지 않은 번호입니다.");
            }
        }

        void timer_GoInitScene(object sender, EventArgs e)
        {
            label_timerCount.Text = (3 - timerCount).ToString();
            if(timerCount < 3)
            {
                timerCount++;
            }
            else
            {
                ResetSetting();
            }
        }

        private void panel_Screen2_Click(object sender, EventArgs e)
        {
            ResetSetting();
        }

        void ResetSetting()
        {
            screenTurnTimer.Stop();
            screenTurnTimer = new Timer();
            panel_Screen2.Visible = false;
            timerCount = 0;
            for (int i = 0; i < input_Nums.Length; i++)
            {
                input_Nums[i].Text = "";
            }
            resultInputNums = "";
        }

        private void but_nowAttentdance_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            for(int i = 0; i < checking_Students.Count; i++)
            {
                attendance.input_Attendance.Text += checking_Students[i] + "\r\n";
            }
            attendance.Show();
        }
    }
}

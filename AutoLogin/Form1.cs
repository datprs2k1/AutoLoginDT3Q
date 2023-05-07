using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLogin
{
    public partial class Form1 : Form
    {
        public List<Account> list = new List<Account>();
        public List<string> listDevice = new List<string>();
        public Bitmap LoiHeThong;
        public Form1()
        {
            InitializeComponent();

            FileStream file = new FileStream("Data/Account.txt", FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(file);

            list.Clear();

            string str;

            while ((str = sr.ReadLine()) != null)
            {
                string[] Account = str.Split('|');

                Account a = new Account();

                a.UserName = Account[0];
                a.Password = Account[1];

                list.Add(a);
            }

            sr.Close();
            file.Close();

            dtgData.AutoGenerateColumns = false;
            dtgData.DataSource = list;

            listDevice = KAutoHelper.ADBHelper.GetDevices();

            LoiHeThong = (Bitmap)Bitmap.FromFile("Data/loihethong.png");

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = listDevice.Select(x => new
            {
                Name = x
            }).ToList();
        }

        private void btnList1_Click(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                Auto();
            });
            t.Start();

            void Auto()
            {

                int i = -1;
                if (listDevice.Count > 0)
                {
                    listDevice.ForEach((x) =>
                    {

                        Task a = new Task(() =>
                        {
                            i++;
                            KAutoHelper.ADBHelper.TapByPercent(x, 51.0, 44.0);
                            KAutoHelper.ADBHelper.InputText(x, list[i].UserName.ToString());
                            KAutoHelper.ADBHelper.TapByPercent(x, 57.9, 52.3);
                            KAutoHelper.ADBHelper.InputText(x, list[i].Password.ToString());
                        });
                        a.RunSynchronously();

                    });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                Auto();
            });
            t.Start();

            void Auto()
            {
                int i = 8;
                if (listDevice.Count > 0)
                {
                    listDevice.ForEach((x) =>
                    {
                        Task a = new Task(() =>
                        {
                            KAutoHelper.ADBHelper.TapByPercent(x, 51.0, 44.0);
                            KAutoHelper.ADBHelper.InputText(x, list[i].UserName.ToString());
                            KAutoHelper.ADBHelper.TapByPercent(x, 57.9, 52.3);
                            KAutoHelper.ADBHelper.InputText(x, list[i].Password.ToString());
                        });
                        a.RunSynchronously();
                        i++;


                    });
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                Auto();
            });
            t.Start();

            void Auto()
            {
                int i = 16;
                if (listDevice.Count > 0)
                {
                    listDevice.ForEach((x) =>
                    {
                        Task a = new Task(() =>
                        {
                            KAutoHelper.ADBHelper.TapByPercent(x, 51.0, 44.0);
                            KAutoHelper.ADBHelper.InputText(x, list[i].UserName.ToString());
                            KAutoHelper.ADBHelper.TapByPercent(x, 57.9, 52.3);
                            KAutoHelper.ADBHelper.InputText(x, list[i].Password.ToString());
                        });
                        a.RunSynchronously();
                        i++;

                    });
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                Auto();
            });
            t.Start();

            void Auto()
            {
                int i = 24;
                if (listDevice.Count > 0)
                {
                    listDevice.ForEach((x) =>
                    {
                        Task a = new Task(() =>
                        {
                            KAutoHelper.ADBHelper.TapByPercent(x, 51.0, 44.0);
                            KAutoHelper.ADBHelper.InputText(x, list[i].UserName.ToString());
                            KAutoHelper.ADBHelper.TapByPercent(x, 57.9, 52.3);
                            KAutoHelper.ADBHelper.InputText(x, list[i].Password.ToString());
                        });
                        a.RunSynchronously();
                        i++;

                    });
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                Auto();
            });
            t.Start();

            void Auto()
            {
                int i = 16;
                if (listDevice.Count > 0)
                {
                    listDevice.ForEach((x) =>
                    {
                        Task a = new Task(() =>
                        {
                            KAutoHelper.ADBHelper.TapByPercent(x, 65.9, 67.2);
                            KAutoHelper.ADBHelper.Delay(1);
                            KAutoHelper.ADBHelper.TapByPercent(x, 52.7, 60.1);
                            KAutoHelper.ADBHelper.Delay(1);
                            KAutoHelper.ADBHelper.TapByPercent(x, 58.1, 84.2);
                            KAutoHelper.ADBHelper.Delay(1);
                            KAutoHelper.ADBHelper.TapByPercent(x, 47.0, 43.4);
                            KAutoHelper.ADBHelper.Delay(1);
                            KAutoHelper.ADBHelper.InputText(x, list[0].Password.ToString());
                        });
                        a.Start();
                        i++;

                    });
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listDevice = KAutoHelper.ADBHelper.GetDevices();
            dataGridView1.DataSource = listDevice.Select(x => new
            {
                Name = x
            }).ToList();

            dataGridView1.Refresh();
        }
    }
}

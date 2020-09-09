using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_work_1_computer_engineering
{
    public partial class Form1 : Form
    {
        int[] arr;
        int number = 0, Result = 0;
        double p = 8;
        public Form1()
        {
            arr = new int[6];
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (line.Text == "") //проверка на пустоту 
            {
                MessageBox.Show("Ошибка! Пвоторите ввод!");
            }
            else if (Convert.ToInt32(line.Text) > 99999 && Convert.ToInt32(line.Text) < 999999) //проверка на разрядность 
            {
                //разделение числа на цифры и заполнение массива
                number = Convert.ToInt32(line.Text);
                arr[0] = number / 100000;
                arr[1] = (number - arr[0] * 100000) / 10000;
                arr[2] = (number - arr[0] * 100000 - arr[1] * 10000) / 1000;
                arr[3] = (number - arr[0] * 100000 - arr[1] * 10000 - arr[2] * 1000) / 100;
                arr[4] = (number - arr[0] * 100000 - arr[1] * 10000 - arr[2] * 1000 - arr[3] * 100) / 10;
                arr[5] = (number - arr[0] * 100000 - arr[1] * 10000 - arr[2] * 1000 - arr[3] * 100 - arr[4] * 10);

                int j = 5;
                Result = 0;
                for (int i = 0; i < 6; i++) //применения формулы для перевода числа 
                {
                    Result += arr[i] * Convert.ToInt32(Math.Pow(p, j));
                    j--;
                }
                result.Text = Result.ToString(); //вывод результата 
            }
            else
                MessageBox.Show("Ошибка! Пвоторите ввод!");
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) // открытие диалогового окна
                return;
            string path = openFileDialog1.FileName;
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
            line.Text = reader.ReadString(); //считывание данных из файла
            reader.Close();
            MessageBox.Show("Файл успешно открыто");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            line.Text = ""; //функция очищения 
            result.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate));
            writer.Write(result.Text.ToString()); //запись результата в файл 
            writer.Close();
            MessageBox.Show("Файл успешно сохранено");
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dolgozok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Dolgozok> dolgozok = new List<Dolgozok>();
        int dolgozokszama = 0;
        string valasztott = "";
        int legfiatalabb = int.MaxValue;
        string legfnev = "";
        int legidosebb = 0;
        string leginev = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string[] sorok = File.ReadAllLines("dolgozok.txt");
            foreach (string s in sorok) { 
                string[] adatok = s.Split(';');
                Dolgozok dolg = new Dolgozok(adatok[0],adatok[1],adatok[2],adatok[3],adatok[4]);
                dolgozok.Add(dolg);
            }

            foreach (var dolg in dolgozok)
            {
                dataGridView1.Rows.Add(dolg.nev,dolg.kor,dolg.nem,dolg.pozicio,dolg.reszleg);

                if (!comboBox1.Items.Contains(dolg.reszleg)){
                    comboBox1.Items.Add(dolg.reszleg);

                }
                if (dolg.kor < legfiatalabb) {
                    legfiatalabb = dolg.kor;
                    legfnev = dolg.nev;
                }
                else if (dolg.kor > legidosebb) { 
                    legidosebb = dolg.kor;
                    leginev = dolg.nev;
                
                }

            }
            label3.Text = ($"A legfiatalabb dolgozó nev: {legfnev}, kora: {legfiatalabb}. A legidősebb dolgozó neve: {leginev}, kora: {legidosebb}.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in dolgozok)
            {
                if (item.reszleg == comboBox1.SelectedItem.ToString()) {
                    listBox1.Items.Add(item.nev);
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*foreach (var item in dolgozok) {
                if (item.nem == "Nő") {
                    dataGridView2.Rows.Add(item.nev,item.kor);
                }
            
            }*/
            foreach (var item in dolgozok)
            {
                if (item.nem == comboBox2.SelectedItem.ToString())
                {
                    dolgozokszama++;
                    valasztott = item.nem;
                    dataGridView2.Rows.Add(item.nev, item.kor);                    
                }
            }

            label2.Text = ($"{valasztott} dolgozok száma: {dolgozokszama} db.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in dolgozok)
            {
                if (item.nem == "Férfi")
                {
                    dataGridView3.Rows.Add(item.nev, item.kor);
                }

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            label2.Text = "";
            dolgozokszama = 0;
        }
    }
}

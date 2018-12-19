using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace LabTBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class AllPeople
        {
            public Person[] allp { get; set; }
        }

        List<Person> people = new List<Person>();
        string path = AppDomain.CurrentDomain.BaseDirectory + "book.json";

        private void Form1_Load(object sender, EventArgs e)
        { 
            if (!File.Exists(path)){
                File.Create(path);
            }
            people = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(path));
            for(int i = 0; i < people.Count(); i++)
            {
                listBox.Items.Add(people[i].FirstName);
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (tbFName.Text != "")
            {
                Person p = new Person();
                p.FirstName = tbFName.Text;
                p.Address = tbAddress.Text;
                p.City = tbCity.Text;
                p.State = tbState.Text;
                p.ZipCode = tbZipCode.Text;
                p.Email = tbEmail.Text;
                p.PhoneNumber = tbPNumber.Text;
                p.Info = tbInfo.Text;
                people.Add(p);
                listBox.Items.Add(p.FirstName);
                string serialize = JsonConvert.SerializeObject(people);
                File.WriteAllText(path, null);
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.UTF8.GetBytes(serialize);
                    fstream.Write(array, 0, array.Length);
                }
                tbFName.Text = "";
                tbAddress.Text = "";
                tbCity.Text = "";
                tbState.Text = "";
                tbZipCode.Text = "";
                tbEmail.Text = "";
                tbPNumber.Text = "";
                tbInfo.Text = "";
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                tbFName.Text = people[listBox.SelectedIndex].FirstName;
                tbAddress.Text = people[listBox.SelectedIndex].Address;
                tbCity.Text = people[listBox.SelectedIndex].City;
                tbState.Text = people[listBox.SelectedIndex].State;
                tbZipCode.Text = people[listBox.SelectedIndex].ZipCode;
                tbEmail.Text = people[listBox.SelectedIndex].Email;
                tbPNumber.Text = people[listBox.SelectedIndex].PhoneNumber;
                tbInfo.Text = people[listBox.SelectedIndex].Info;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                people[listBox.SelectedIndex].FirstName = tbFName.Text;
                people[listBox.SelectedIndex].Address = tbAddress.Text;
                people[listBox.SelectedIndex].City = tbCity.Text;
                people[listBox.SelectedIndex].State = tbState.Text;
                people[listBox.SelectedIndex].ZipCode = tbZipCode.Text;
                people[listBox.SelectedIndex].Email = tbEmail.Text;
                people[listBox.SelectedIndex].PhoneNumber = tbPNumber.Text;
                people[listBox.SelectedIndex].Info = tbInfo.Text;
                listBox.Items[listBox.SelectedIndex] = tbFName.Text;
                string serialize = JsonConvert.SerializeObject(people);
                File.WriteAllText(path, null);
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.UTF8.GetBytes(serialize);
                    fstream.Write(array, 0, array.Length);
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                int del = listBox.SelectedIndex;
                people.RemoveAt(del);
                listBox.Items.RemoveAt(del);
                string serialize = JsonConvert.SerializeObject(people);
                File.WriteAllText(path, null);
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.UTF8.GetBytes(serialize);
                    fstream.Write(array, 0, array.Length);
                }
                tbFName.Text = "";
                tbAddress.Text = "";
                tbCity.Text = "";
                tbState.Text = "";
                tbZipCode.Text = "";
                tbEmail.Text = "";
                tbPNumber.Text = "";
                tbInfo.Text = "";
            }
        }
    }



    public class Person
    {
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
    }
}

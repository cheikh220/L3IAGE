using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L3IAGE
{
    public partial class Form1 : Form
    {
        List<Personne> list = new List<Personne>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Personne personne = new Personne();

            personne.nom = txtNom.Text;
            personne.prenom = txtPrenom.Text;
            personne.tel = txtTel.Text;

            if (rbFemme.Checked)
            {
                personne.sexe = "Femme";
            }
            else {
                personne.sexe = "Homme";
            }
            string tempocomp = "";
            if (cbJAVA.Checked) {
                tempocomp += "JAVA ";
            }
            if (cbPHP.Checked)
            {
                tempocomp += "PHP ";
            }
            if (cbCsharp.Checked)
            {
                tempocomp += "Csharp ";
            }
            if (cbCplusplus.Checked)
            {
                tempocomp += "C++ ";
            }
            personne.competances = tempocomp;
            personne.classe = cmbClasse.Text;


            list.Add(personne);

            MessageBox.Show("donnees ajoute","Enregistrement ",MessageBoxButtons.OK, MessageBoxIcon.Information);


            refresh();

            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            effacer();
        }
        private void effacer()
        {
            txtNom.Text = String.Empty;
            txtPrenom.Text = String.Empty;
            txtTel.Text = String.Empty;

            rbFemme.Checked = false;
            rbHomme.Checked = false;

            cbCplusplus.Checked = false;
            cbCsharp.Checked = false;
            cbJAVA.Checked = false;
            cbPHP.Checked = false;

            cmbClasse.Text = "Selectionner";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            effacer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;  
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        Personne personneselected = null;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex < list.Count)
            {
                personneselected = list[e.RowIndex];
                txtNom.Text = personneselected.nom;
                txtPrenom.Text = personneselected.prenom;
                txtTel.Text = personneselected.tel;

                if(personneselected.sexe == "Femme")
                {
                    rbFemme.Checked = true;
                }
                else
                {
                    rbHomme.Checked = true;
                }
                string[] langue = personneselected.competances.Split();

                cbCplusplus.Checked = langue.Contains("C++");
                cbCsharp.Checked = langue.Contains("Csharp");
                cbJAVA.Checked = langue.Contains("JAVA");
                cbPHP.Checked = langue.Contains("PHP");
                cmbClasse.Text = personneselected.classe;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (personneselected == null) { 
                MessageBox.Show("verifier que vous avez selectionner","Avertissement",MessageBoxButtons.OK);
            }
            else
            {
               DialogResult result = MessageBox.Show("Voulez vous confirme la suppresion","Avertisement",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    list.Remove(personneselected);
                    refresh();
                    effacer();  
                }
            }

        }
        
        public void refresh()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int pos = list.IndexOf(personneselected);
            if (personneselected == null)
            {
                MessageBox.Show("verifier que vous avez selectionner", "Avertissement", MessageBoxButtons.OK);
            }
            else
            {
                personneselected.nom = txtNom.Text;
                personneselected.tel = txtTel.Text;
                personneselected.prenom = txtPrenom.Text;
                personneselected.sexe = (rbFemme.Checked) ? "Femme" : "Homme";

                string tempocomp = "";
                if (cbJAVA.Checked)
                {
                    tempocomp += "JAVA ";
                }
                if (cbPHP.Checked)
                {
                    tempocomp += "PHP ";
                }
                if (cbCsharp.Checked)
                {
                    tempocomp += "Csharp ";
                }
                if (cbCplusplus.Checked)
                {
                    tempocomp += "C++ ";
                }
                personneselected.competances = tempocomp;
                personneselected.classe = cmbClasse.Text;

                list[pos] = personneselected;
                refresh();
                effacer();

                
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}

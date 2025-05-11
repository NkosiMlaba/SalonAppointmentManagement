using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonAppointmentSystem
{
    public partial class GenderAndHairtypeForm : Form
    {
        private FormManager currentFormManager;
        private Client currentClient;
        private Appointment currentAppointment;
        
        public GenderAndHairtypeForm(FormManager formManager, Client client, Appointment appointment)
        {
            InitializeComponent();
            currentClient = client;
            currentAppointment = appointment;
            currentFormManager = formManager;

            DisableAllRowsExcept(tlpFemale, 0);
            DisableAllRowsExcept(tlpMale, 0);

            rdoFemale.Checked = true;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void rdoFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemale.Checked)
            {
                CenterGroupBox(grpFemale);
                grpFemale.Visible = true;
                grpFemale.Enabled = true;

                grpMale.Visible = false;
                grpMale.Enabled = false;
            }
            else
            {
                grpFemale.Visible = false;
                grpFemale.Enabled = false;
            }
        }

        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMale.Checked)
            {
                CenterGroupBox(grpMale);
                grpMale.Visible = true;
                grpMale.Enabled = true;

                grpFemale.Visible = false;
                grpFemale.Enabled = false;
            }
            else
            {
                grpMale.Visible = false;
                grpMale.Enabled = false;
            }
        }

        private void CenterGroupBox(GroupBox groupBox)
        {
            // Center horizontally and vertically within the form
            int x = (this.ClientSize.Width - groupBox.Width) / 2;
            int y = 100; // Do not change
            groupBox.Location = new Point(x, y);
        }

        private void DisableAllRowsExcept(TableLayoutPanel panel, int exceptionRow)
        {
            for (int row = 0; row < panel.RowCount; row++)
            {
                for (int col = 0; col < panel.ColumnCount; col++)
                {
                    PictureBox control = (PictureBox) panel.GetControlFromPosition(col, row);
                    if (control != null && control is Control)
                    {
                        if (row != exceptionRow)
                        {
                            control.Enabled = false;
                            //control.Visible = false;
                            control.BorderStyle = BorderStyle.None;

                        }
                        else
                        {
                            control.Enabled = true;
                            control.BorderStyle = BorderStyle.Fixed3D;
                            //control.Visible = true;
                        }
                    }
                }
            }
        }

        private void rdoFemaleStraight_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemaleStraight.Checked)
            {
                DisableAllRowsExcept(tlpFemale, 0);
            }
        }

        private void rdoFemaleWavy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemaleWavy.Checked)
            {
                DisableAllRowsExcept(tlpFemale, 1);
            }
        }

        private void rdoFemaleCurly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemaleCurly.Checked)
            {
                DisableAllRowsExcept(tlpFemale, 2);
            }
        }

        private void rdoFemaleCoily_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemaleCoily.Checked)
            {
                DisableAllRowsExcept(tlpFemale, 3);
            }
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox != null)
            {
                DialogResult dialogResult;
                switch (clickedPictureBox.Name)
                {
                    case "picFemaleCoilyA":
                        dialogResult = MessageBox.Show("Female Coily A Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Coily Type A";
                        }
                        break;
                    case "picFemaleCoilyB":
                        dialogResult = MessageBox.Show("Female Coily B Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Coily Type B";
                        }
                        break;
                    case "picFemaleCoilyC":
                        dialogResult = MessageBox.Show("Female Coily C Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Coily Type C";
                        }
                        break;
                    case "picFemaleStraightA":
                        dialogResult = MessageBox.Show("Female Straight A Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Straight Type A";
                        }
                        break;
                    case "picFemaleStraightB":
                        dialogResult = MessageBox.Show("Female Straight B Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Straight Type B";
                        }
                        break;
                    case "picFemaleStraightC":
                        dialogResult = MessageBox.Show("Female Straight C Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Straight Type C";
                        }
                        break;
                    case "picFemaleCurlyA":
                        dialogResult = MessageBox.Show("Female Curly A Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Curly Type A";
                        }
                        break;
                    case "picFemaleCurlyB":
                        dialogResult = MessageBox.Show("Female Curly B Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Curly Type B";
                        }
                        break;
                    case "picFemaleCurlyC":
                        dialogResult = MessageBox.Show("Female Curly C Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Curly Type C";
                        }
                        break;
                    case "picFemaleWavyA":
                        dialogResult = MessageBox.Show("Female Wavy A Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Wavy Type A";
                        }
                        break;
                    case "picFemaleWavyB":
                        dialogResult = MessageBox.Show("Female Wavy B Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Wavy Type B";
                        }
                        break;
                    case "picFemaleWavyC":
                        dialogResult = MessageBox.Show("Female Wavy C Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Female";
                            currentClient.HairType = "Wavy Type C";
                        }
                        break;
                    // males
                    case "picMaleCoilyA":
                        dialogResult = MessageBox.Show("Male Coily A Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Coily Type A";
                        }
                        break;
                    case "picMaleCoilyB":
                        dialogResult = MessageBox.Show("Male Coily B Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Coily Type B";
                        }
                        break;
                    case "picMaleCoilyC":
                        dialogResult = MessageBox.Show("Male Coily C Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Coily Type C";
                        }
                        break;
                    case "picMaleStraightA":
                        dialogResult = MessageBox.Show("Male Straight A Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Straight Type A";
                        }
                        break;
                    case "picMaleStraightB":
                        dialogResult = MessageBox.Show("Male Straight B Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Straight Type B";
                        }
                        break;
                    case "picMaleStraightC":
                        dialogResult = MessageBox.Show("Male Straight C Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Straight Type C";
                        }
                        break;
                    case "picMaleCurlyA":
                        dialogResult = MessageBox.Show("Male Curly A Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Curly Type A";
                        }
                        break;
                    case "picMaleCurlyB":
                        dialogResult = MessageBox.Show("Male Curly B Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Curly Type B";
                        }
                        break;
                    case "picMaleCurlyC":
                        dialogResult = MessageBox.Show("Male Curly C Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Curly Type C";
                        }
                        break;
                    case "picMaleWavyA":
                        dialogResult = MessageBox.Show("Male Wavy A Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Wavy Type A";
                        }
                        break;
                    case "picMaleWavyB":
                        dialogResult = MessageBox.Show("Male Wavy B Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Wavy Type B";
                        }
                        break;
                    case "picMaleWavyC":
                        dialogResult = MessageBox.Show("Male Wavy C Hair Selected, Press Yes to confirm as you hairtype", "Confirm Hair Type", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogResult)
                        {
                            currentClient.Gender = "Male";
                            currentClient.HairType = "Wavy Type C";
                        }
                        break;
                    default:
                        // Handle cases where the clicked PictureBox is not recognized
                        MessageBox.Show("Unknown PictureBox clicked.");
                        break;
                }
            }
        }

        private void StoreUserInDatabase()
        {
            if (currentClient.IsGuest == true) return;

            DatabaseManager database = new DatabaseManager();
            database.InsertCustomer(currentClient.Email, currentClient.Password, currentClient.Name, currentClient.Surname, currentClient.HairType, currentClient.Gender);
        }

        private void OpenClientDashboardForm()
        {
            currentFormManager.ShowForm(currentFormManager.clientDashboardForm, this);
        } 

        private void CheckAndStoreUser()
        {
            if (currentClient.HairType != null && currentClient.Gender != null)
            {
                StoreUserInDatabase();
                OpenClientDashboardForm();

            }
        }

        private void picFemaleStraightA_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleStraightB_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleStraightC_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleWavyA_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleWavyB_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleWavyC_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleCurlyA_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleCurlyB_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleCurlyC_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleCoilyA_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleCoilyB_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picFemaleCoilyC_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void rdoMaleStraight_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMaleStraight.Checked)
            {
                DisableAllRowsExcept(tlpMale, 0);
            }
        }

        private void rdoMaleWavy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMaleWavy.Checked)
            {
                DisableAllRowsExcept(tlpMale, 1);
            }
        }

        private void rdoMaleCurly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMaleCurly.Checked)
            {
                DisableAllRowsExcept(tlpMale, 2);
            }
        }

        private void rdoMaleCoily_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMaleCoily.Checked)
            {
                DisableAllRowsExcept(tlpMale, 3);
            }
        }

        private void picMaleStraightA_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleStraightB_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleStraightC_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleWavyA_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleWavyB_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleWavyC_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleCurlyA_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleCurlyB_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleCurlyC_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleCoilyA_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleCoilyB_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void picMaleCoilyC_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
            CheckAndStoreUser();
        }

        private void GenderAndHairtypeForm_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Current User: \n" + currentClient.ToString();

            
        }
    }
}

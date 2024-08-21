using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lam_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormA());
            Home.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormB());
            Home.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormC());
            Home.Text = button3.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            Home.Text = "Home";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void OK_Click_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            //if (progressBar1.Value == progressBar1.Minimum)
            //{
            //    timer1.Stop();
            //    MessageBox.Show("Đã chạy xong!!!");
            //    progressBar1.Value = progressBar1.Minimum;
            //    this.lblTienDo.Text = "0 %";
            //}
            if(progressBar1.Value==progressBar1.Minimum)
            {
                progressBar1.PerformStep();
                this.lblTienDo.Text = progressBar1.Value.ToString() + " %";
            }else
            {
                timer1.Stop();
                MessageBox.Show("Đã chạy xong!!!");
                progressBar1.Value = progressBar1.Minimum;
                this.lblTienDo.Text = "0 %";
            }

        }

        private void Cancel_Click_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void ChoseDay_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = "Welcome: " + this.textBox1.Text + "\n";
            if (radioButton1.Checked == true) str += "Giới tính: Nam\n";
            else str += "Giới tính: Nữ\n";
            if (comboBox1.SelectedItem != null) str += "Môn học: " + this.comboBox1.SelectedItem.ToString();
            else
            {
                MessageBox.Show("Thí sinh không chọn khóa học");
                return;
            }
            if (dateTimePicker1.Text == null)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.");
                return; // Ngừng xử lý nếu không có ngày sinh
            }
            else
            {
                str += "\nNgày sinh: " + dateTimePicker1.Text.ToString();
            }
            MessageBox.Show(str);
        }
       
        private void Image_Click(object sender, EventArgs e)
        {

        }
        private void lblMSSV_Click(object sender, EventArgs e)
        {

        }

        private void btnMSSV_Click(object sender, EventArgs e)
        {
            ListViewItem lv = new ListViewItem(txtMSSV.Text);
            //Thêm các ô tiếp
            lv.SubItems.Add(txtTen.Text);
            lv.SubItems.Add(txtLop.Text);
            lv.SubItems.Add(txtGT.Text);
            LvDanhSach.Items.Add(lv);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (LvDanhSach.SelectedItems.Count > 0)
            {
                LvDanhSach.Items.Remove(LvDanhSach.SelectedItems[0]);
                MessageBox.Show("Đã xóa một dòng");
            }
            else
            {
                MessageBox.Show("Không có ai trong danh sách", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (LvDanhSach.SelectedItems.Count > 0)
            {
                ListViewItem lv = LvDanhSach.SelectedItems[0];
                lv.SubItems[0].Text = txtMSSV.Text;
                lv.SubItems[1].Text = txtTen.Text;
                lv.SubItems[2].Text = txtLop.Text;
                lv.SubItems[3].Text = txtGT.Text;
            }
            else
            {
                MessageBox.Show("Không có ai trong danh sách", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LvDanhSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (LvDanhSach.SelectedItems.Count > 0)
            {
                ListViewItem lv = LvDanhSach.SelectedItems[0];
                txtMSSV.Text = lv.SubItems[0].Text;
                txtTen.Text = lv.SubItems[1].Text;
                txtLop.Text = lv.SubItems[2].Text;
                txtGT.Text = lv.SubItems[3].Text;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            picOff.Visible = false;
            picOn.Visible = true;
            btnOnOff.Text = "Switch!";
        }
        int so = 1;
        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if(so==1)
            {
                picOff.Visible = true;
                picOn.Visible = false;
                btnOnOff.Text = "Đổi qua con hươu";
                so = 0;
            }    else
            {
                picOff.Visible = false;
                picOn.Visible = true;
                btnOnOff.Text = "Đổi qua con mèo";
                so = 1;
            }    
        }

        private void lblTienDo_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= imlDemo.Images.Count; i++)
            {
                ccbChonHinh.Items.Add("Hình " + i);
            }
        }

        private void ccbChonHinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbHinhAnh.Image = imlDemo.Images[ccbChonHinh.SelectedIndex];
        }

        private void frmTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
                TreeNode rNode, cNode;
                rNode = this.treeView1.Nodes.Add("Các loại hoa");
                rNode.ImageIndex = 0;
                cNode = new TreeNode("Hoa Lan");
                cNode.ImageIndex = 1;
                rNode.Nodes.Add(cNode);
                cNode = new TreeNode("Hoa Hồng", 2, 2);
                rNode.Nodes.Add(cNode);
                rNode = this.treeView1.Nodes.Add("Trái Cây");
                rNode.ImageIndex = 2;
                cNode = new TreeNode("Trái Xoài");
                cNode.ImageIndex = 3;
                rNode.Nodes.Add(cNode);
                cNode = new TreeNode("Trái Mít");
                cNode.ImageIndex = 4;
                rNode.Nodes.Add(cNode);
          
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void lblPassWord_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show(textBox2.Text,"Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel= true;
                textBox2.Focus();
                errorProvider1.SetError(textBox2, "Please enter your username!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, null);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show(textBox2.Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

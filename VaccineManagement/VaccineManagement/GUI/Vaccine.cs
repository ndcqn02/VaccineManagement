using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaccineManagement.BLL;
using VaccineManagement.DTO;

namespace VaccineManagement.GUI
{
    public partial class Vaccine : Form
    {

        private VaccineBLL vaccineBLL = new VaccineBLL();
        private VaccineDTO vaccineDTO = new VaccineDTO();

        public Vaccine()
        {
            InitializeComponent();
            vaccineBLL.HienThi(grvVaccine);
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaVaccine.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                vaccineDTO.MaVaccine = txtMaVaccine.Text;
                vaccineDTO.TenVaccine = txtTenVaccine.Text;
                vaccineDTO.NgaySX = txtNSX.Text;
                vaccineDTO.NgayHetHan = txtNHH.Text;
                vaccineDTO.MaDM= txtMaDM.Text;
           
                //gọi BLL thực hiện
                vaccineBLL.Them(vaccineDTO);
                //hiện lên dgv
                vaccineBLL.HienThi(grvVaccine);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaVaccine.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                vaccineDTO.MaVaccine = txtMaVaccine.Text;
                vaccineDTO.TenVaccine = txtTenVaccine.Text;
                vaccineDTO.NgaySX = txtNSX.Text;
                vaccineDTO.NgayHetHan = txtNHH.Text;
                vaccineDTO.MaDM = txtMaDM.Text;

                //gọi BLL thực hiện
                vaccineBLL.Sua(vaccineDTO);
                //hiện lên dgv
                vaccineBLL.HienThi(grvVaccine);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaVaccine.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                string MaVaccine = txtMaVaccine.Text;

                //gọi BLL thực hiện
                vaccineBLL.Xoa(MaVaccine);
                //hiện lên dgv
                vaccineBLL.HienThi(grvVaccine);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
            if (txtMaVaccine.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                vaccineDTO.MaVaccine = txtMaVaccine.Text;
                //gọi BLL thực hiện
                var vaccineTim = vaccineBLL.TimKiem2(vaccineDTO, grvVaccine);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (vaccineTim != null)
                {
                    txtMaVaccine.Text = vaccineTim.MaVaccine;
                    txtTenVaccine.Text = vaccineTim.TenVaccine;
                    txtNSX.Text = vaccineTim.NgaySX;
                    txtNHH.Text = vaccineTim.NgayHetHan;
                    txtMaDM.Text = vaccineTim.MaDM;
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMaVaccine.Text = txtTenVaccine.Text = txtNSX.Text = txtNHH.Text
                    = txtMaDM.Text = string.Empty;
                }
            }
        }
    }
}

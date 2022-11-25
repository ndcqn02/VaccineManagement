using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VaccineManagement.DTO;

namespace VaccineManagement.BLL
{
    class VaccineBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        private string fileName = "../../tb_Vaccine.xml";

        public VaccineBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 5;

            XmlNodeList ds = root.SelectNodes("vaccine");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaVC").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenVC").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("ngaySX").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("NgayHetHan").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("MaDM").InnerText;
                sd++;
            }
        }



        public void Them(VaccineDTO vaccine)
        {
            //tạo nút vaccine
            XmlNode vc = doc.CreateElement("vaccine");

            //tạo nút con của khách hàng là maVaccine
            XmlElement maVaccine = doc.CreateElement("MaVC");
            maVaccine.InnerText = vaccine.MaVaccine;//gán giá trị cho maVaccine
            vc.AppendChild(maVaccine);//thêm maVaccine vào trong vaccine

            XmlElement tenVC = doc.CreateElement("TenVC");
            tenVC.InnerText = vaccine.TenVaccine;
            vc.AppendChild(tenVC);   

            XmlElement ngaySX = doc.CreateElement("ngaySX");
            ngaySX.InnerText = vaccine.NgaySX.ToString();
            vc.AppendChild(ngaySX);

            XmlElement NgayHetHan = doc.CreateElement("NgayHetHan");
            NgayHetHan.InnerText = vaccine.NgayHetHan;
            vc.AppendChild(NgayHetHan);

            XmlElement maDM = doc.CreateElement("MaDM");
            maDM.InnerText = vaccine.MaDM.ToString();
            vc.AppendChild(maDM);
          
            //thêm vaccine vào gốc root
            root.AppendChild(vc);
            doc.Save(fileName);//lưu dữ liệu
        }


        public void Sua(VaccineDTO vaccine)
        {
            //lấy vị trí cần sửa theo mã kh cũ đưa vào
            XmlNode vaccineCu = root.SelectSingleNode("vaccine[MaVC='" + vaccine.MaVaccine + "']");
            if (vaccineCu != null)
            {
                XmlNode vc = doc.CreateElement("vaccine");
                
                XmlElement maVaccine = doc.CreateElement("MaVC");
                maVaccine.InnerText = vaccine.MaVaccine;//gán giá trị cho maVaccine
                vc.AppendChild(maVaccine);//thêm maVaccine vào trong vaccine

                XmlElement tenVC = doc.CreateElement("TenVC");
                tenVC.InnerText = vaccine.TenVaccine;
                vc.AppendChild(tenVC);

                XmlElement ngaySX = doc.CreateElement("ngaySX");
                ngaySX.InnerText = vaccine.NgaySX.ToString();
                vc.AppendChild(ngaySX);

                XmlElement NgayHetHan = doc.CreateElement("NgayHetHan");
                NgayHetHan.InnerText = vaccine.NgayHetHan;
                vc.AppendChild(NgayHetHan);

                XmlElement maDM = doc.CreateElement("MaDM");
                maDM.InnerText = vaccine.MaDM.ToString();
                vc.AppendChild(maDM);

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(vc, vaccineCu);
                doc.Save(fileName);//lưu lại
            }
        }

        public void Xoa(string MaVaccine)
        {
            XmlNode vaccineXoa = root.SelectSingleNode("vaccine[MaVC ='" + MaVaccine + "']");
            if (vaccineXoa != null)
            {
                root.RemoveChild(vaccineXoa);

                doc.Save(fileName);
            }
        }

        public void TimKiem(VaccineDTO vaccine, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode vaccineTim = root.SelectSingleNode("vaccine[MaVC ='" + vaccine.MaVaccine + "']");
            
            if (vaccineTim != null)
            {
                MessageBox.Show("vao day roi nha");
                dgv.ColumnCount = 5;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = vaccineTim.SelectSingleNode("MaVC").InnerText;
                dgv.Rows[0].Cells[1].Value = vaccineTim.SelectSingleNode("TenVC").InnerText;
                dgv.Rows[0].Cells[2].Value = vaccineTim.SelectSingleNode("ngaySX").InnerText;
                dgv.Rows[0].Cells[3].Value = vaccineTim.SelectSingleNode("NgayHetHan").InnerText;
                dgv.Rows[0].Cells[4].Value = vaccineTim.SelectSingleNode("MaDM").InnerText;
               
            }
            
        }

        public VaccineDTO TimKiem2(VaccineDTO vaccine, DataGridView dgv)
        {

            VaccineDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode vaccinTim = root.SelectSingleNode("vaccine[MaVC='" + vaccine.MaVaccine + "']");

            if (vaccinTim != null)
            {

                dgv.ColumnCount = 5;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = vaccinTim.SelectSingleNode("MaVC").InnerText;
                dgv.Rows[0].Cells[1].Value = vaccinTim.SelectSingleNode("TenVC").InnerText;
                dgv.Rows[0].Cells[2].Value = vaccinTim.SelectSingleNode("ngaySX").InnerText;
                dgv.Rows[0].Cells[3].Value = vaccinTim.SelectSingleNode("NgayHetHan").InnerText;
                dgv.Rows[0].Cells[4].Value = vaccinTim.SelectSingleNode("MaDM").InnerText;
            

                ketQua = new VaccineDTO();

                ketQua.MaVaccine = vaccinTim.SelectSingleNode("MaVC").InnerText;
                ketQua.TenVaccine = vaccinTim.SelectSingleNode("TenVC").InnerText;
                ketQua.NgaySX = vaccinTim.SelectSingleNode("ngaySX").InnerText;
                ketQua.NgayHetHan = vaccinTim.SelectSingleNode("NgayHetHan").InnerText;
                ketQua.MaDM = vaccinTim.SelectSingleNode("MaDM").InnerText;

            }
            return ketQua;

        }



    }
}

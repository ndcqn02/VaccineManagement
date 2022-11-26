using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccine.DTO
{
    class VaccineDTO
    {
        private string maVaccine, tenVaccine, ngaySX, ngayHetHan, soLuong, giaTien, maDM;


        public VaccineDTO()
        {

        }

        public VaccineDTO(string maVaccine, string tenVaccine, string ngaySX, string ngayHetHan, string soLuong, string giaTien, string maDM)
        {
            this.maVaccine = maVaccine;
            this.tenVaccine = tenVaccine;
            this.ngaySX = ngaySX;
            this.ngayHetHan = ngayHetHan;
            this.soLuong = soLuong;
            this.giaTien = giaTien;
            this.maDM = maDM;
        }

        public string MaVaccine { get => maVaccine; set => maVaccine = value; }
        public string TenVaccine { get => tenVaccine; set => tenVaccine = value; }
        public string NgaySX { get => ngaySX; set => ngaySX = value; }
        public string NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string GiaTien { get => giaTien; set => giaTien = value; }
        public string MaDM { get => maDM; set => maDM = value; }
    }
}

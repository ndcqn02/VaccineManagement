using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineManagement.DTO
{
    class VaccineDTO
    {
        private string maVaccine, tenVaccine, ngaySX, ngayHetHan, maDM;


        public VaccineDTO()
        {

        }

        public VaccineDTO(string maVaccine, string tenVaccine, string ngaySX, string ngayHetHan, string maDM)
        {
            this.MaVaccine = maVaccine;
            this.TenVaccine = tenVaccine;
            this.NgaySX = ngaySX;
            this.NgayHetHan = ngayHetHan;
            this.MaDM = maDM;
        }

        public string MaVaccine { get => maVaccine; set => maVaccine = value; }
        public string TenVaccine { get => tenVaccine; set => tenVaccine = value; }
        public string NgaySX { get => ngaySX; set => ngaySX = value; }
        public string NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public string MaDM { get => maDM; set => maDM = value; }
    }
}

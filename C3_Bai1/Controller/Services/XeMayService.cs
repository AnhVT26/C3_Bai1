using C3_Bai1.Controller.Repositories;
using C3_Bai1.Model.Context.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Bai1.Controller.Services
{
    internal class XeMayService
    {
        XeMayRepository _repos;
        public XeMayService()
        {
            _repos = new();
        }
        public void ThemXeMay(XeMay obj)
        {
            if (_repos.AddXeMay(obj) == true)
            {
                MessageBox.Show("Them thanh cong");
            }
            else
            {
                MessageBox.Show("Them that bai");
            }
        }

        public void XoaXeMay(Guid id)
        {
            if (_repos.DeleteXeMay(id))
            {
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa that bai");
            }
        }
        public List<XeMay> GetXeMays(string input)
        {
            return _repos.GetXeMays(input);
        }
        //public List<XeMay> GetAllXe()
        //{
        //    return _repos.GetAllXe();
        //}
    }
}

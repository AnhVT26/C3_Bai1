using C3_Bai1.Model.Context;
using C3_Bai1.Model.Context.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Bai1.Controller.Repositories
{
    internal class XeMayRepository
    {
        DBContext _context;
        public XeMayRepository()
        {
            _context = new();
        }
        public List<XeMay> GetXeMays(string search)
        {
            if (search == null)
            {
                return _context.XeMays.ToList();
            }
            return _context.XeMays.Where(x => x.Ten.Contains(search)).ToList();
        }
        //public List<XeMay> GetAllXe()
        //{
        //    return _context.XeMays.ToList();
        //}
        public bool AddXeMay(XeMay x)
        {
            if (x == null)
            {
                return false;
            }
            x.Id = Guid.NewGuid();
            _context.Add(x);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteXeMay(Guid id)
        {
            var xexoa = _context.XeMays.FirstOrDefault(x => x.Id == id);
            if (xexoa == null)
            {
                return false;
            }
            _context.Remove(xexoa);
            _context.SaveChanges();
            return true;
        }
    }
}

using PraktikPortalWebApi.EfCore;

namespace PraktikPortalWebApi.Models
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }
        // GET students
        public List<StudentModel> GetStudents()
        {
            List<StudentModel> response = new List<StudentModel>();
            var dataList = _context.Students.ToList();
            dataList.ForEach(row => response.Add(new StudentModel()
            {
                id = row.id,
                name = row.name,
                username = row.username,
                password = row.password
            }));
            return response;
        }

        // GET student
        public StudentModel GetStudentById(int id)
        {
            StudentModel response = new StudentModel();
            var row = _context.Students.Where(s => s.id.Equals(id)).FirstOrDefault();
            return new StudentModel()
            {
                id = row.id,
                name = row.name,
                username = row.username,
                password = row.password
            };
          
        }

        // GET internships
        public List<InternshipModel> GetInternships()
        {
            List<InternshipModel> response = new List<InternshipModel>();
            var dataList = _context.Internships.ToList();
            System.Diagnostics.Debug.WriteLine("!!!!!!!!!!");
            foreach (var internship in dataList)
            {
                System.Diagnostics.Debug.WriteLine(internship.InternshipName, internship.Student.name);
            }
            System.Diagnostics.Debug.WriteLine("!!!!!!!!!!");
            dataList.ForEach(row => response.Add(new InternshipModel()
            {
                InternshipId = row.InternshipId,
                InternshipName = row.InternshipName,
                InternshipCompany = row.InternshipCompany,
                Status = row.Status
            }));
            return response;
        }

        // GET internship
        public InternshipModel GetInternshipById(int id)
        {
            InternshipModel response = new InternshipModel();
            var row = _context.Internships.Where( s=> s.InternshipId.Equals(id)).FirstOrDefault();
            return new InternshipModel()
            {
                InternshipId = row.InternshipId,
                InternshipName = row.InternshipName,
                InternshipCompany = row.InternshipCompany,
                Status = row.Status,
                StudentId = row.Student.id
            };
        }

        /// <summary>
        /// it servers the post/put/patch
        /// </summary>
        //public void saveorder(ordermodel ordermodel)
        //{
        //    order dbtable = new order();
        //    if (ordermodel.id > 0)
        //    {
        //        put
        //       dbtable = _context.orders.where(d => d.id.equals(ordermodel.id)).firstordefault();
        //        if (dbtable != null)
        //        {
        //            dbtable.phone = ordermodel.phone;
        //            dbtable.address = ordermodel.address;
        //        }
        //    }
        //    else
        //    {
        //        post
        //        dbtable.phone = ordermodel.phone;
        //        dbtable.address = ordermodel.address;
        //        dbtable.name = ordermodel.name;
        //        dbtable.product = _context.products.where(f => f.id.equals(ordermodel.product_id)).firstordefault();
        //        _context.orders.add(dbtable);
        //    }
        //    _context.savechanges();
        //}

        //public void DeleteOrder(int id)
        //{
        //    var order = _context.Orders.Where(d => d.id == id).FirstOrDefault();
        //    if (order != null)
        //    {
        //        _context.Orders.Remove(order);
        //        _context.SaveChanges();
        //    }
        //}
    }
}

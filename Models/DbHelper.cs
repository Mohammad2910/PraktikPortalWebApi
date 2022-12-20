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
        // GET users
        public List<UserModel> GetUsers()
        {
            List<UserModel> response = new List<UserModel>();
            var dataList = _context.Users.ToList();
            dataList.ForEach(row => response.Add(new UserModel()
            {
                id = row.id,
                name = row.name,
                username = row.username,
                password = row.password,
                email = row.email,
                type = row.type
            }));
            return response;
        }

        // GET user
        public UserModel GetUserById(int id)
        {
            UserModel response = new UserModel();
            var row = _context.Users.Where(s => s.id.Equals(id)).FirstOrDefault();
            return new UserModel()
            {
                id = row.id,
                name = row.name,
                username = row.username,
                password = row.password,
                email = row.email,
                type = row.type
            };
          
        }

        public UserModel GetUserByUsername(string username)
        {
            UserModel response = new UserModel();
            var row = _context.Users.Where(s => s.username.Equals(username)).FirstOrDefault();
            return new UserModel()
            {
                id = row.id,
                name = row.name,
                username = row.username,
                password = row.password,
                email = row.email,
                type = row.type
            };
        }

        // GET internships
        public List<InternshipModel> GetInternships()
        {
            List<InternshipModel> response = new List<InternshipModel>();
            var dataList = _context.Internships.ToList();
            dataList.ForEach(row => response.Add(new InternshipModel()
            {
                InternshipId = row.InternshipId,
                InternshipName = row.InternshipName,
                InternshipCompany = row.InternshipCompany,
                Status = row.Status,
                user_id = row.user_id,
                DTUSupervisor_id = row.DTUSupervisor_id,
                CompanySupervisor_id = row.CompanySupervisor_id
            }));
            return response;
        }

        // GET internship by internship id
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
                user_id = row.user_id,
                DTUSupervisor_id = row.DTUSupervisor_id,
                CompanySupervisor_id = row.CompanySupervisor_id
            };
        }

        // GET internship by user id and user id type
        public List<InternshipModel> GetInternshipByUserIdAndIdType(int id, string user_type)
        {
            List<InternshipModel> response = new List<InternshipModel>();
            // var dataList = _context.Internships.ToList();
            List<Internship> dataList = null;
            if (user_type.Equals("user_id"))
            {
                dataList = _context.Internships.Where(s => s.user_id.Equals(id)).ToList();
            } else if (user_type.Equals("DTUSupervisor_id"))
            {
                dataList = _context.Internships.Where(s => s.DTUSupervisor_id.Equals(id)).ToList();
            } else if (user_type.Equals("CompanySupervisor_id"))
            {
                dataList = _context.Internships.Where(s => s.CompanySupervisor_id.Equals(id)).ToList();
            }

            dataList.ForEach(row => response.Add(new InternshipModel()
            {
                InternshipId = row.InternshipId,
                InternshipName = row.InternshipName,
                InternshipCompany = row.InternshipCompany,
                Status = row.Status,
                user_id = row.user_id,
                DTUSupervisor_id = row.DTUSupervisor_id,
                CompanySupervisor_id = row.CompanySupervisor_id
            }));
            return response;
        }

        /// <summary>
        /// it servers the post/put/patch
        /// </summary>
        public void saveUser(UserModel user)
        {
            User userTable = new User();
            System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!");
            System.Diagnostics.Debug.WriteLine(user.id);
            System.Diagnostics.Debug.WriteLine(user.id);
            if (user.id > 0)
            {
                // PUT
                userTable = _context.Users.Where(d => d.id.Equals(user.id)).FirstOrDefault();
                if (userTable != null)
                {
                    userTable.name = user.name;
                    userTable.username = user.username;
                    userTable.password = user.password;
                    userTable.email = user.email;
                }
            }
            else
            {
                // POST
                userTable.name = user.name;
                userTable.username = user.username;
                userTable.password = user.password;
                userTable.email = user.email;
                userTable.type = user.type;
                _context.Users.Add(userTable);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// it servers the post/put/patch
        /// </summary>
        public void saveInternship(InternshipModel internship)
        {
            Internship internshipTable = new Internship();
            if (internship.InternshipId > 0)
            {
                // PUT
                internshipTable = _context.Internships.Where(d => d.InternshipId.Equals(internship.InternshipId)).FirstOrDefault();
                if (internshipTable != null)
                {
                    internshipTable.InternshipName = internship.InternshipName;
                    internshipTable.InternshipCompany = internship.InternshipCompany;
                    internshipTable.Status = internship.Status;
                    internshipTable.user_id = internship.user_id;
                    internshipTable.DTUSupervisor_id = internship.DTUSupervisor_id;
                    internshipTable.CompanySupervisor_id = internship.CompanySupervisor_id;
                }
            }
            else
            {
                // POST
                
                internshipTable.InternshipName = internship.InternshipName;
                internshipTable.InternshipCompany = internship.InternshipCompany;
                internshipTable.Status = internship.Status;
                internshipTable.user_id = internship.user_id;
                internshipTable.DTUSupervisor_id = internship.DTUSupervisor_id;
                internshipTable.CompanySupervisor_id = internship.CompanySupervisor_id;
                _context.Internships.Add(internshipTable);
            }
            _context.SaveChanges();
        }

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

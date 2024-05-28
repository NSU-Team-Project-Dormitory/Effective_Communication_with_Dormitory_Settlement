
using System.ComponentModel.Design;
using System.Drawing;
using System.Security.Cryptography;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.Campus;


namespace Data.Repositories.SideInformation
{
    public class StudentGroupRepository : IStudentGroupRepository
    {
        private static StudentGroupRepository? studentGroupRepository = null;
        private StudentGroupRepository() { }
        public static StudentGroupRepository GetRepository()
        {
            return studentGroupRepository ??= new StudentGroupRepository();
        }

        public string Add(int id, string faculcy)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var existingGroup = db.StudentGroup.FirstOrDefault(g => g.ID == id);
                if (existingGroup != null)
                {
                    return "Group already exists";
                }

                StudentGroup studentGroup = new StudentGroup(id, faculcy);

                db.StudentGroup.Add(studentGroup);
                db.SaveChanges();

                return "Done";
            }
        }



        public string Delete(StudentGroup group)
        {
            string result = "This group doesn't exist";

            using (ApplicationDbContext db = new())
            {
                db.StudentGroup.Remove(group);
                db.SaveChanges();
                result = "Done. Group: " + group.ID + " has been removed";
            }
            return result;
        }

        public StudentGroup GetGroup(int id, string faculcy)
        {
            using (ApplicationDbContext db = new())
            {
                var existingGroup = db.StudentGroup.FirstOrDefault(r => r.ID == id);
                if (existingGroup != null)
                {
                    return existingGroup;
                }


                StudentGroup studentGroup = new StudentGroup(id, faculcy);

                db.StudentGroup.Add(studentGroup);
                db.SaveChanges();
                return studentGroup;

            }
        }

        public List<StudentGroup> GetAll()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = dbContext.StudentGroup.ToList();
                return result;
            }
        }

    }
}



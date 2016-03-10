using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace EntityLib
{
    public class StudentRepository : IStudenRepository
    {
        public string Insert(StudentModel model)
        {
            try
            {
                using (var std = new StudentEntities())
                {
                    using (var trans = std.Database.BeginTransaction())
                    {
                        try
                        {
                            string result = std.Students.Add(ModelToDModel(model)).Id;
                            std.SaveChanges();
                            trans.Commit();
                            return result;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Update(StudentModel model)
        {
            try
            {
                using (var std = new StudentEntities())
                {
                    using (var trans = std.Database.BeginTransaction())
                    {
                        try
                        {
                            Student uStd = std.Students.Find(model.ID);
                            if (uStd != null)
                            {
                                uStd.Name = model.Name;
                                uStd.Age = model.Age;
                                uStd.Addresss = model.Address;
                                uStd.ClassName = model.ClassName;
                                std.SaveChanges();
                                trans.Commit();
                                return uStd.Id;
                               
                            }
                            else
                            {
                                throw new ArgumentNullException();
                            }
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string id)
        {
            try
            {
                using (var std = new StudentEntities())
                {
                    using (var trans = std.Database.BeginTransaction())
                    {
                        try
                        {
                            Student uStd = std.Students.Find(id);
                            if (uStd != null)
                            {
                                std.Students.Remove(uStd);
                                std.SaveChanges();
                                trans.Commit();
                            }
                            else
                            {
                                throw new ArgumentNullException();
                            }
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Student ModelToDModel(StudentModel model)
        {
            Student dModel = new Student();
            dModel.Id = model.ID;
            dModel.Name = model.Name;
            dModel.Age = model.Age;
            dModel.ClassName = model.ClassName;
            dModel.Addresss = model.Address;
            return dModel;
        }


        public List<StudentModel> LoadListStudents()
        {
            try
            {
                using (var std = new StudentEntities())
                {
                    var data = std.Students.Select(x => new StudentModel
                    {
                        Age = x.Age,
                        ID = x.Id,
                        Name = x.Name,
                        Address = x.Addresss,
                        ClassName = x.ClassName,
                    }).ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

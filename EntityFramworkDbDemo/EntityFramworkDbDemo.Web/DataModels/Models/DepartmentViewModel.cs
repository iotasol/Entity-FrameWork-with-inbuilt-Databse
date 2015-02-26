/*
 * IOTASOL Pvt. Ltd.
 * Date: 26-02-2015
 * Summary : Class representing simple department entity
 */
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EntityFramworkDbDemo.Web.DataModels.EF;

namespace EntityFramworkDbDemo.Web.DataModels.Models
{
    public class DepartmentViewModel
    {
        #region Public member

        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime CreatedOn { get; set; }


        public DepartmentViewModel()
        {
            _db = new EntityFramworkDbDemoEntities();
        }

        /// <summary>
        ///     To get list of Department from database
        /// </summary>
        /// <returns></returns>
        public List<DepartmentViewModel> GetDepartments()
        {
            return (from department in _db.Departments.ToList()
                select _changeDbToViewModel(department)).ToList();
        }

        /// <summary>
        ///     Create a new Department
        /// </summary>
        /// <param name="model">Object on DepartmentViewModel</param>
        /// <returns></returns>
        public DepartmentViewModel CreateDepartment(DepartmentViewModel model = null)
        {
            if (model == null)
                model = this;
            var dbModel = _changeViewModelToDb(model);

            dbModel.GUID = System.Guid.NewGuid().ToString();
            dbModel.CreatedOn = DateTime.Now;

            if (IsExist(m => m.DepartmentCode == dbModel.DepartmentCode))
                throw new InvalidOperationException("Department Code is already in Database");

            _db.Departments.Add(dbModel);
            _db.SaveChanges();
            return _changeDbToViewModel(dbModel);
        }

        /// <summary>
        ///     To check wheter the value exist in database
        /// </summary>
        /// <param name="filter">to check value</param>
        /// <returns></returns>
        public bool IsExist(Func<Department, bool> filter)
        {
            var dept = _db.Departments.Where(filter).FirstOrDefault();
            if (null != dept)
                return true;
            return false;
        }
        /// <summary>
        /// Get a single dept by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DepartmentViewModel GetSingle(int id)
        {
            var dept = _db.Departments.FirstOrDefault(x => x.Id.Equals(id));
            return _changeDbToViewModel(dept);
        }
        /// <summary>
        /// Get a Single Depatment
        /// </summary>
        /// <param name="filter">To filter from department</param>
        /// <example>
        ///     GetDepartment(x=>x.Guid.Equals(guid)
        /// </example>
        /// <returns></returns>
        public Department GetDepartment(Func<Department, bool> filter)
        {
            return _db.Departments.Where(filter).FirstOrDefault();
        }
        /// <summary>
        /// To update existing dept
        /// </summary>
        public void Update()
        {
            if (IsExist(m => m.DepartmentCode.Equals(DepartmentCode) && m.Name.Equals(Name)))
                throw new InvalidOperationException("This Department name and code is already registred");

            var dept = GetDepartment(x => x.GUID.Equals(Guid));
            dept.DepartmentCode = DepartmentCode;
            dept.Name = Name;

            _db.Entry(dept).State = EntityState.Modified;
            _db.SaveChanges();
        }
        
        /// <summary>
        /// To Delete a dept by id
        /// </summary>
        /// <param name="id">primary key+</param>
        public void Delete(int id)
        {
            var dept = _db.Departments.Find(id);
            _db.Departments.Remove(dept);
            _db.SaveChanges();
        }

        #endregion

        #region Private members

        private readonly EntityFramworkDbDemoEntities _db;

        /// <summary>
        ///     Convert Database model to viewmodel
        /// </summary>
        private readonly Func<Department, DepartmentViewModel> _changeDbToViewModel =
            department => new DepartmentViewModel
            {
                Id = department.Id,
                Guid = department.GUID,
                Name = department.Name,
                CreatedOn = department.CreatedOn,
                DepartmentCode = department.DepartmentCode
            };

        /// <summary>
        ///     Convert viewmodel to database model
        /// </summary>
        private readonly Func<DepartmentViewModel, Department> _changeViewModelToDb = department => new Department
        {
            Id = department.Id,
            GUID = department.Guid,
            Name = department.Name,
            CreatedOn = department.CreatedOn,
            DepartmentCode = department.DepartmentCode
        };

        #endregion
    }
}
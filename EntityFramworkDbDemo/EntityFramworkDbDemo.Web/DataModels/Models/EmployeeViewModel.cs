/*
 * IOTASOL Pvt. Ltd.
 * Date: 26-02-2015
 * Summary : Class representing simple Employee entity
 */
using System;

namespace EntityFramworkDbDemo.Web.DataModels.Models
{
    internal class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public int DepartmentCode { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
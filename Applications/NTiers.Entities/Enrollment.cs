//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NTiers.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enrollment
    {
        public int EnrollID { get; set; }
        public int CourseID { get; set; }
        public int stdID { get; set; }
    
        public virtual Course Courses { get; set; }
        public virtual Student Students { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EducationPlatform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reviewstudent
    {
        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> MentorId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public string FeedBack { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}

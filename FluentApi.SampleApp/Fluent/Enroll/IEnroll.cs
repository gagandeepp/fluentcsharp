using System;
using System.Collections.Generic;
using FluentApi.SampleApp.Models;


namespace FluentApi.SampleApp.Fluent
{
    public interface IEnroll 
    {
        IEnroll WithStudents(Func<IEnumerable<Student>,IEnumerable<Student>> func);
        IEnroll ForCourse(string courseId);
        void Save();
    }
}
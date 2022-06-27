using System;
using System.Collections.Generic;
using FluentApi.SampleApp.Models;

namespace FluentApi.SampleApp.Fluent
{
    public class Enroll : IEnroll {
        public IEnumerable<Student> FilteredStudents {get;set;}
        public Course Course {get;set;}

        public IEnroll WithStudents(Func<IEnumerable<Student>,IEnumerable<Student>> func)
        {
            var studentRepository = RepositoryFactory.CreateStudentRepository();
            var students = studentRepository.GetStudents();

            FilteredStudents = func.Invoke(students);

            return this as IEnroll;
        }

        public IEnroll ForCourse(string courseId){
            if(string.IsNullOrEmpty(courseId)) throw new ArgumentNullException(nameof(courseId));

            var courseRepository = RepositoryFactory.CreateCourseRepository();
            Course = courseRepository.GetCourseById(courseId);
            return this as IEnroll;
        }

        public void Save()
        {
            var courseRepository = RepositoryFactory.CreateCourseRepository();
            
            foreach (var student in FilteredStudents)
            {
                if (!student.IsRegistered)
                {
                    var enrollment = new Enrollment
                    {
                        Student = student,
                        Course = Course
                    };
                    courseRepository.Save(enrollment);
                }
            }
        }

    }
}
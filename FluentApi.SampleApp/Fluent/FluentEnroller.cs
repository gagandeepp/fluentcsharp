using System;

namespace FluentApi.SampleApp.Fluent 
{
    public class FluentEnroller
    {
        public IEnroll Enroll()
        {
            return new Enroll();
        }
    }
}
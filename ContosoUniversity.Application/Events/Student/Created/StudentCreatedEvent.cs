using System;
using MediatR;

namespace ContosoUniversity.Application.Events.Student.Created
{
    public class StudentCreatedEvent : INotification
    {
        public StudentCreatedEvent(string lastName, string firstName, DateTime enrollmentAtDate)
        {
            LastName = lastName;
            FirstName = firstName;
            EnrollmentAtDate = enrollmentAtDate;
        }

        public string LastName { get; private set; }

        public string FirstName { get; private set; }

        public DateTime EnrollmentAtDate { get; private set; }
    }
}
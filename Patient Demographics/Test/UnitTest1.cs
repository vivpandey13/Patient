using DBClasses;
using Helpers;
using Moq;
using NUnit.Framework;
using Patient_Demographics.Controllers;
using Patient_Demographics.Models;
using System.Collections.Generic;
using System.Web.Http.Results;
using Test;


namespace Tests
{
    public class Tests
    {
        List<Patient> list;
        
        [SetUp]
        public void Setup()
        {
            list= PatientInit.InitializePatient();
        }

        [Test]        
        public void GetReturnsListOfPatients()
        {
            // Arrange
            var mockHelper = new Mock<IPatientDemoHelper>();
            mockHelper.Setup(x => x.GetPatients()).Returns(list);

            var mockDemo = new Mock<IPatientDemo_DAO>();

            var controller = new ValuesController(mockDemo.Object,mockHelper.Object);

            // Act
            var actionResult = controller.Get();

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsTrue(actionResult is List<Patient>);
            Assert.IsNotNull(actionResult.Count == 2);
            
        }
        [Test]
        public void AddPatient()
        {
            // Arrange
            Patient patient = new Patient();
            patient.ForeName = "New";
            patient.SurName = "Patient";
            patient.Gender = EnumGender.Female;
            patient.DateOfBirth = "01-01-1999";
            Contact contact = new Contact() { ContactType = EnumContact.Home, Number = "7654398765" };
            patient.Contacts = new List<Contact>() { contact };
            var mockHelper = new Mock<IPatientDemoHelper>();
            mockHelper.Setup(x => x.SavePatient(It.IsAny<Patient>())).Callback((Patient p) => { list.Add(p); });

            var mockDemo = new Mock<IPatientDemo_DAO>();

            var controller = new ValuesController(mockDemo.Object, mockHelper.Object);

            // Act
            int listCount = list.Count;
            controller.Post(patient);

            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list[listCount].ForeName =="New");
            Assert.IsNotNull(list.Count == listCount+1);

        }
    }
}
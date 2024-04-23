using DoctorPatientBLLibrary;
using DoctorPatientDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatienceBLTest
{
    public class PatientBLTest
    {
        IRepository<int, Patient> repository;
        IPatientService patientService;
        [SetUp]
        public void Setup()
        {
            repository = new PatientRepository();
            patientService = new PatientBL(repository);
        }

        [Test]
        public void CreatePatientSuccessTest()
        {
            Patient patient=new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description="Fever" };
            var id = patientService.CreatePatient(patient);
            Assert.AreEqual(1, id);
        }
        //[Test]
        //public void CreatePatientFailTest()
        //{
        //    Patient patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
        //    patientService.CreatePatient(patient);
        //    patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
        //    var exception = Assert.Throws<DuplicatePatientNameException>(() => patientService.CreatePatient(patient));

        //    Assert.AreEqual("Patient already exists", exception.Message);
        //}

        [Test]
        public void DeletePatientSuccessTest()
        {
            Patient patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
            var id = patientService.CreatePatient(patient);
            var result = patientService.DeletePatient(id);
            Assert.AreEqual(1, result.PatienceID);
        }
        [Test]
        public void DeleteDoctorFailTest()
        {
            Patient patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
            var id = patientService.CreatePatient(patient);
            var exception = Assert.Throws<PatientNotExistsException>(() => patientService.DeletePatient(2));
            Assert.AreEqual("Patient does not exists", exception.Message);
        }

        [Test]
        public void GetAllPatientsSuccessTest()
        {
            Patient patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
            var id = patientService.CreatePatient(patient);
            var result = patientService.GetAllPatients();
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void GetAllPatientsFailTest()
        {
            var result = patientService.GetAllPatients();
            Assert.IsNull(result);
        }

        [Test]
        public void GetPatientByIdSuccessTest()
        {
            Patient patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
            var id = patientService.CreatePatient(patient);
            var result = patientService.GetPatientByID(id);
            Assert.AreEqual("rahul", result.Name);
        }

        [Test]
        public void GetPatientByIdFailTest()
        {
            Patient patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
            var id = patientService.CreatePatient(patient);
            var exception = Assert.Throws<PatientNotExistsException>(() => patientService.GetPatientByID(2));
            Assert.AreEqual("Patient does not exists", exception.Message);
        }

        [Test]
        public void UpdatePatientSuccessTest()
        {
            Patient patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
            patientService.CreatePatient(patient);
            Patient patient1 = new Patient() {PatienceID=1, Name = "rahul", Age = 12, Gender = "Male", Description = "Headache" };
            var result = patientService.UpdatePatient(patient1);
            Assert.AreEqual("Headache", result.Description);
        }

        [Test]
        public void UpdateDoctorFailTest()
        {
            Patient patient = new Patient() { Name = "rahul", Age = 12, Gender = "Male", Description = "Fever" };
            var id=patientService.CreatePatient(patient);
            Patient patient1 = new Patient() { PatienceID = 2, Name = "rahul", Age = 12, Gender = "Male", Description = "Headache" };
            var exception = Assert.Throws<PatientNotExistsException>(() => patientService.UpdatePatient(patient1));
            Assert.AreEqual("Patient does not exists", exception.Message);
        }

    }
}

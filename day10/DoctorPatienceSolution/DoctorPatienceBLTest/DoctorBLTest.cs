using DoctorPatientBLLibrary;
using DoctorPatientDALLibrary;
using ModelClassLibrary;

namespace DoctorPatienceBLTest
{
    public class DoctorBLTest
    {
        IRepository<int, Doctor> repository;
        IDoctorSerivce doctorService;
        [SetUp]
        public void Setup()
        {
            repository = new DoctorRepository();
            doctorService = new DoctorBL(repository);
        }

        [Test]
        public void CreateDoctorSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
            var id = doctorService.CreateDoctor(doctor);
            Assert.AreEqual(1, id);
        }
        //[Test]
        //public void CreateDoctorFailTest()
        //{
        //    Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
        //    doctorService.CreateDoctor(doctor);
        //    doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
        //    var result = doctorService.CreateDoctor(doctor);
        //    Assert.IsNull(result);       
        //}

        [Test]
        public void DeleteDoctorSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
            var id = doctorService.CreateDoctor(doctor);
            var result = doctorService.DeleteDoctor(id);
            Assert.AreEqual(1, result.DoctorID);
        }
        [Test]
        public void DeleteDoctorFailTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
            var id = doctorService.CreateDoctor(doctor);
            var exception = Assert.Throws<DoctorNotExistsException>(() => doctorService.DeleteDoctor(2));
            Assert.AreEqual("Doctor does not exists", exception.Message);
        }

        [Test]
        public void GetAllDoctorsSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
            var id = doctorService.CreateDoctor(doctor);
            var result=doctorService.GetAllDoctors();
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void GetAllDoctorsFailTest()
        {
           var result = doctorService.GetAllDoctors();
           Assert.IsNull(result);
        }

        [Test]
        public void GetDoctorByAvailabilitySuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
            doctorService.CreateDoctor(doctor);
            doctor = new Doctor() { DoctorName = "ram", Specialization = "brain", Available = false };
            doctorService.CreateDoctor(doctor);
            var result = doctorService.GetDoctorByAvailability(true);
            Assert.AreEqual(1,result.Count);
        }

        [Test]
        public void GetDoctorByAvailabilityFailTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = false };
            doctorService.CreateDoctor(doctor);
            doctor = new Doctor() { DoctorName = "ram", Specialization = "brain", Available = false };
            doctorService.CreateDoctor(doctor);
            var result = doctorService.GetDoctorByAvailability(true);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetDoctorByIdSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = false };
            doctorService.CreateDoctor(doctor);
            var result= doctorService.GetDoctorByID(1);
            Assert.AreEqual("rahul",result.DoctorName);
        }

        [Test]
        public void GetDoctorByIdFailTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
            var id = doctorService.CreateDoctor(doctor);
            var exception = Assert.Throws< DoctorNotExistsException> (() => doctorService.GetDoctorByID(2));
            Assert.AreEqual("Doctor does not exists", exception.Message);
        }


        [Test]
        public void GetDoctorBySpecializationSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
            doctorService.CreateDoctor(doctor);
            doctor = new Doctor() { DoctorName = "ram", Specialization = "head", Available = true };
            doctorService.CreateDoctor(doctor);
            var result = doctorService.GetDoctorBySpecialization("head");
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetDoctorBySpecializationFailTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = false };
            doctorService.CreateDoctor(doctor);
            doctor = new Doctor() { DoctorName = "ram", Specialization = "brain", Available = false };
            doctorService.CreateDoctor(doctor);
            var result = doctorService.GetDoctorBySpecialization("head");
            Assert.IsEmpty(result);
        }


        [Test]
        public void UpdateDoctorSuccessTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = false };
            doctorService.CreateDoctor(doctor);
            Doctor doctor1 = new Doctor() {DoctorID=1, DoctorName = "rahul", Specialization = "head", Available = false };
            var result = doctorService.UpdateDoctor(doctor1);
            Assert.AreEqual("head", result.Specialization);
        }

        [Test]
        public void UpdateDoctorFailTest()
        {
            Doctor doctor = new Doctor() { DoctorName = "rahul", Specialization = "brain", Available = true };
            var id = doctorService.CreateDoctor(doctor);
            Doctor doctor1 = new Doctor() { DoctorID = 2, DoctorName = "rahul", Specialization = "head", Available = false };
            var exception = Assert.Throws<DoctorNotExistsException>(() => doctorService.UpdateDoctor(doctor1));
            Assert.AreEqual("Doctor does not exists", exception.Message);
        }

    }
}
This solution contains an ASP.NET MVC API project. The API contains a single controller which has a single endpoint.

The endpoint can be accessed using the following URL...

http://{your binding}/patients/{patientId}/episodes

...where {your binding} is whatever binding you specify if you set the API up as a project in IIS, and {patientId} is an integer.

The API uses Entity Framework 6 to connect to a SQL database on Azure. The contents of the database were created by the class PatientInitialiser. The login to the database specified in the connection string has select access to those two tables and no other permissions.

If the patient ID in the URL matches a patient in the SQL database, that patient is returned along with its episodes. If not, the endpoint returns 404.

The API is crudely designed, and in particular, is poorly architected for automated testing.

You may be aware that Linq join syntax works over object collections in the same way it does against a SQL database. For example, in the following code, the Linq query will return an object containing the Patient and the Episode exactly as you might expect:

            var patientsInMemory = new List<Patient>
                {
                    new Patient
                        {
                            DateOfBirth = new DateTime(1972, 10, 27),
                            FirstName = "Millicent",
                            PatientId = 1,
                            LastName = "Hammond",
                            NhsNumber = "1111111111"
                        }
                };

            var episodesInMemory = new List<Episode>
                {
                    new Episode
                        {
                            AdmissionDate = new DateTime(2014, 11, 12),
                            Diagnosis = "Irritation of inner ear",
                            DischargeDate = new DateTime(2014, 11, 27),
                            EpisodeId = 1,
                            PatientId = 1
                        }
                };

            var patientsAndEpisodes =
                from p in patientsInMemory
                join e in episodesInMemory on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new {p, e};

This means it is possible to write test code that uses in-memory objects to test our Linq logic without touching a real database.

At Careflow, we usually write our 'unit' tests against an entire graph of objects rather than an isolated class instance. So in the case of this crude patients API, we would instantiate the controller itself and call its action, passing it a patient ID, and then assert that we get the patient object back that we expect. In order to do this, we call the application's IoC container in our test code and ask it to provide us with an instance of the controller. However, we do substitute out external dependencies such as a SQL database. In order to do this, we have to configure the container to accept runtime substitutions of its registrations. So our test code can say something like 'give me an instance of PatientsController, but substitute the component which talks to the SQL database with this fake one'.

This is what you are being asked to do in this exercise. To summarise:
- Refactor the API project to use an IoC container of your choice to instantiate the controller and its dependencies.
- Create an alternative implementation of the component that loads data from the database which instead works across in-memory collections.
- Write unit tests that call the IoC container to get an instance of the controller, but substitute the registration for the real data access component with the in-memory one, and verify the following:
- - If the database contains a patient with 1 episode, and the controller action is called with that patient's ID, then the patient is returned with its episode
- - If the controller action is called with a patient ID that doesn't match a patient in the database, then a 404 is returned.
- Create a github repository that contains your work and invite the user DavidCleaveDocCom to it.

Do this work as you would in a real professional context, but don't do any refactoring work outside the scope of the objectives above. Make a note of any refactorings you would choose to make given time.

Don't worry if you cannot complete the assignment. Just commit whatever you can.

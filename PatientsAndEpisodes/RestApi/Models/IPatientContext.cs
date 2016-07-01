using System.Data.Entity;

namespace RestApi.Models
{
    public interface IPatientContext
    {
        DbSet<Episode> Episodes { get; set; }
        DbSet<Patient> Patients { get; set; }
    }
}
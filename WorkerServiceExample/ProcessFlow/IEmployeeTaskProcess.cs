using System.Threading.Tasks;

namespace WorkerServiceExample.ProcessFlow
{
    public interface IEmployeeTaskProcess
    {
        Task StartTheWork();

        Task AssignTheWork();

        Task ProgressTheWork();

    }
}
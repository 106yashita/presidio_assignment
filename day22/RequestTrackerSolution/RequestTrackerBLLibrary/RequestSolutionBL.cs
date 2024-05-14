using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestSolutionBL : IRequestSolutionBL
    {
        private readonly IRepository<int, RequestSolution> _solutionRepository;
        public RequestSolutionBL()
        {
            IRepository<int, RequestSolution> repo = new RequestSolutionRepository(new RequestTrackerContext());
            _solutionRepository = repo;
        }
        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            var addedSolution = await _solutionRepository.Add(solution);
            return addedSolution;
        }



        public async Task<bool> RespondToSolution(int requestId, string response)
        {

            var requestSolution = await _solutionRepository.Get(requestId);
            if (requestSolution == null)
            {

                return false;
            }
            if (string.IsNullOrEmpty(response))
            {
                return false;
            }

            requestSolution.RequestRaiserComment = response;
            await _solutionRepository.Update(requestSolution);
            return true;
        }

        public async Task<IList<RequestSolution>> ViewSolution(int requestId)
        {
            var solutions = (await _solutionRepository.GetAll()).Where(e => e.RequestId == requestId).ToList();
            if (solutions.Count == 0)
                throw new NoSolutionExists();
            return solutions;
        }
    }
}

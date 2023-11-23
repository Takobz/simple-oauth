using SimpleAuthServer.Data.Entities;

namespace SimpleAuthServer.Data.Repositories
{
    public class RepoResult<T> where T : Entity
    {
        public RepoResult(T result, bool isSuccess, bool isEmptyResult)
        {
            Result = result;
            IsSuccess = isSuccess;
            IsEmptyResult = isEmptyResult;  
        }

        public T Result { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsEmptyResult { get; private set; }
    }
}
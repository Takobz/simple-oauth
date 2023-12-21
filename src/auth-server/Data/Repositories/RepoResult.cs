using SimpleAuthServer.Data.Entities;

namespace SimpleAuthServer.Data.Repositories
{
    public class RepoResult<T>(T result, bool isSuccess, bool isEmptyResult) where T : Entity
    {
        public T Result { get; private set; } = result;
        public bool IsSuccess { get; private set; } = isSuccess;
        public bool IsEmptyResult { get; private set; } = isEmptyResult;
    }
}
using System.Collections.Generic;

namespace _0_Framework.Infrastructure
{
    public interface IPermissionExposer
    {
        Dictionary< List<string> , List<PermissionDto>> Expose();
    }
}
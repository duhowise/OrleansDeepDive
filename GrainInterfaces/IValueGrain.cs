using System;
using System.Threading.Tasks;
using Orleans;

namespace GrainInterfaces
{
    public interface IValueGrain: IGrainWithIntegerKey
    {
        Task<string> GetValue();
        Task SetValue(string value);
    }
}

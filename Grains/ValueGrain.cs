using System.Threading.Tasks;
using GrainInterfaces;
using Orleans;

namespace Grains
{
    public class ValueGrain:Grain,IValueGrain
    {
        private string _value;
        public Task<string> GetValue()
        {
            return Task.FromResult(_value);
        }

        public Task SetValue(string value)
        {
            _value = value;
            return Task.CompletedTask;
        }
    }
}

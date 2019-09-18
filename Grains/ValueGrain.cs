using System;
using System.Threading.Tasks;
using GrainInterfaces;
using Orleans;
using Orleans.Providers;

namespace Grains
{
   [StorageProvider(ProviderName = "OrleansStorage")] public class ValueGrain:Grain<SavedState>,IValueGrain
    {
        private string _value="none";
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


   public class SavedState : IGrainState
   {
       public object State { get; set; }
       public Type Type { get; }
       public string ETag { get; set; }
   }
}

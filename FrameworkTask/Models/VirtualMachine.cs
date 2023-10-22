using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Models
{
    public class VirtualMachine
    {
        public string NumberOfInstances { get; set; }
        public string OperatingSystem { get; set; }
        public string ProvisioningModel { get; set; }
        public string Series { get; set; }
        public string MachineType { get; set; }
        public string NumberOfGPUs { get; set; }
        public string GPUType { get; set; }
        public string LocalSSD { get; set; }
        public string DatacenterLocation { get; set; }
        public string CommittedUsage { get; set; }

        public VirtualMachine()
        {
                
        }



        
    }
}

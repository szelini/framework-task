using FrameworkTask.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Utilities
{
    public static class VirtualMachineCreator
    {
       public static VirtualMachine CreateVirtualMachine()
        {
            VirtualMachine vm = new VirtualMachine();

            var c = TestContext.CurrentContext;

            vm.NumberOfInstances = TestContext.Parameters["NumberOfInstances"];
            vm.OperatingSystem = TestContext.Parameters["OperatingSystem"];
            vm.ProvisioningModel = TestContext.Parameters["ProvisioningModel"];
            vm.Series = TestContext.Parameters["Series"];
            vm.MachineType = TestContext.Parameters["MachineType"];
            vm.NumberOfGPUs = TestContext.Parameters["NumberOfGPUs"];
            vm.GPUType = TestContext.Parameters["GPUType"]; 
            vm.LocalSSD = TestContext.Parameters["LocalSSD"];
            vm.DatacenterLocation = TestContext.Parameters["DatacenterLocation"];
            vm.CommittedUsage = TestContext.Parameters["CommittedUsage"];
           
            return vm;
        }

    }
}

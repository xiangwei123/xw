using System.Reflection;
using Abp.Modules;

namespace TestProject
{
    public class TestProjectCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

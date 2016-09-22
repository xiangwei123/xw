using System.Reflection;
using Abp.Modules;

namespace TestProject
{
    [DependsOn(typeof(TestProjectCoreModule))]
    public class TestProjectApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

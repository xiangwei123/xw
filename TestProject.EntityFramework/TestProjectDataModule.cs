using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using TestProject.EntityFramework;

namespace TestProject
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(TestProjectCoreModule))]
    public class TestProjectDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<TestProjectDbContext>(null);
        }
    }
}

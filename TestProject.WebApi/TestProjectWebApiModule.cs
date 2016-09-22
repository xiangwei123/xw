using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace TestProject
{
    [DependsOn(typeof(AbpWebApiModule), typeof(TestProjectApplicationModule))]
    public class TestProjectWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(TestProjectApplicationModule).Assembly, "app")
                .Build();
        }
    }
}

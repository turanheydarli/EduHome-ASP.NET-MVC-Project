using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interseptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CourseManager>().As<ICourseService>();
			builder.RegisterType<EfCourseDal>().As<ICourseDal>();

			builder.RegisterType<CourseDetailManager>().As<ICourseDetailService>();
			builder.RegisterType<EfCourseDetailDal>().As<ICourseDetailDal>();

			builder.RegisterType<UserManager>().As<IUserService>();
			builder.RegisterType<EfUserDal>().As<IUserDal>();

			builder.RegisterType<SliderContentManager>().As<ISliderContentService>();
			builder.RegisterType<EfSliderContentDal>().As<ISliderContentDal>();

			builder.RegisterType<NoticeManager>().As<INoticeService>();
			builder.RegisterType<EfNoticeDal>().As<INoticeDal>();

			builder.RegisterType<CourseManager>().As<ICourseService>();
			builder.RegisterType<EfCourseDal>().As<ICourseDal>();

			builder.RegisterType<BlogManager>().As<IBlogService>();
			builder.RegisterType<EfBlogDal>().As<IBlogDal>();

			builder.RegisterType<CategoryManager>().As<ICategoryService>();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

			builder.RegisterType<EventManager>().As<IEventService>();
			builder.RegisterType<EfEventDal>().As<IEventDal>();

			builder.RegisterType<AuthManager>().As<IAuthService>();

			builder.RegisterType<JwtHelper>().As<ITokenHelper>();


			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();
		}
	}
}

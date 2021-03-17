using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
 public  class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();//biri constructor da ICarService isterse ona ICarManager ver

            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();//biri senden constructurda ICarDal isterse ona EfCarDal ver
           

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();//çalıştığında devreye gir

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//AspectInterceptorSelector ı çalıştır ,o da attribute ları okuyordu
                }).SingleInstance();
        }
    }
}

﻿using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstDemo.Controllers
{
    public class WindsorControllerFactory:DefaultControllerFactory
    {
        private readonly IKernel _ikernel;
        public WindsorControllerFactory(IKernel ikernel)
        {
            _ikernel = ikernel;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if(controllerType == null)
            {
                throw new HttpException(404, string.Format("当前对{0}的请求不存在", requestContext.HttpContext.Request.Path));
            }
            return (IController)_ikernel.Resolve(controllerType);
        }
        public override void ReleaseController(IController controller)
        {
            _ikernel.ReleaseComponent(controller);
            base.ReleaseController(controller);
        }


    }
}
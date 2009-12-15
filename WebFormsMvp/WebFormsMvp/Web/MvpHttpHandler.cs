﻿using System;
using System.Web;
using WebFormsMvp.Binder;

namespace WebFormsMvp.Web
{
    public abstract class MvpHttpHandler : IHttpHandler, IView
    {
        public void ProcessRequest(HttpContext context)
        {
            var presenterBinder = new PresenterBinder(this, context);

            OnLoad();

            presenterBinder.Release();
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public event EventHandler Load;
        protected virtual void OnLoad()
        {
            if (Load != null)
            {
                Load(this, new EventArgs());
            }
        }
    }
}
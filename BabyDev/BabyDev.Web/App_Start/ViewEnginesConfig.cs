﻿namespace BabyDev.Web
{
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
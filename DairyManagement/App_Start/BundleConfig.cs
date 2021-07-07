﻿using System.Web.Optimization;

namespace DairyManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
            //            "~/Scripts/dataTables.bootstrap4.min.js",
            //            "~/Scripts/jquery.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapdatatablecss").Include(
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/responsive.bootstrap.min.css"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
            //            "~/Scripts/jquery-ui.js"));

            bundles.IgnoreList.Clear();
        }
    }
}

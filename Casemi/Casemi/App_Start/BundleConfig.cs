﻿using System.Web;
using System.Web.Optimization;

namespace Casemi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.11.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/methods_pt.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalform").Include(
                      "~/Scripts/modalform.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymaskedinput").Include(
                         "~/Scripts/jquery.maskedinput*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/themes/base/*.css",
                      "~/Content/PagedList.css"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace eUseControl.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/bootstrap.min.css",
                new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/categories/css").Include("~/Style/categories.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/reg-log-forms/css").Include("~/Style/reg-log-forms.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/style/css").Include("~/Style/style.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/view-profile/css").Include("~/Style/view-profile.css", new CssRewriteUrlTransform()));
            bundles.Add(new ScriptBundle("~/bundles/menu-resize/js").Include("~/Scripts/menu-resize.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquerry/js").Include("~/Scripts/jquerry-3.3.1.slim.js"));
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new ScriptBundle("~/bundles/tether/js").Include("~/Scripts/tether.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include("~/Scripts/bootstrap.min.js"));

        }
    }
}
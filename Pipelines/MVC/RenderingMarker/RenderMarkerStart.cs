using Sitecore.Configuration;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;

namespace RenderingsMarkerModule.Pipelines.MVC.RenderingMarker
{
    public class RenderMarkerStart : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            if (Settings.GetBoolSetting("RenderingsMarkerModule.Enabled", false))
            {
                Renderer renderer = args.Rendering.Renderer;
                if (renderer == null)
                    return;

                bool isLayout = renderer is ViewRenderer &&
                                ((ViewRenderer) renderer).Rendering.RenderingType == "Layout";
                bool showLayoutMarkers = Settings.GetBoolSetting("RenderingsMarkerModule.ShowLayoutMarkers", false);

                if (isLayout && !showLayoutMarkers) return;

                args.Writer.Write("\n<!-- START: " + renderer + " -->\n");
            }
        }
    }
}
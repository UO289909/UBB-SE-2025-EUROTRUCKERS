using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace UBB_SE_2025_EUROTRUCKERS.MapRouting
{
    internal class DataProvider
    {


        private async void OnShowRouteClicked(object sender, RoutedEventArgs e)
        {
            var startPoint = new BasicGeoposition() { Latitude = 47.620, Longitude = -122.349 };
            var endPoint = new BasicGeoposition() { Latitude = 47.610, Longitude = -122.201 };

            var start = new Geopoint(startPoint);
            var end = new Geopoint(endPoint);

            var routeResult = await MapRouteFinder.GetDrivingRouteAsync(start, end);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                var routeView = new MapRouteView(routeResult.Route);
                routeView.RouteColor = Windows.UI.Colors.Blue;
                routeView.OutlineColor = Windows.UI.Colors.Black;

                MyMap.Routes.Clear();
                MyMap.Routes.Add(routeView);

                await MyMap.TrySetViewBoundsAsync(
                    routeResult.Route.BoundingBox,
                    null,
                    Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Default);
            }
        }

    }
}

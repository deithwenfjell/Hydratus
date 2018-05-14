using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Hydratus.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace Hydratus.iOS
{
    public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            foreach (var item in TabBar.Items)
            {
                item.Image = GetTabIcon(item.Title);
            }
        }

        private UIImage GetTabIcon(string title)
        {
            UITabBarItem item = null;

            switch (title)
            {
                case "Hydratus":
                    item = new UITabBarItem(UITabBarSystemItem.Downloads, 0);
                    break;
                case "Bio":
                    item = new UITabBarItem(UITabBarSystemItem.Contacts, 0);
                    break;
                case "Cyklus":
                    item = new UITabBarItem(UITabBarSystemItem.Recents, 0);
                    break;
            }

            var img = (item != null) ? UIImage.FromImage(item.SelectedImage.CGImage, item.SelectedImage.CurrentScale, item.SelectedImage.Orientation) : new UIImage();
            return img;
        }




    }
}
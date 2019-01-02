﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.PrismDemo
{
    using global::Prism.Regions;
    using System.Windows;
    using System.Windows.Controls;

    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : 
            base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
              {
                  if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                  {
                      foreach (FrameworkElement element in e.NewItems)
                      {
                          regionTarget.Children.Add(element);
                      }
                  }
              };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}

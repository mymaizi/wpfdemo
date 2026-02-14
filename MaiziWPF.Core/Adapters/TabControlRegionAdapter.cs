using Prism.Navigation.Regions;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;

namespace MaiziWPF.Core
{
    public class TabControlRegionAdapter : RegionAdapterBase<TabControl>
    {
        public TabControlRegionAdapter(IRegionBehaviorFactory factory) : base(factory)
        {
        }

        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.ActiveViews.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var view in e.NewItems)
                    {
                        if (regionTarget.Items.Count > 0)
                        {
                            regionTarget.Items.Insert(1, view);
                            regionTarget.SelectedItem= view;
                        }
                        else
                        {
                            regionTarget.Items.Add(view);
                        }
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var view in e.OldItems)
                    {
                        regionTarget.Items.Remove(view);
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

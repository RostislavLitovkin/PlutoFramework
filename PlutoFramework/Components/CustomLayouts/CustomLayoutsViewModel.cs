using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;

namespace PlutoFramework.Components.CustomLayouts
{
	public partial class CustomLayoutsViewModel : ObservableObject
    {
		[ObservableProperty]
        private ObservableCollection<ComponentInfo> componentInfos = new ObservableCollection<ComponentInfo>();

        public CustomLayoutsViewModel()
		{
            try
            {
                componentInfos = Model.CustomLayoutModel.ParsePlutoComponentInfos(
                    Preferences.Get("PlutoLayout",
                    Model.CustomLayoutModel.DEFAULT_PLUTO_LAYOUT)
                );
            }
            catch
            {
                componentInfos = Model.CustomLayoutModel.ParsePlutoComponentInfos(Model.CustomLayoutModel.DEFAULT_PLUTO_LAYOUT);
            }
        }

        public void SwapItems(int originalIndex, int newIndex)
        {
            if (originalIndex == newIndex) return;

            var infos = new ObservableCollection<ComponentInfo>();

            if (originalIndex < newIndex)
            {
                newIndex++;
            }

            for (int i = 0; i < ComponentInfos.Count(); i++)
            {
                if (i == originalIndex)
                {
                    continue;
                }

                if (i == newIndex)
                {
                    infos.Add(ComponentInfos[originalIndex]);
                }

                infos.Add(ComponentInfos[i]);
            }

            if (newIndex == ComponentInfos.Count())
            {
                infos.Add(ComponentInfos[originalIndex]);
            }

            ComponentInfos = infos;

            Model.CustomLayoutModel.SaveLayout(infos);
        }

        public void DeleteItem(int originalIndex)
        {
            var infos = new ObservableCollection<ComponentInfo>();

            for (int i = 0; i < ComponentInfos.Count(); i++)
            {
                if (i == originalIndex)
                {
                    continue;
                }

                infos.Add(ComponentInfos[i]);
            }

            ComponentInfos = infos;

            Model.CustomLayoutModel.SaveLayout(infos);
        }
    }
}


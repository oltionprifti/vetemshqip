using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class KategoriteDataSource : IDataSource<MenuSchema>
    {
        private readonly IEnumerable<MenuSchema> _data = new MenuSchema[]
		{
            new MenuSchema
            {
                Type = "Section",
                Title = "Vendi",
                Icon = "/Assets/DataImages/9655015726_85882bc8ba_o.png",
                Target = "VendiPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Rajoni",
                Icon = "/Assets/DataImages/9651782873_5025abc629_o.png",
                Target = "RajoniPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Bota",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "BotaPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Sport",
                Icon = "/Assets/DataImages/9707861179_a311105360_o-1.png",
                Target = "SportPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Kuriozitete",
                Icon = "/Assets/DataImages/9651782747_fd48be7f92_o.png",
                Target = "KuriozitetePage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Opinion",
                Icon = "/Assets/DataImages/9655015792_d78de1c2b3_o.png",
                Target = "OpinionPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Teknologji",
                Icon = "/Assets/DataImages/9651782171_e4f74d831f_o.png",
                Target = "TeknologjiPage",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "Horoskopi Ditor",
                Icon = "/Assets/DataImages/9651781521_216232023f_o.png",
                Target = "HoroskopiDitorPage",
            },
		};

        public async Task<IEnumerable<MenuSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<MenuSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}

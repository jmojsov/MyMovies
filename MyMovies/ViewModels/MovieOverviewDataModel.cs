using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieOverviewDataModel
    {
        public SideBarData SiedbarData { get; set; }
        public List<MovieOverviewModel> Movies { get; set; }
    }
}

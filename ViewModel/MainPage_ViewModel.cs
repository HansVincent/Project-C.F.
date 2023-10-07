using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_C.F_.Model;

namespace Project_C.F_.ViewModel
{
    public partial class MainPage_ViewModel: MainViewModel
    {
        public ObservableCollection<CarouselContent> CarouselView { get; set; } = new();
        public MainPage_ViewModel() 
        {
            CarouselView.Add(new CarouselContent(){ ImagePath = "mainpage_carosel1.png" });
            CarouselView.Add(new CarouselContent(){ ImagePath = "mainpage_carosel2.png" });
            CarouselView.Add(new CarouselContent(){ ImagePath = "mainpage_carosel3.png" });
            CarouselView.Add(new CarouselContent(){ ImagePath = "mainpage_carosel4.png" });
        }
    }
}
